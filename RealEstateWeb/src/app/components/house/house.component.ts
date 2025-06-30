import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HousingService } from '../../services/house.service';

@Component({
  selector: 'app-house',
  templateUrl: './house.component.html',
  styleUrl: './house.component.scss',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class HouseComponent {
  houseForm = new FormGroup({
    name: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    state: new FormControl('', Validators.required),
    availableUnits: new FormControl(1, [Validators.required, Validators.min(1)]),
    wifi: new FormControl(false),
    laundry: new FormControl(false),
    photo: new FormControl(''),
    photoLocal: new FormControl<string | ArrayBuffer | null>(null)
  });
  photoLocalPreview: string | ArrayBuffer | null = null;

  constructor(private housingService: HousingService) {}

  onPhotoLocalChange(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.photoLocalPreview = reader.result;
        this.houseForm.patchValue({ photoLocal: reader.result });
      };
      reader.readAsDataURL(file);
    }
  }

  submitHouse() {
    if (this.houseForm.invalid) {
      this.houseForm.markAllAsTouched();
      return;
    }
    this.housingService.addHouse(this.houseForm.value);
    alert('House submitted!');
    this.houseForm.reset();
    this.photoLocalPreview = null;
  }
}
