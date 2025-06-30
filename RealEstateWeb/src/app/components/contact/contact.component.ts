import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class ContactComponent {
  contactForm = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.pattern(/^\p{L}+(?:[\p{L} .'-]+)*$/u)
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ])
  });

  submitContact() {
    if (this.contactForm.invalid) {
      this.contactForm.markAllAsTouched();
      return;
    }
    // Handle valid form submission here
    alert('Contact form submitted!');
  }
}
