# F003 - Services Pages Feature

## Feature Overview

| Field | Value |
|-------|-------|
| Feature ID | F003 |
| Feature Name | Services Pages |
| Priority | High |
| Status | Planned |

## Description

Comprehensive service pages that detail all contracting services offered. Includes a services overview page and individual detail pages for each service category. These pages serve as key SEO landing pages and conversion points.

---

## User Stories

### US-009: Service Discovery
**As a** potential customer
**I want to** see all available services in one place
**So that** I can understand the full range of offerings

### US-010: Service Details
**As a** homeowner with a specific need
**I want to** read detailed information about a specific service
**So that** I can understand what's included and if it meets my needs

### US-011: Service Process Understanding
**As a** first-time renovation customer
**I want to** understand the process for a service
**So that** I know what to expect

### US-012: Visual Evidence
**As a** decision-maker
**I want to** see examples of completed work for a service
**So that** I can evaluate the quality

---

## Service Categories

### Primary Services

| Category | URL | Services Included |
|----------|-----|-------------------|
| General Contracting | /services/general-contracting | Full renovations, remodeling, new construction |
| Kitchen Renovation | /services/kitchen | Cabinet installation, countertops, appliances, plumbing |
| Bathroom Renovation | /services/bathroom | Fixtures, tile, plumbing, accessibility modifications |
| Basement Services | /services/basement | Finishing, legalization, waterproofing, conversions |
| Restoration | /services/restoration | Water damage, fire damage, mold, insurance claims |
| Roofing | /services/roofing | Repair, replacement, flat roofs, maintenance |
| Exterior | /services/exterior | Siding, facades, masonry, sidewalks |
| Specialty | /services/specialty | Leak detection, structural repairs, DOT violations |

---

## Requirements

| ID | Requirement | Priority | Status |
|----|-------------|----------|--------|
| F003-R01 | Services overview page with all categories | High | Planned |
| F003-R02 | Individual service detail pages | High | Planned |
| F003-R03 | Service-specific galleries | Medium | Planned |
| F003-R04 | Process explanation section | Medium | Planned |
| F003-R05 | Related services suggestions | Low | Planned |
| F003-R06 | Service-specific CTAs | High | Planned |
| F003-R07 | FAQ section per service | Medium | Planned |
| F003-R08 | Pricing indication (if applicable) | Low | Planned |

---

## Acceptance Criteria

### AC-017: Services Overview Page
```gherkin
Feature: Services Overview
  Scenario: Overview page display
    Given the user navigates to /services
    When the page loads
    Then a hero section with "Our Services" headline should display
    And a grid of all service categories should display
    And each category card should include:
      | Element |
      | Service icon |
      | Service name |
      | Brief description (2-3 sentences) |
      | "Learn More" link |
    And categories should be organized logically

  Scenario: Service category navigation
    Given the services overview is displayed
    When the user clicks on a service category card
    Then they should navigate to the respective service detail page
    And the URL should match /services/{service-slug}
```

### AC-018: Service Detail Page Structure
```gherkin
Feature: Service Detail Page
  Scenario: Detail page sections
    Given the user navigates to a service detail page
    When the page loads
    Then the following sections should be present (in order):
      | Section | Content |
      | Hero | Service name, hero image, brief intro |
      | Overview | Detailed service description |
      | Benefits | List of key benefits/features |
      | Process | Step-by-step process explanation |
      | Gallery | Before/after images, project photos |
      | Testimonials | Service-specific customer reviews |
      | FAQ | Common questions about the service |
      | CTA | Contact form or quote request |
      | Related | Related services suggestions |
```

### AC-019: Service Hero Section
```gherkin
Feature: Service Hero
  Scenario: Hero display for service page
    Given the user is on a service detail page
    When viewing the hero section
    Then the following should display:
      | Element | Example |
      | Background image | High-quality service-related image |
      | Service title | "Kitchen Renovation" |
      | Breadcrumb | Home > Services > Kitchen Renovation |
      | Brief intro | 1-2 sentence value proposition |
      | CTA button | "Get Free Kitchen Quote" |
```

### AC-020: Benefits Section
```gherkin
Feature: Service Benefits
  Scenario: Benefits list display
    Given the user is on a service detail page
    When scrolling to the benefits section
    Then a list of 4-6 key benefits should display
    And each benefit should have:
      | Element |
      | Check icon or custom icon |
      | Benefit title |
      | Brief description |
    And benefits should be displayed in a 2-column grid (desktop)
```

### AC-021: Process Section
```gherkin
Feature: Service Process
  Scenario: Process steps display
    Given the user is on a service detail page
    When scrolling to the process section
    Then a numbered step-by-step process should display
    And typical steps include:
      | Step | Title |
      | 1 | Initial Consultation |
      | 2 | Design & Planning |
      | 3 | Proposal & Contract |
      | 4 | Construction Phase |
      | 5 | Quality Inspection |
      | 6 | Final Walkthrough |
    And each step should have a title and description
    And a timeline visualization should connect steps
```

### AC-022: Service Gallery
```gherkin
Feature: Service Gallery
  Scenario: Gallery display
    Given the user is on a service detail page
    When scrolling to the gallery section
    Then a grid of project images should display
    And at least 6 images should be shown
    And before/after comparisons should be available

  Scenario: Gallery lightbox
    Given images are displayed in the gallery
    When the user clicks on an image
    Then a lightbox overlay should open
    And navigation arrows should allow browsing
    And an X button or clicking outside should close the lightbox

  Scenario: Before/After slider
    Given a before/after image pair is displayed
    When the user interacts with the slider
    Then dragging the slider should reveal more of before or after image
    And touch interactions should work on mobile
```

### AC-023: Service-Specific Testimonials
```gherkin
Feature: Service Testimonials
  Scenario: Testimonial relevance
    Given the user is on a service detail page (e.g., Kitchen)
    When viewing the testimonials section
    Then only testimonials related to that service should display
    And each testimonial should indicate the service received
    And at least 2-3 testimonials should be shown
```

### AC-024: Service FAQ
```gherkin
Feature: Service FAQ
  Scenario: FAQ accordion
    Given the user is on a service detail page
    When scrolling to the FAQ section
    Then an accordion of common questions should display
    And questions should be specific to that service
    And clicking a question should expand the answer
    And only one answer should be visible at a time (optional)

  Example FAQs for Kitchen Renovation:
    | Question |
    | How long does a kitchen renovation take? |
    | Can I stay in my home during the renovation? |
    | Do you handle permits and inspections? |
    | What is included in a full kitchen renovation? |
    | How do I choose the right cabinets? |
```

### AC-025: Related Services
```gherkin
Feature: Related Services
  Scenario: Related services display
    Given the user is on a service detail page
    When scrolling to the related services section
    Then 3-4 related service cards should display
    And services should be logically related
    Example: Kitchen page shows Bathroom, General Contracting, Basement
    And each card should link to its respective page
```

### AC-026: Service CTA
```gherkin
Feature: Service-Specific CTA
  Scenario: CTA section
    Given the user is on a service detail page
    When scrolling to the CTA section
    Then a prominent call-to-action should display
    And include service-specific text: "Get Your Free Kitchen Quote"
    And include either:
      - Inline contact form
      - Link to contact page with service pre-selected
    And phone number should be displayed
```

---

## Service Page Content Template

### Kitchen Renovation (/services/kitchen)

**Hero:**
- Title: "Kitchen Renovation Services"
- Subtitle: "Transform Your Kitchen Into the Heart of Your Home"
- Image: Modern renovated kitchen

**Overview:**
Expert kitchen renovations tailored to your style and needs. From custom cabinetry to state-of-the-art appliances, we handle every aspect of your kitchen transformation.

**Benefits:**
1. Custom Design - Personalized layouts that maximize space
2. Quality Materials - Premium cabinets, countertops, and fixtures
3. Licensed Professionals - NYC certified contractors
4. Project Management - Dedicated project manager throughout
5. Warranty - Workmanship guarantee on all installations
6. Code Compliance - All work meets NYC building codes

**Process:**
1. Free Consultation - We visit your home to discuss your vision
2. Design Phase - 3D renderings and material selection
3. Proposal - Detailed quote with timeline
4. Permitting - We handle all required permits
5. Construction - Professional installation
6. Inspection - Quality checks throughout
7. Completion - Final walkthrough and warranty

---

## UI Specifications

### Overview Page
- Hero height: 40vh
- Grid: 3 columns (desktop), 2 (tablet), 1 (mobile)
- Card spacing: 24px gap
- Card padding: 32px

### Detail Page Hero
- Height: 50vh
- Overlay: linear-gradient with brand colors
- Title size: 40px
- Breadcrumb: 14px, color #9CA3AF

### Benefits Grid
- 2 columns (desktop), 1 column (mobile)
- Icon size: 40px
- Icon color: Primary (#1E40AF)
- Title: 18px, font-weight 600
- Description: 14px, color #6B7280

### Process Timeline
- Vertical on mobile, horizontal on desktop
- Step numbers in circles
- Connecting line between steps
- Active/completed state styling

### Gallery
- Grid: Masonry or 3-column
- Image spacing: 16px
- Hover overlay with magnify icon
- Lazy loading for performance

---

## Wireframe Reference

See: [../wireframes/services.md](../wireframes/services.md)

---

## SEO Considerations

Each service page should have:
- Unique meta title: "{Service} in NYC | Company Name"
- Meta description: Unique 155-character description
- H1: Service name only
- Structured data: Service schema
- Internal links: Related services, projects

---

## Dependencies

- F001: Navigation (service dropdown)
- F008: Footer
- F005: Projects (gallery may link to projects)
- F007: Testimonials (filtered testimonials)

## Related Features

- F002: Homepage (services grid)
- F006: Contact (CTA destination)
