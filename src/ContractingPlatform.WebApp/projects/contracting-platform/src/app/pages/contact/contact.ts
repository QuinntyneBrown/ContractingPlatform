import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BehaviorSubject, finalize } from 'rxjs';
import { HeroSection } from 'contracting-platform-components';
import { ApiService, CreateLeadRequest } from '../../services';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    HeroSection,
  ],
  templateUrl: './contact.html',
  styleUrl: './contact.scss',
})
export class Contact {
  private fb = inject(FormBuilder);
  private apiService = inject(ApiService);

  private submittingSubject = new BehaviorSubject<boolean>(false);
  private submittedSubject = new BehaviorSubject<boolean>(false);
  private errorSubject = new BehaviorSubject<string | null>(null);

  submitting$ = this.submittingSubject.asObservable();
  submitted$ = this.submittedSubject.asObservable();
  error$ = this.errorSubject.asObservable();

  contactForm = this.fb.group({
    fullName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
    email: ['', [Validators.required, Validators.email, Validators.maxLength(200)]],
    phone: ['', [Validators.required, Validators.pattern(/^[\d\s\-\(\)\+]+$/), Validators.maxLength(50)]],
    serviceType: ['', Validators.required],
    projectAddress: ['', Validators.maxLength(500)],
    message: ['', Validators.maxLength(2000)],
    preferredContactMethod: ['Either'],
  });

  serviceTypes = [
    { value: 'General Inquiry', label: 'General Inquiry' },
    { value: 'Kitchen Renovation', label: 'Kitchen Renovation' },
    { value: 'Bathroom Renovation', label: 'Bathroom Renovation' },
    { value: 'Basement Services', label: 'Basement Services' },
    { value: 'Water Damage Restoration', label: 'Water Damage Restoration' },
    { value: 'Fire Damage Restoration', label: 'Fire Damage Restoration' },
    { value: 'Roofing', label: 'Roofing' },
    { value: 'Exterior/Facade', label: 'Exterior/Facade' },
    { value: 'Sidewalk/DOT Violation', label: 'Sidewalk/DOT Violation' },
    { value: 'Other', label: 'Other' },
  ];

  contactMethods = [
    { value: 'Email', label: 'Email' },
    { value: 'Phone', label: 'Phone' },
    { value: 'Either', label: 'Either' },
  ];

  onSubmit(): void {
    if (this.contactForm.invalid) {
      this.contactForm.markAllAsTouched();
      return;
    }

    this.submittingSubject.next(true);
    this.errorSubject.next(null);

    const formValue = this.contactForm.value;
    const request: CreateLeadRequest = {
      fullName: formValue.fullName || '',
      email: formValue.email || '',
      phone: formValue.phone || '',
      serviceType: formValue.serviceType || '',
      projectAddress: formValue.projectAddress || undefined,
      message: formValue.message || undefined,
      preferredContactMethod: formValue.preferredContactMethod || 'Either',
    };

    this.apiService.createLead(request)
      .pipe(finalize(() => this.submittingSubject.next(false)))
      .subscribe({
        next: () => {
          this.submittedSubject.next(true);
          this.contactForm.reset();
        },
        error: () => {
          this.errorSubject.next('There was an error submitting your request. Please try again or call us directly.');
        },
      });
  }

  resetForm(): void {
    this.submittedSubject.next(false);
    this.errorSubject.next(null);
  }
}
