# F004 - About Us Feature

## Feature Overview

| Field | Value |
|-------|-------|
| Feature ID | F004 |
| Feature Name | About Us |
| Priority | Medium |
| Status | Planned |

## Description

Company information page that builds trust and establishes credibility. Tells the company story, introduces leadership, displays credentials, and reinforces the value proposition of working with an experienced, family-owned contractor.

---

## User Stories

### US-013: Company Background
**As a** potential customer
**I want to** learn about the company's history and values
**So that** I can trust them with my home

### US-014: Meet the Team
**As a** homeowner
**I want to** see who will be working on my project
**So that** I feel comfortable with the people involved

### US-015: Credential Verification
**As a** cautious buyer
**I want to** verify the company's licenses and certifications
**So that** I know they are legitimate and qualified

### US-016: Service Area Confirmation
**As a** NYC resident
**I want to** confirm they service my area
**So that** I don't waste time with a company that doesn't cover my location

---

## Requirements

| ID | Requirement | Priority | Status |
|----|-------------|----------|--------|
| F004-R01 | Company history and founding story | High | Planned |
| F004-R02 | Leadership/team profiles section | Medium | Planned |
| F004-R03 | Mission statement and company values | Medium | Planned |
| F004-R04 | Licenses and certifications display | High | Planned |
| F004-R05 | Service area coverage with map | High | Planned |
| F004-R06 | Company statistics recap | Medium | Planned |
| F004-R07 | Company photos/office images | Low | Planned |

---

## Page Sections (Order)

1. Header/Navigation (F001)
2. Hero Section
3. Company Story
4. Mission & Values
5. Key Statistics
6. Team/Leadership
7. Credentials & Licenses
8. Service Areas
9. CTA Section
10. Footer (F008)

---

## Acceptance Criteria

### AC-027: About Hero Section
```gherkin
Feature: About Page Hero
  Scenario: Hero display
    Given the user navigates to /about
    When the page loads
    Then a hero section should display with:
      | Element | Content |
      | Headline | "About [Company Name]" |
      | Subheadline | "Family-Owned, NYC-Built Since 1987" |
      | Background | Team photo or office image |
    And a breadcrumb should show: Home > About Us
```

### AC-028: Company Story
```gherkin
Feature: Company Story
  Scenario: Story section display
    Given the user is on the about page
    When scrolling to the company story section
    Then a narrative should display covering:
      | Topic |
      | Founding year (1987) |
      | Founder background |
      | Family-owned emphasis |
      | Growth over the years |
      | Commitment to NYC community |
    And an accompanying photo should display
    And the content should feel personal and authentic
```

### AC-029: Mission and Values
```gherkin
Feature: Mission and Values
  Scenario: Values display
    Given the user is on the about page
    When scrolling to the mission section
    Then the company mission statement should display
    And core values should be listed:
      | Value | Description |
      | Quality | Commitment to superior craftsmanship |
      | Integrity | Honest pricing and transparent communication |
      | Reliability | On-time, on-budget project delivery |
      | Customer Focus | Treating every home like our own |
      | Safety | Strict adherence to safety standards |
    And each value should have an icon and brief description
```

### AC-030: Team Section
```gherkin
Feature: Team Profiles
  Scenario: Team member display
    Given the user is on the about page
    When scrolling to the team section
    Then key team members should display:
      | Role | Elements |
      | CEO/Founder | Photo, name, title, bio, years experience |
      | Project Manager | Photo, name, title, bio |
      | Lead Contractor | Photo, name, title, specialties |
    And photos should be professional headshots
    And bios should be 2-3 sentences each
    And team grid should be responsive (3 cols > 2 > 1)
```

### AC-031: Credentials Section
```gherkin
Feature: Credentials Display
  Scenario: Licenses and certifications
    Given the user is on the about page
    When scrolling to the credentials section
    Then the following should display:
      | Credential | Details |
      | NYC General Contractor License | License number visible |
      | BBB Accreditation | A+ rating badge |
      | Insurance | "Fully Licensed & Insured" |
      | Workers Comp | Coverage confirmation |
    And official logos should be displayed where applicable
    And credentials should link to verification (if possible)

  Scenario: Trust indicators
    Given credentials are displayed
    Then additional trust indicators should show:
      | Indicator |
      | 37+ Years in Business |
      | 6,500+ Completed Projects |
      | Family-Owned & Operated |
      | 24/7 Emergency Service |
```

### AC-032: Service Areas
```gherkin
Feature: Service Areas Display
  Scenario: Borough coverage
    Given the user is on the about page
    When scrolling to the service areas section
    Then an NYC map graphic should display
    And all 5 boroughs should be highlighted:
      | Borough | Key Neighborhoods |
      | Manhattan | Upper East Side, Greenwich Village, Tribeca |
      | Brooklyn | Williamsburg, Park Slope, DUMBO |
      | Queens | Astoria, Long Island City, Forest Hills |
      | Bronx | Riverdale, Pelham Bay, Fordham |
      | Staten Island | St. George, Tottenville |
    And clicking a borough should show neighborhood list
    Or neighborhoods should be listed below each borough

  Scenario: Location verification
    Given service areas are displayed
    Then the user should be able to identify if their area is covered
    And a message should indicate "Serving all of NYC and surrounding areas"
```

### AC-033: About Page CTA
```gherkin
Feature: About Page CTA
  Scenario: Call-to-action display
    Given the user has read the about content
    When scrolling to the CTA section
    Then a CTA should display with:
      | Element | Content |
      | Headline | "Ready to Work With NYC's Trusted Contractor?" |
      | Button | "Get Free Estimate" |
      | Phone | "(718) 550-2779" |
    And the button should link to the contact page
```

---

## Content Requirements

### Company Story Content

```markdown
# Our Story

[Company Name] was founded in 1987 by [Founder Name], a second-generation
contractor who learned the trade from his father in the heart of Brooklyn.
What started as a small family operation has grown into one of NYC's most
trusted contracting companies.

For over 37 years, we've been transforming homes and buildings across all
five boroughs. Our commitment to quality craftsmanship and honest business
practices has earned us the trust of over 6,500 satisfied customers.

As a family-owned business, we understand that your home is more than just
a building—it's where memories are made. That's why we treat every project
with the same care and attention we'd give our own homes.

Today, our team of licensed professionals continues the tradition of
excellence that [Founder Name] established nearly four decades ago.
We're proud to serve the NYC community and look forward to being your
trusted contractor for generations to come.
```

### Team Profiles

**Raja Riasat - CEO & Founder**
With over 30 years of experience in construction and renovation, Raja founded [Company Name] with a vision of bringing quality craftsmanship and honest service to NYC homeowners. He personally oversees major projects and maintains relationships with long-term clients.

---

## UI Specifications

### Hero Section
- Height: 50vh
- Background: Team/company photo with overlay
- Title: 44px, font-weight 700
- Subtitle: 20px, font-weight 400

### Story Section
- Layout: 2-column (text + image)
- Text column: 60% width
- Image column: 40% width
- On mobile: Stack vertically

### Values Grid
- Grid: 5 columns (desktop), responsive
- Card style: Icon above, text below
- Icon size: 48px
- Icon color: Primary

### Team Grid
- Grid: 3 columns (desktop)
- Photo: Square, 200x200px
- Border radius: Full (circular) or 8px
- Shadow on hover

### Credentials
- Logo row: Flexbox, center aligned
- Logo max-height: 60px
- Grayscale default, color on hover

### Service Areas Map
- Map width: 100% of section
- Max-width: 800px, centered
- Interactive hover states on boroughs
- Color: Primary color for active areas

---

## Wireframe Reference

See: [../wireframes/about.md](../wireframes/about.md)

---

## SEO Considerations

- Meta Title: "About [Company Name] | NYC General Contractor Since 1987"
- Meta Description: "Learn about [Company Name], a family-owned NYC contractor with 37+ years of experience. Licensed, insured, and trusted by over 6,500 customers."
- Structured Data: LocalBusiness, Organization

---

## Dependencies

- F001: Navigation
- F008: Footer

## Related Features

- F002: Homepage (statistics, about preview)
- F006: Contact (CTA destination)
