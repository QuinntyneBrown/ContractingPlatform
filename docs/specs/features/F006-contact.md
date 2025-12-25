# F006 - Contact & Lead Generation Feature

## Feature Overview

| Field | Value |
|-------|-------|
| Feature ID | F006 |
| Feature Name | Contact & Lead Generation |
| Priority | Critical |
| Status | Planned |

## Description

Primary conversion point for the website. Provides multiple contact methods and a comprehensive lead capture form. This feature is critical for business success as it converts website visitors into qualified leads.

---

## User Stories

### US-021: Submit Project Inquiry
**As a** homeowner with a renovation project
**I want to** submit my project details through a form
**So that** I can get a quote from the company

### US-022: Emergency Contact
**As a** homeowner with water damage
**I want to** find an emergency contact number quickly
**So that** I can get immediate help

### US-023: Find Location
**As a** a local customer
**I want to** see the company's office location
**So that** I can verify they are a real local business

### US-024: Multiple Contact Options
**As a** a visitor with preferences
**I want to** choose how to contact the company
**So that** I can use my preferred method

---

## Requirements

| ID | Requirement | Priority | Status |
|----|-------------|----------|--------|
| F006-R01 | Comprehensive contact form | Critical | Planned |
| F006-R02 | Form validation (client & server) | Critical | Planned |
| F006-R03 | Multiple contact methods display | High | Planned |
| F006-R04 | Service type selection dropdown | High | Planned |
| F006-R05 | File upload for project photos | Medium | Planned |
| F006-R06 | Emergency services section | High | Planned |
| F006-R07 | Office location with map | Medium | Planned |
| F006-R08 | Business hours display | Medium | Planned |
| F006-R09 | Form submission confirmation | High | Planned |
| F006-R10 | Email notification to admin | Critical | Planned |
| F006-R11 | Spam protection (reCAPTCHA) | High | Planned |

---

## Page Sections (Order)

1. Header/Navigation (F001)
2. Hero Section
3. Emergency Contact Banner
4. Contact Form
5. Contact Information
6. Office Location & Map
7. Business Hours
8. FAQ (Optional)
9. Footer (F008)

---

## Acceptance Criteria

### AC-042: Contact Page Hero
```gherkin
Feature: Contact Page Hero
  Scenario: Hero display
    Given the user navigates to /contact
    When the page loads
    Then a hero section should display with:
      | Element | Content |
      | Headline | "Contact Us" |
      | Subheadline | "Get Your Free Estimate Today" |
    And the page should feel welcoming and professional
```

### AC-043: Emergency Contact Section
```gherkin
Feature: Emergency Contact
  Scenario: Emergency section display
    Given the user is on the contact page
    When viewing the emergency section
    Then a prominent banner should display with:
      | Element | Content |
      | Headline | "24/7 Emergency Services" |
      | Phone | "(718) 550-2779" |
      | Text | "Water damage? Fire? Call us anytime." |
    And the section should use high-visibility colors
    And the phone number should be clickable (tel: link)
    And an emergency icon should be displayed
```

### AC-044: Contact Form Fields
```gherkin
Feature: Contact Form
  Scenario: Form field display
    Given the user views the contact form
    Then the following fields should be present:
      | Field | Type | Required | Validation |
      | Full Name | text | Yes | Min 2 chars |
      | Email | email | Yes | Valid email format |
      | Phone | tel | Yes | Valid phone format |
      | Service Type | select | Yes | Must select option |
      | Project Address | text | No | - |
      | Preferred Contact | radio | No | Email/Phone/Either |
      | Message | textarea | No | Max 2000 chars |
      | Photos | file | No | Max 5 files, 10MB each |
      | Submit | button | - | "Send Message" |

  Scenario: Service type options
    Given the user clicks the Service Type dropdown
    Then the following options should be available:
      | Option |
      | General Inquiry |
      | Kitchen Renovation |
      | Bathroom Renovation |
      | Basement Services |
      | Water Damage Restoration |
      | Fire Damage Restoration |
      | Roofing |
      | Exterior/Facade |
      | Sidewalk/DOT Violation |
      | Other |
```

### AC-045: Form Validation
```gherkin
Feature: Form Validation
  Scenario: Required field validation
    Given the user submits the form with empty required fields
    When clicking Submit
    Then inline error messages should appear below each empty required field
    And error messages should be in red
    And the form should not submit
    And focus should move to the first error field

  Scenario: Email validation
    Given the user enters an invalid email format
    When the field loses focus or form submits
    Then an error message should display: "Please enter a valid email address"

  Scenario: Phone validation
    Given the user enters an invalid phone number
    When the field loses focus or form submits
    Then an error message should display: "Please enter a valid phone number"

  Scenario: File upload validation
    Given the user attempts to upload files
    When selecting more than 5 files
    Then an error should display: "Maximum 5 files allowed"
    When selecting a file larger than 10MB
    Then an error should display: "File size must be under 10MB"
    When selecting a non-image file
    Then an error should display: "Only image files are allowed"
```

### AC-046: Form Submission
```gherkin
Feature: Form Submission
  Scenario: Successful submission
    Given the user has filled all required fields correctly
    When clicking Submit
    Then a loading spinner should appear on the button
    And the button should be disabled
    And on success, a confirmation message should display:
      | Element | Content |
      | Headline | "Thank You!" |
      | Message | "We've received your message..." |
      | Timeline | "We'll respond within 24 hours" |
    And the form should be cleared or hidden

  Scenario: Email notifications
    Given a form is successfully submitted
    Then an email should be sent to the admin
    And a confirmation email should be sent to the customer
    And the email should include all form data

  Scenario: Submission error
    Given a server error occurs during submission
    Then an error message should display
    And the user should be advised to try again or call
    And the form data should be preserved
```

### AC-047: reCAPTCHA Protection
```gherkin
Feature: Spam Protection
  Scenario: reCAPTCHA verification
    Given the contact form is displayed
    Then Google reCAPTCHA v3 should be active
    Or reCAPTCHA v2 checkbox should be visible

  Scenario: Bot detection
    Given a bot attempts to submit the form
    When reCAPTCHA score is too low
    Then the submission should be blocked
    And the user should see a CAPTCHA challenge
```

### AC-048: Contact Information Display
```gherkin
Feature: Contact Information
  Scenario: Contact details display
    Given the user is on the contact page
    When viewing the contact information section
    Then the following should be displayed:
      | Info | Value | Interaction |
      | Phone | (718) 550-2779 | Clickable tel: link |
      | Email | info@company.com | Clickable mailto: link |
      | Address | 99 Wall St, Ste 172, NYC | Links to map |
    And appropriate icons should accompany each item
```

### AC-049: Business Hours
```gherkin
Feature: Business Hours
  Scenario: Hours display
    Given the user is on the contact page
    When viewing business hours
    Then the following should display:
      | Day | Hours |
      | Monday - Friday | 8:00 AM - 5:00 PM |
      | Saturday | 9:00 AM - 2:00 PM |
      | Sunday | Closed |
      | Emergency | 24/7 Available |
    And current status should be indicated (Open/Closed)
```

### AC-050: Location Map
```gherkin
Feature: Office Location Map
  Scenario: Map display
    Given the user is on the contact page
    When viewing the map section
    Then an interactive Google Map should display
    And the office location should be marked with a pin
    And the map should be zoomable and pannable
    And clicking the pin should show address info

  Scenario: Directions link
    Given the map is displayed
    Then a "Get Directions" link should be available
    And clicking should open Google Maps with directions
```

### AC-051: File Upload
```gherkin
Feature: Photo Upload
  Scenario: Upload interface
    Given the file upload field is displayed
    Then it should show "Upload Project Photos (Optional)"
    And a drag-and-drop zone should be visible
    And a "Browse" button should be available
    And accepted formats should be indicated (JPG, PNG)

  Scenario: File preview
    Given the user selects files to upload
    Then thumbnail previews should display
    And each file should show name and size
    And a remove (X) button should be on each thumbnail

  Scenario: Upload progress
    Given files are being uploaded
    Then progress indicators should show upload status
    And users should be able to continue filling the form
```

---

## Form Data Structure

```json
{
  "id": "lead-001",
  "timestamp": "2024-03-15T14:30:00Z",
  "source": "contact-form",
  "contact": {
    "name": "John Smith",
    "email": "john@example.com",
    "phone": "(917) 555-1234",
    "preferredContact": "phone"
  },
  "project": {
    "serviceType": "kitchen-renovation",
    "address": "123 Main St, Brooklyn, NY 11201",
    "message": "Looking to renovate our kitchen...",
    "attachments": [
      {
        "name": "kitchen-photo.jpg",
        "size": 2500000,
        "url": "/uploads/lead-001/kitchen-photo.jpg"
      }
    ]
  },
  "meta": {
    "ip": "192.168.1.1",
    "userAgent": "Mozilla/5.0...",
    "recaptchaScore": 0.9,
    "referrer": "google.com"
  },
  "status": "new"
}
```

---

## Email Templates

### Admin Notification

```
Subject: New Lead: Kitchen Renovation - John Smith

NEW LEAD RECEIVED

Contact Information:
- Name: John Smith
- Email: john@example.com
- Phone: (917) 555-1234
- Preferred: Phone

Project Details:
- Service: Kitchen Renovation
- Address: 123 Main St, Brooklyn, NY 11201

Message:
Looking to renovate our kitchen...

Attachments: 1 file(s)

---
Received: March 15, 2024 at 2:30 PM
Source: Contact Form
```

### Customer Confirmation

```
Subject: We've Received Your Message - [Company Name]

Hi John,

Thank you for contacting [Company Name]!

We've received your inquiry about Kitchen Renovation and one of our
team members will be in touch within 24 hours.

If you need immediate assistance, please call us at (718) 550-2779.

Your Reference: #LEAD-001

Best regards,
The [Company Name] Team
```

---

## UI Specifications

### Form Container
- Max-width: 600px
- Padding: 40px
- Background: White
- Border-radius: 12px
- Shadow: 0 10px 40px rgba(0,0,0,0.1)

### Form Fields
- Height: 48px (inputs)
- Border: 1px solid #D1D5DB
- Border-radius: 8px
- Focus border: 2px solid #1E40AF
- Error border: 2px solid #DC2626
- Font size: 16px (prevents zoom on iOS)

### Labels
- Font size: 14px
- Font weight: 500
- Color: #374151
- Margin bottom: 8px

### Error Messages
- Font size: 12px
- Color: #DC2626
- Icon: Exclamation circle
- Margin top: 4px

### Submit Button
- Width: 100%
- Height: 56px
- Background: #1E40AF
- Color: White
- Font size: 18px
- Font weight: 600
- Border-radius: 8px
- Hover: Background #1E3A8A

### Emergency Banner
- Background: #FEF3C7 (amber-100)
- Border-left: 4px solid #F59E0B
- Text color: #92400E
- Icon color: #F59E0B
- Padding: 24px

### Contact Info Cards
- Grid: 3 columns (desktop)
- Card padding: 24px
- Icon size: 32px
- Icon background: Primary color at 10% opacity

### Map Container
- Height: 400px
- Border-radius: 12px
- Overflow: hidden

---

## Wireframe Reference

See: [../wireframes/contact.md](../wireframes/contact.md)

---

## Integration Requirements

| Integration | Purpose | Priority |
|-------------|---------|----------|
| Google reCAPTCHA v3 | Spam prevention | High |
| Email Service (SendGrid/etc) | Notifications | Critical |
| Google Maps API | Location map | Medium |
| File Storage (S3/etc) | Photo uploads | Medium |
| CRM (optional) | Lead management | Low |

---

## Accessibility Requirements

- All form fields must have associated labels
- Error messages must be announced to screen readers
- Focus management after form submission
- Color contrast must meet WCAG 2.1 AA
- Touch targets minimum 44x44px

---

## Dependencies

- F001: Navigation
- F008: Footer

## Related Features

- F002: Homepage (CTA links here)
- F003: Services (CTA links here with service pre-selected)
