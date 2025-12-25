# F008 - Footer Feature

## Feature Overview

| Field | Value |
|-------|-------|
| Feature ID | F008 |
| Feature Name | Footer |
| Priority | High |
| Status | Planned |

## Description

Consistent footer displayed across all pages containing essential company information, navigation links, service areas, and legal information. The footer serves as a secondary navigation and trust-building element.

---

## User Stories

### US-028: Quick Navigation
**As a** website visitor
**I want to** access main pages from the footer
**So that** I can navigate without scrolling to the top

### US-029: Contact Access
**As a** potential customer
**I want to** find contact information in the footer
**So that** I can reach the company easily

### US-030: Service Area Verification
**As a** NYC resident
**I want to** quickly verify my borough is serviced
**So that** I know the company covers my area

### US-031: Legal Information
**As a** a cautious visitor
**I want to** access privacy and terms pages
**So that** I can understand how my data is used

---

## Requirements

| ID | Requirement | Priority | Status |
|----|-------------|----------|--------|
| F008-R01 | Company information and logo | High | Planned |
| F008-R02 | Contact information section | High | Planned |
| F008-R03 | Quick navigation links | High | Planned |
| F008-R04 | Services links list | Medium | Planned |
| F008-R05 | Service areas section | Medium | Planned |
| F008-R06 | Social media links | Medium | Planned |
| F008-R07 | Copyright notice | High | Planned |
| F008-R08 | Legal links (Privacy, Terms) | High | Planned |
| F008-R09 | Newsletter signup (optional) | Low | Planned |
| F008-R10 | Back to top button | Low | Planned |

---

## Footer Sections

1. **Top Row** (4 columns on desktop)
   - Company Info
   - Quick Links
   - Services
   - Contact

2. **Service Areas Row**
   - NYC Boroughs list

3. **Bottom Bar**
   - Copyright
   - Legal links
   - Social icons

---

## Acceptance Criteria

### AC-059: Footer Structure
```gherkin
Feature: Footer Layout
  Scenario: Desktop footer display
    Given the user is on any page with viewport >= 992px
    When scrolling to the footer
    Then the footer should display with 4 columns:
      | Column 1 | Column 2 | Column 3 | Column 4 |
      | Company Info | Quick Links | Services | Contact |
    And a service areas row below
    And a bottom bar with copyright and legal

  Scenario: Mobile footer display
    Given the viewport is < 768px
    When viewing the footer
    Then columns should stack vertically
    And content should be centered or left-aligned
    And all information should remain accessible
```

### AC-060: Company Information Section
```gherkin
Feature: Company Info Column
  Scenario: Company info display
    Given the footer is displayed
    When viewing the company column
    Then the following should display:
      | Element | Content |
      | Logo | Company logo (light version for dark footer) |
      | Tagline | "NYC's Trusted Contractor Since 1987" |
      | Description | 2-3 sentence company summary |
      | Licenses | "Licensed & Insured" badge |
```

### AC-061: Quick Links Section
```gherkin
Feature: Quick Links Column
  Scenario: Navigation links display
    Given the footer is displayed
    When viewing the Quick Links column
    Then the following links should be present:
      | Link |
      | Home |
      | About Us |
      | Services |
      | Projects |
      | Testimonials |
      | Contact |
    And each link should navigate to the correct page
    And hover state should indicate interactivity
```

### AC-062: Services Links Section
```gherkin
Feature: Services Column
  Scenario: Services list display
    Given the footer is displayed
    When viewing the Services column
    Then the top services should be listed:
      | Service |
      | Kitchen Renovation |
      | Bathroom Renovation |
      | Basement Finishing |
      | Water Damage Restoration |
      | Roofing |
      | General Contracting |
    And each should link to its service page
```

### AC-063: Contact Section
```gherkin
Feature: Contact Column
  Scenario: Contact info display
    Given the footer is displayed
    When viewing the Contact column
    Then the following should display:
      | Element | Content | Interaction |
      | Phone | (718) 550-2779 | tel: link |
      | Email | info@company.com | mailto: link |
      | Address | 99 Wall St, Ste 172, New York, NY | map link |
      | Hours | Mon-Fri: 8am-5pm | - |
      | Emergency | 24/7 Emergency Service | highlighted |
    And icons should accompany each item
```

### AC-064: Service Areas Section
```gherkin
Feature: Service Areas
  Scenario: Borough display
    Given the footer is displayed
    When viewing the service areas section
    Then NYC boroughs should be listed:
      | Borough |
      | Manhattan |
      | Brooklyn |
      | Queens |
      | Bronx |
      | Staten Island |
    And a "Serving All of NYC" headline should display
    And boroughs may link to area-specific pages (optional)
```

### AC-065: Social Media Links
```gherkin
Feature: Social Media
  Scenario: Social icon display
    Given the footer is displayed
    When viewing the social media section
    Then icons should display for:
      | Platform | Icon |
      | Facebook | Facebook icon |
      | Instagram | Instagram icon |
      | LinkedIn | LinkedIn icon |
      | Yelp | Yelp icon (optional) |
    And each should open in a new tab
    And icons should have hover states
```

### AC-066: Bottom Bar
```gherkin
Feature: Footer Bottom Bar
  Scenario: Bottom bar content
    Given the footer is displayed
    When viewing the bottom bar
    Then the following should display:
      | Element | Content |
      | Copyright | "© 2024 [Company Name]. All rights reserved." |
      | Privacy | Link to Privacy Policy |
      | Terms | Link to Terms of Service |
      | Accessibility | Link to Accessibility Statement |
    And links should be separated by dividers
```

### AC-067: Back to Top Button
```gherkin
Feature: Back to Top
  Scenario: Button visibility
    Given the user has scrolled down the page
    When the footer comes into view
    Then a "Back to Top" button should be visible

  Scenario: Button interaction
    Given the Back to Top button is visible
    When the user clicks the button
    Then the page should smooth-scroll to the top
    And the button should fade out when at top
```

### AC-068: Newsletter Signup (Optional)
```gherkin
Feature: Newsletter Signup
  Scenario: Newsletter form display
    Given newsletter signup is enabled
    When viewing the footer
    Then a newsletter section should display with:
      | Element |
      | Headline: "Stay Updated" |
      | Email input field |
      | Subscribe button |
    And the form should validate email format
    And success message should display on submit
```

---

## UI Specifications

### Footer Container
- Background: #111827 (gray-900) or #1E3A5F (dark blue)
- Text color: White (#FFFFFF)
- Secondary text: #9CA3AF (gray-400)
- Padding: 60px 0 (main), 24px 0 (bottom bar)

### Logo (Footer Version)
- Use light/white version of logo
- Max height: 40px
- Margin bottom: 20px

### Column Headers
- Font size: 18px
- Font weight: 600
- Color: White
- Margin bottom: 24px
- Text transform: None or uppercase

### Links
- Font size: 14px
- Color: #9CA3AF (default)
- Color hover: White
- Line height: 2.0 (for spacing)
- No underline

### Contact Items
- Icon size: 20px
- Icon color: Primary accent (#3B82F6)
- Spacing: 16px between items
- Text size: 14px

### Service Areas Row
- Background: Slightly lighter than footer (#1F2937)
- Padding: 24px 0
- Text: Centered
- Boroughs: Inline with bullet separators

### Social Icons
- Size: 24px
- Container: 40px circle
- Background: rgba(255,255,255,0.1)
- Hover background: Primary color
- Spacing: 12px between

### Bottom Bar
- Border top: 1px solid rgba(255,255,255,0.1)
- Background: Same as footer or slightly darker
- Text size: 12px
- Flexbox: Space-between (copyright left, links right)

### Responsive Behavior
- Desktop (≥992px): 4 columns
- Tablet (768-991px): 2x2 grid
- Mobile (<768px): Single column, stacked
- Bottom bar: Stack on mobile

---

## Footer Content

### Company Description
```
[Company Name] is a family-owned general contracting company serving
NYC since 1987. With over 6,500 completed projects, we specialize in
renovations, restorations, and new construction across all five boroughs.
```

### Contact Details
```
Phone: (718) 550-2779
Email: info@company.com
Address: 99 Wall St, Suite 172
         New York, NY 10005

Hours: Monday - Friday: 8:00 AM - 5:00 PM
       Saturday: 9:00 AM - 2:00 PM
       Emergency: 24/7 Available
```

---

## Wireframe

```
┌─────────────────────────────────────────────────────────────────┐
│  FOOTER (Dark Background)                                       │
├─────────────────────────────────────────────────────────────────┤
│                                                                  │
│  [LOGO]              Quick Links    Services        Contact     │
│  Family-owned        ─────────────  ───────────     ─────────── │
│  contractor          • Home         • Kitchen       📞 (718)    │
│  since 1987...       • About        • Bathroom         550-2779 │
│                      • Services     • Basement      📧 info@    │
│  Licensed &          • Projects     • Restoration   📍 99 Wall  │
│  Insured             • Contact      • Roofing          St, NYC  │
│                                                     🕐 Mon-Fri  │
│                                                                  │
├─────────────────────────────────────────────────────────────────┤
│     Serving All of NYC: Manhattan • Brooklyn • Queens •         │
│                         Bronx • Staten Island                    │
├─────────────────────────────────────────────────────────────────┤
│  © 2024 Company. All rights reserved.    Privacy | Terms | f in │
└─────────────────────────────────────────────────────────────────┘
```

---

## Dependencies

- None (base feature)

## Related Features

- F001: Navigation (mirrors links)
- F006: Contact (detailed contact info)
