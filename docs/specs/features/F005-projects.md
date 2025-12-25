# F005 - Projects/Portfolio Feature

## Feature Overview

| Field | Value |
|-------|-------|
| Feature ID | F005 |
| Feature Name | Projects/Portfolio |
| Priority | High |
| Status | Planned |

## Description

Showcase of completed projects to demonstrate capabilities and build trust. Features filterable galleries, before/after comparisons, and detailed project information to help potential customers visualize the quality of work.

---

## User Stories

### US-017: Browse Projects
**As a** potential customer
**I want to** see examples of completed projects
**So that** I can evaluate the quality of work

### US-018: Filter by Type
**As a** homeowner looking for kitchen renovation
**I want to** filter projects by type
**So that** I can see relevant examples

### US-019: Before/After Comparison
**As a** visual learner
**I want to** see before and after images
**So that** I can understand the transformation possible

### US-020: Project Details
**As a** detail-oriented buyer
**I want to** read about specific project details
**So that** I can understand the scope and quality

---

## Requirements

| ID | Requirement | Priority | Status |
|----|-------------|----------|--------|
| F005-R01 | Project gallery with grid layout | High | Planned |
| F005-R02 | Category filtering | High | Planned |
| F005-R03 | Individual project detail pages | Medium | Planned |
| F005-R04 | Before/after comparison sliders | High | Planned |
| F005-R05 | Project location tags | Low | Planned |
| F005-R06 | Load more/pagination | Medium | Planned |
| F005-R07 | Lightbox image viewing | High | Planned |

---

## Project Categories

| Category | Description | Examples |
|----------|-------------|----------|
| Residential | Home renovations | Apartments, townhouses, single-family |
| Commercial | Business spaces | Offices, retail, restaurants |
| Kitchen | Kitchen-specific | Full remodels, cabinet refacing |
| Bathroom | Bathroom-specific | Full remodels, accessibility |
| Basement | Below-grade work | Finishing, legalization, waterproofing |
| Restoration | Damage repair | Water, fire, mold remediation |
| Exterior | Outside work | Roofing, facades, sidewalks |

---

## Acceptance Criteria

### AC-034: Projects Overview Page
```gherkin
Feature: Projects Gallery
  Scenario: Gallery page display
    Given the user navigates to /projects
    When the page loads
    Then a hero section should display with:
      | Element | Content |
      | Headline | "Our Projects" |
      | Subheadline | "See Our Work Across NYC" |
    And filter buttons should display for each category
    And a grid of project thumbnails should display
    And projects should show most recent first by default
```

### AC-035: Project Filtering
```gherkin
Feature: Project Category Filter
  Scenario: Filter by category
    Given the projects gallery is displayed
    When the user clicks a category filter button
    Then only projects in that category should display
    And the filter button should show as active
    And the project count should update
    And the transition should be smooth (fade/scale)

  Scenario: Clear filters
    Given a filter is applied
    When the user clicks "All" or the active filter again
    Then all projects should display
    And the filter should show as inactive

  Scenario: Multiple filters (optional)
    Given filters support multiple selection
    When the user selects multiple categories
    Then projects matching any selected category should display
```

### AC-036: Project Thumbnail Cards
```gherkin
Feature: Project Thumbnails
  Scenario: Thumbnail display
    Given the projects grid is visible
    Then each project card should include:
      | Element | Description |
      | Image | High-quality project photo |
      | Title | Project name or address |
      | Category | Category badge (e.g., "Kitchen") |
      | Location | NYC borough |
    And hovering should show overlay with "View Project"
    And cards should be equal height in grid

  Scenario: Thumbnail interaction
    Given a project thumbnail is displayed
    When the user clicks the card
    Then they should navigate to the project detail page
    Or open a lightbox gallery
```

### AC-037: Project Detail Page
```gherkin
Feature: Project Detail
  Scenario: Detail page content
    Given the user navigates to a project detail page
    When the page loads
    Then the following should display:
      | Section | Content |
      | Hero | Main project image, title, location |
      | Gallery | All project images in grid |
      | Description | Project narrative |
      | Scope | Work completed list |
      | Before/After | Comparison slider (if available) |
      | Details | Duration, size, category, borough |
      | Related | Similar projects |

  Scenario: Image gallery
    Given project images are displayed
    When the user clicks an image
    Then a lightbox should open
    And navigation arrows should allow browsing
    And image counter should show position (e.g., "3 of 12")
```

### AC-038: Before/After Slider
```gherkin
Feature: Before/After Comparison
  Scenario: Slider functionality
    Given a before/after comparison is displayed
    When the user drags the slider handle
    Then the before image should reveal from left
    And the after image should reveal from right
    And the transition should be smooth

  Scenario: Mobile touch support
    Given the user is on a mobile device
    When touching and dragging the slider
    Then the comparison should work with touch gestures
    And the experience should be smooth

  Scenario: Labels
    Given the slider is displayed
    Then "Before" and "After" labels should be visible
    And labels should move with the slider handle
```

### AC-039: Lightbox Gallery
```gherkin
Feature: Lightbox
  Scenario: Lightbox opening
    Given the project gallery is displayed
    When the user clicks an image
    Then a fullscreen lightbox should open
    And the clicked image should display large
    And a dark overlay should cover the page

  Scenario: Lightbox navigation
    Given the lightbox is open
    When the user clicks left/right arrows
    Then the previous/next image should display
    And keyboard arrow keys should also work
    And swipe gestures should work on mobile

  Scenario: Lightbox closing
    Given the lightbox is open
    When the user clicks the X button or presses Escape
    Then the lightbox should close
    And clicking outside the image should also close it
```

### AC-040: Related Projects
```gherkin
Feature: Related Projects
  Scenario: Related projects display
    Given the user is on a project detail page
    When scrolling to the related projects section
    Then 3-4 related project cards should display
    And projects should be from the same category
    Or from the same borough
    And each card should link to its detail page
```

### AC-041: Load More/Pagination
```gherkin
Feature: Project Pagination
  Scenario: Initial load
    Given the user is on the projects page
    When the page loads
    Then 12 projects should display initially

  Scenario: Load more
    Given 12 projects are displayed
    When the user clicks "Load More"
    Then 12 additional projects should append
    And the button should show loading state
    And "Load More" should hide when all projects loaded

  Alternative: Infinite scroll
    Given the user scrolls to the bottom
    When near the last row of projects
    Then additional projects should auto-load
```

---

## Project Data Structure

```json
{
  "id": "proj-001",
  "title": "Modern Kitchen Renovation",
  "slug": "modern-kitchen-upper-east-side",
  "category": "kitchen",
  "subcategory": "full-remodel",
  "location": {
    "borough": "Manhattan",
    "neighborhood": "Upper East Side"
  },
  "description": "Complete kitchen transformation...",
  "scope": [
    "Custom cabinetry installation",
    "Quartz countertop installation",
    "Plumbing relocation",
    "Electrical upgrades",
    "Tile backsplash"
  ],
  "details": {
    "duration": "6 weeks",
    "squareFeet": 150,
    "completedDate": "2024-03"
  },
  "images": {
    "thumbnail": "/images/projects/proj-001/thumb.jpg",
    "hero": "/images/projects/proj-001/hero.jpg",
    "gallery": [
      "/images/projects/proj-001/img-1.jpg",
      "/images/projects/proj-001/img-2.jpg"
    ],
    "beforeAfter": {
      "before": "/images/projects/proj-001/before.jpg",
      "after": "/images/projects/proj-001/after.jpg"
    }
  },
  "featured": true,
  "order": 1
}
```

---

## UI Specifications

### Gallery Page
- Hero height: 40vh
- Grid: 3 columns (desktop), 2 (tablet), 1 (mobile)
- Card aspect ratio: 4:3
- Gap between cards: 24px

### Filter Bar
- Position: Sticky below header (optional)
- Background: White
- Button style: Pill-shaped, outline default
- Active button: Filled with primary color
- Spacing: 12px between buttons

### Project Cards
- Border radius: 12px
- Overflow: Hidden (for image)
- Shadow: 0 4px 6px rgba(0,0,0,0.1)
- Hover: Scale 1.02, shadow increase
- Overlay on hover: rgba(0,0,0,0.5) with centered text

### Before/After Slider
- Handle: 40px circle, white, drop shadow
- Handle icon: Left/right arrows
- Border between images: 4px white
- Responsive: Full width of container

### Lightbox
- Background: rgba(0,0,0,0.9)
- Image max-height: 90vh
- Navigation arrows: 48px, white
- Close button: 32px, top-right
- Counter: Bottom center, white text

---

## Wireframe Reference

See: [../wireframes/projects.md](../wireframes/projects.md)

---

## Performance Considerations

- Image lazy loading for gallery
- Thumbnail images: Max 600px width, WebP format
- Full images: Max 1920px, progressive JPEG or WebP
- Skeleton loading states
- Smooth scroll for anchor links

---

## SEO Considerations

- Meta Title: "Projects | NYC Renovation Portfolio | [Company Name]"
- Individual project pages with unique URLs
- Alt text for all images
- Structured data: ImageGallery schema

---

## Dependencies

- F001: Navigation
- F008: Footer

## Related Features

- F002: Homepage (featured projects carousel)
- F003: Services (service galleries link here)
