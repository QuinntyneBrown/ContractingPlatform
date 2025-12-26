import { TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { Contact } from './contact';

describe('Contact', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Contact],
      providers: [
        provideRouter([]),
        provideHttpClient(),
        provideAnimationsAsync(),
      ],
    }).compileComponents();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    expect(component).toBeTruthy();
  });

  it('should have contact form', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    expect(component.contactForm).toBeTruthy();
  });

  it('should have required form fields', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    expect(component.contactForm.get('fullName')).toBeTruthy();
    expect(component.contactForm.get('email')).toBeTruthy();
    expect(component.contactForm.get('phone')).toBeTruthy();
    expect(component.contactForm.get('serviceType')).toBeTruthy();
  });

  it('should have service types', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    expect(component.serviceTypes.length).toBeGreaterThan(0);
  });

  it('should have contact methods', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    expect(component.contactMethods.length).toBe(3);
  });

  it('should invalidate form with empty required fields', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    expect(component.contactForm.valid).toBe(false);
  });

  it('should validate form with all required fields', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    component.contactForm.patchValue({
      fullName: 'John Smith',
      email: 'john@example.com',
      phone: '7185551234',
      serviceType: 'Kitchen Renovation',
    });
    expect(component.contactForm.valid).toBe(true);
  });

  it('should reset form', () => {
    const fixture = TestBed.createComponent(Contact);
    const component = fixture.componentInstance;
    component.resetForm();
    // Check that submitting and error states are reset
    component.submitted$.subscribe(submitted => {
      expect(submitted).toBe(false);
    });
  });
});
