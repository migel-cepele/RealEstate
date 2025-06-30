import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HousingService } from '../../services/house.service';
import { House } from '../../interfaces/house';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ApplicationService } from '../../services/application.service';
import { UserApplication } from '../../interfaces/userApplication';
import { ApplicationFacade } from '../../store/application/application.facade';

@Component({
  standalone: true,
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.scss',
  imports: [CommonModule, ReactiveFormsModule]
})
export class DetailsComponent {
  housingLocation: House = {} as House;
  housingService = inject(HousingService);
  route: ActivatedRoute = inject(ActivatedRoute);
  applicationFacade = inject(ApplicationFacade);

  ngOnInit() {
    this.route.params.subscribe(params => {
      const housingLocationId = Number(params['id']);
      this.housingService.getHousingLocationById(housingLocationId)
        .then((housingLocation) => {
          this.housingLocation = housingLocation;
          if (!this.housingLocation) {
            console.error('Housing location not found');
          }
        });
    });
  }

  applyForm = new FormGroup({
    firstName: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[\p{L} .'-]+$/u)
    ]),
    lastName: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[\p{L} .'-]+$/u)
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    phoneNr: new FormControl('', [
      Validators.required,
      Validators.pattern(/^\+?[0-9\s-]{7,20}$/)
    ]),
    offerAmount: new FormControl('', [
      Validators.required,
      Validators.pattern(/^\d+(\.\d{1,2})?$/)
    ]),
    description: new FormControl('', [
      Validators.maxLength(500)
    ])
  });

  constructor() {}

  async submitApplication() {
    if (this.applyForm.invalid) {
      this.applyForm.markAllAsTouched();
      return;
    }
    
    const application : UserApplication = {
      id: 0,
      firstName: this.applyForm.value.firstName ?? '',
      lastName: this.applyForm.value.lastName ?? '',
      email: this.applyForm.value.email ?? '',
      phoneNo: this.applyForm.value.phoneNr ?? '',
      offerAmount: Number.parseInt(this.applyForm.value.offerAmount ?? ''),
      description: this.applyForm.value.description ?? '',
      houseId: this.housingLocation.id,
      isAccepted: false,
      isRejected: false
    };
    try {
      await this.applicationFacade.addApplication(application);
      // Optionally show a success message or reset the form
    } catch (error) {
      console.error('Failed to submit application', error);
    }
  }

  
}
