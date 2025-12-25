# F007 - Testimonials Feature

## Feature Overview

| Field | Value |
|-------|-------|
| Feature ID | F007 |
| Feature Name | Testimonials |
| Priority | Medium |
| Status | Planned |

## Description

Customer reviews and social proof elements displayed throughout the website. Testimonials build trust and credibility by showcasing real customer experiences and satisfaction.

---

## User Stories

### US-025: View Customer Reviews
**As a** potential customer
**I want to** read reviews from past customers
**So that** I can gauge the quality of service

### US-026: Service-Specific Reviews
**As a** homeowner considering kitchen renovation
**I want to** see reviews from kitchen renovation customers
**So that** I can see relevant experiences

### US-027: Verified Trust
**As a** cautious buyer
**I want to** see star ratings and detailed reviews
**So that** I can trust the reviews are genuine

---

## Requirements

| ID | Requirement | Priority | Status |
|----|-------------|----------|--------|
| F007-R01 | Testimonial carousel on homepage | High | Planned |
| F007-R02 | Dedicated testimonials page | Medium | Planned |
| F007-R03 | Star ratings display | Medium | Planned |
| F007-R04 | Service type tags | Medium | Planned |
| F007-R05 | Customer location display | Low | Planned |
| F007-R06 | Third-party review integration | Low | Planned |
| F007-R07 | Testimonials on service pages | High | Planned |

---

## Acceptance Criteria

### AC-052: Homepage Testimonial Carousel
```gherkin
Feature: Testimonial Carousel
  Scenario: Carousel display on homepage
    Given the user is on the homepage
    When scrolling to the testimonials section
    Then a testimonial carousel should display
    And 3-5 testimonials should be available
    And each testimonial should show:
      | Element | Description |
      | Quote | Customer's testimonial text |
      | Name | Customer first name and last initial |
      | Location | NYC neighborhood or borough |
      | Rating | 5-star rating display |
      | Service | Type of service received |

  Scenario: Carousel navigation
    Given the testimonial carousel is displayed
    When the user clicks navigation arrows
    Then the carousel should transition smoothly
    And dot indicators should update
    And auto-play should pause on hover

  Scenario: Auto-rotation
    Given the carousel is visible
    When no user interaction occurs
    Then testimonials should auto-rotate every 5 seconds
    And transition should be smooth fade or slide
```

### AC-053: Testimonials Page
```gherkin
Feature: Testimonials Page
  Scenario: Page display
    Given the user navigates to /testimonials
    When the page loads
    Then a hero section should display with:
      | Element | Content |
      | Headline | "What Our Customers Say" |
      | Subheadline | "Real Reviews from Real NYC Homeowners" |
    And overall company rating should display
    And all testimonials should be listed

  Scenario: Testimonial grid
    Given testimonials are displayed
    Then they should display in a card grid format
    And each card should include full testimonial content
    And filtering by service type should be available
```

### AC-054: Testimonial Cards
```gherkin
Feature: Testimonial Card Display
  Scenario: Card content
    Given a testimonial card is displayed
    Then it should include:
      | Element | Details |
      | Quote marks | Decorative quote icon |
      | Text | Full testimonial (expandable if long) |
      | Stars | 5 gold stars (or actual rating) |
      | Name | "John S." format |
      | Location | "Brooklyn, NY" |
      | Service | "Kitchen Renovation" badge |
      | Date | "March 2024" (optional) |

  Scenario: Long testimonial
    Given a testimonial exceeds 200 characters
    When initially displayed
    Then text should be truncated with ellipsis
    And a "Read more" link should be available
    When clicking "Read more"
    Then the full testimonial should expand
```

### AC-055: Star Rating Display
```gherkin
Feature: Star Ratings
  Scenario: Five-star display
    Given a testimonial has a 5-star rating
    Then 5 filled gold star icons should display

  Scenario: Partial rating (if applicable)
    Given a testimonial has a 4-star rating
    Then 4 filled stars and 1 empty star should display

  Scenario: Overall rating
    Given the testimonials page is displayed
    Then an aggregate rating should display
    And format should be: "4.9 out of 5 based on 150+ reviews"
```

### AC-056: Service Filtering
```gherkin
Feature: Testimonial Filtering
  Scenario: Filter by service
    Given the testimonials page is displayed
    When the user selects a service filter (e.g., "Kitchen")
    Then only testimonials for that service should display
    And the count should update to reflect filtered results

  Scenario: Service tags
    Given testimonials are displayed
    Then each should have a service type badge
    And clicking the badge should filter to that service
```

### AC-057: Service Page Testimonials
```gherkin
Feature: Context-Specific Testimonials
  Scenario: Service page integration
    Given the user is on a service detail page (e.g., Kitchen)
    When viewing the testimonials section
    Then only testimonials related to that service should display
    And at least 2-3 relevant testimonials should show
    And a link to view all testimonials should be available
```

### AC-058: Third-Party Integration
```gherkin
Feature: External Review Integration
  Scenario: Review platform logos
    Given the testimonials page is displayed
    Then logos for review platforms should display:
      | Platform |
      | Google Reviews |
      | Yelp |
      | BBB |
      | HomeAdvisor |
    And links should open respective profile pages

  Scenario: Aggregate external ratings (optional)
    Given external reviews are integrated
    Then aggregate ratings from platforms should display
    And should indicate source of each rating
```

---

## Testimonial Data Structure

```json
{
  "id": "test-001",
  "quote": "Raj and his team repaired drywall, installed access panels and painted in one of our luxury apartments in Greenwich Village. Raj was communicative, efficient and the quality of work was top notch. Would definitely recommend them.",
  "customer": {
    "name": "Michael T.",
    "location": "Greenwich Village, Manhattan",
    "avatar": null
  },
  "rating": 5,
  "service": "general-contracting",
  "serviceDisplay": "General Contracting",
  "project": {
    "type": "Drywall Repair",
    "date": "2024-02"
  },
  "featured": true,
  "source": "google",
  "verified": true
}
```

---

## Sample Testimonials

### Testimonial 1
> "Zicklin rebuilt our front stoop from scratch in 7 days. The construction team was skilled and professional, worked quickly and removed all the trash. The price was very fair and affordable. The new stoop looks great! Working with Zicklin was a rare all-around good experience!"

**— Sarah M., Park Slope, Brooklyn**
**Service:** Exterior/Masonry | ★★★★★

### Testimonial 2
> "The project was in an 112 year old building and had a number of complications once the walls were opened. Zicklin took care of everything and adapted to the conditions found with suggestions and expertise. I could not be happier with the outcome."

**— David K., Upper West Side, Manhattan**
**Service:** General Contracting | ★★★★★

### Testimonial 3
> "We had water damage in our basement and needed emergency help. They responded within 2 hours and had a team there the same day. Professional, thorough, and worked directly with our insurance company. Highly recommend for any restoration work."

**— Jennifer L., Astoria, Queens**
**Service:** Water Damage Restoration | ★★★★★

---

## UI Specifications

### Carousel Container
- Background: Light gray (#F9FAFB)
- Padding: 80px vertical
- Max-width: 800px for single testimonial view

### Testimonial Card
- Background: White
- Border-radius: 16px
- Padding: 32px
- Shadow: 0 4px 6px rgba(0,0,0,0.05)
- Quote marks: 48px, primary color at 20% opacity

### Quote Text
- Font size: 18px (carousel), 16px (grid)
- Font style: Italic
- Line height: 1.7
- Color: #374151

### Attribution
- Name: 16px, font-weight 600, color #111827
- Location: 14px, color #6B7280
- Service badge: 12px, background primary-light, color primary

### Stars
- Size: 20px
- Filled color: #F59E0B (amber-500)
- Empty color: #E5E7EB (gray-200)
- Spacing: 4px between

### Carousel Navigation
- Arrows: 48px circles, white background, shadow
- Dot indicators: 10px circles, active is primary color
- Transition: 0.5s ease-in-out

### Grid Layout
- Columns: 3 (desktop), 2 (tablet), 1 (mobile)
- Gap: 24px
- Cards equal height with flexbox

---

## Wireframe Reference

See: [../wireframes/homepage.md](../wireframes/homepage.md) (Testimonials section)

---

## Dependencies

- None (standalone feature)

## Related Features

- F002: Homepage (testimonial carousel)
- F003: Services (filtered testimonials)
- F004: About (social proof)
