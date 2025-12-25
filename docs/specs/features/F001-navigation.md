# F001 - Navigation & Header Feature

## Feature Overview

| Field | Value |
|-------|-------|
| Feature ID | F001 |
| Feature Name | Navigation & Header |
| Priority | High |
| Status | Planned |

## Description

A responsive navigation system that provides easy access to all main sections of the website. The header serves as the primary navigation interface and includes branding, contact information, and call-to-action elements.

---

## User Stories

### US-001: Primary Navigation
**As a** website visitor
**I want to** easily navigate between main sections of the website
**So that** I can find the information I need quickly

### US-002: Mobile Navigation
**As a** mobile user
**I want to** access navigation through a hamburger menu
**So that** I can navigate the site on smaller screens

### US-003: Quick Contact Access
**As a** potential customer
**I want to** see the phone number prominently displayed
**So that** I can call immediately without searching

### US-004: Request Quote
**As a** homeowner needing services
**I want to** quickly access a quote request form
**So that** I can get pricing information easily

---

## Requirements

| ID | Requirement | Priority | Status |
|----|-------------|----------|--------|
| F001-R01 | Display company logo that links to homepage | High | Planned |
| F001-R02 | Show primary navigation menu with main page links | High | Planned |
| F001-R03 | Include phone number prominently displayed | High | Planned |
| F001-R04 | Provide "Get a Quote" call-to-action button | Critical | Planned |
| F001-R05 | Support mobile hamburger menu on small screens | High | Planned |
| F001-R06 | Sticky header on scroll | Medium | Planned |
| F001-R07 | Dropdown menus for services categories | Medium | Planned |

---

## Acceptance Criteria

### AC-001: Logo Display and Functionality
```gherkin
Feature: Logo Display
  Scenario: Logo visibility and navigation
    Given the user is on any page of the website
    When the page finishes loading
    Then the company logo should be visible in the left side of the header
    And the logo should have alt text for accessibility
    And clicking the logo should navigate to the homepage "/"
```

### AC-002: Primary Navigation Links
```gherkin
Feature: Navigation Menu
  Scenario: Navigation link visibility
    Given the user is on any page with viewport width >= 992px
    When viewing the header navigation
    Then the following links should be visible:
      | Link Text | URL |
      | Home | / |
      | Services | /services |
      | About Us | /about |
      | Projects | /projects |
      | Contact | /contact |
    And the current page link should be visually highlighted
```

### AC-003: Phone Number Display
```gherkin
Feature: Phone Number Display
  Scenario: Desktop phone display
    Given the user is on any page with viewport width >= 768px
    When viewing the header
    Then a phone number should be displayed in the header
    And the phone number should be formatted as "(718) 550-2779"

  Scenario: Mobile phone interaction
    Given the user is on any page with viewport width < 768px
    When viewing the phone number
    Then the phone number should be a clickable tel: link
    And clicking should initiate a phone call
```

### AC-004: Get a Quote CTA
```gherkin
Feature: Quote Request CTA
  Scenario: CTA button visibility and function
    Given the user is on any page
    When viewing the header
    Then a "Get Free Estimate" button should be visible
    And the button should use the primary accent color
    And clicking the button should navigate to /contact#quote-form
```

### AC-005: Mobile Hamburger Menu
```gherkin
Feature: Mobile Navigation
  Scenario: Hamburger menu display
    Given the viewport width is less than 992px
    When the page loads
    Then a hamburger menu icon (three horizontal lines) should be visible
    And the primary navigation links should be hidden

  Scenario: Hamburger menu interaction
    Given the hamburger menu icon is visible
    When the user clicks the hamburger icon
    Then a mobile menu should slide in from the right
    And all primary navigation links should be visible
    And a close (X) button should be visible
    And clicking outside the menu should close it
```

### AC-006: Sticky Header Behavior
```gherkin
Feature: Sticky Header
  Scenario: Header becomes sticky on scroll
    Given the user is on any page
    When scrolling down more than 100px from the top
    Then the header should become fixed to the top of the viewport
    And a subtle drop shadow should appear below the header
    And the header should have a solid background color

  Scenario: Header returns to normal on scroll up
    Given the header is in sticky mode
    When the user scrolls to the top of the page (< 100px)
    Then the header should return to its normal position
    And the drop shadow should be removed
```

### AC-007: Services Dropdown Menu
```gherkin
Feature: Services Dropdown
  Scenario: Dropdown on hover (desktop)
    Given the viewport width is >= 992px
    When the user hovers over "Services" in the navigation
    Then a dropdown menu should appear with service categories:
      | Category |
      | General Contracting |
      | Basement Services |
      | Restoration |
      | Exterior Services |
      | Specialty Services |
    And each category should link to its respective page

  Scenario: Dropdown on mobile
    Given the viewport width is < 992px
    And the mobile menu is open
    When the user taps "Services"
    Then the services submenu should expand below
    And a collapse arrow indicator should rotate
```

---

## UI Components

### Header Container
- Fixed height: 80px (desktop), 60px (mobile)
- Background: White (#FFFFFF)
- Border bottom: 1px solid #E5E7EB
- Shadow (when sticky): 0 2px 10px rgba(0,0,0,0.1)

### Logo
- Max height: 50px (desktop), 40px (mobile)
- Alignment: Left
- Padding: 0 20px

### Navigation Links
- Font: 16px, weight 500
- Color: #374151 (default), #1E40AF (hover/active)
- Spacing: 32px between links

### CTA Button
- Background: #1E40AF
- Color: White
- Padding: 12px 24px
- Border radius: 6px
- Hover: Background #1E3A8A

### Phone Number
- Font: 18px, weight 600
- Color: #1E40AF
- Icon: Phone icon before number

---

## PlantUML Component Diagram

See: [../architecture/c4-component.puml](../architecture/c4-component.puml)

---

## Wireframe Reference

See: [../wireframes/homepage.md](../wireframes/homepage.md) (Header section)

---

## Dependencies

- None (base feature)

## Related Features

- F002: Homepage (contains header)
- F006: Contact (CTA destination)
