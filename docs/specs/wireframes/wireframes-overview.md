# Wireframes Overview

This folder contains ASCII wireframes for all pages of the Contractors Platform website. These wireframes provide a visual blueprint for the layout and structure of each page.

## Document Index

| Page | File | Description |
|------|------|-------------|
| Homepage | [homepage.md](./homepage.md) | Main landing page with hero, services, testimonials |
| Services | [services.md](./services.md) | Services overview and detail page templates |
| About | [about.md](./about.md) | Company information, team, credentials |
| Projects | [projects.md](./projects.md) | Project gallery with filtering |
| Contact | [contact.md](./contact.md) | Contact form and information |

## Wireframe Legend

```
┌─────────┐  Box/Container
│         │
└─────────┘

═══════════  Section divider

[Button]     Button element

[___________] Input field

( ) Radio button
[x] Checkbox

▼            Dropdown indicator

←  →         Navigation arrows

■ ■ ■        Grid items

● ○ ○        Carousel indicators (active/inactive)

☰            Hamburger menu

✕            Close button

★            Star rating

📞 📧 📍      Icons (phone, email, location)
```

## Responsive Breakpoints

| Breakpoint | Width | Grid Columns |
|------------|-------|--------------|
| Mobile | < 768px | 1 |
| Tablet | 768px - 991px | 2 |
| Desktop | 992px - 1199px | 3-4 |
| Large Desktop | ≥ 1200px | 4 |

## Common Components

### Header (All Pages)
```
┌─────────────────────────────────────────────────────────────────┐
│  [LOGO]     Home  Services▼  About  Projects  Contact   [CTA]  │
│                                                    📞 718-XXX   │
└─────────────────────────────────────────────────────────────────┘
```

### Footer (All Pages)
```
┌─────────────────────────────────────────────────────────────────┐
│  LOGO        Quick Links    Services        Contact Info        │
│  Tagline     • Home         • Kitchen       📞 (718) 550-2779  │
│              • About        • Bathroom      📧 info@company.com │
│  Licensed    • Services     • Basement      📍 99 Wall St, NYC  │
│  & Insured   • Projects     • Restoration                       │
│              • Contact      • Roofing                            │
├─────────────────────────────────────────────────────────────────┤
│        Manhattan • Brooklyn • Queens • Bronx • Staten Island    │
├─────────────────────────────────────────────────────────────────┤
│  © 2024 Company Name           Privacy | Terms    [f] [in] [ig] │
└─────────────────────────────────────────────────────────────────┘
```

## Page Templates

### Standard Page Template
```
┌─────────────────────────────────────────────────────────────────┐
│                           HEADER                                 │
├─────────────────────────────────────────────────────────────────┤
│                                                                  │
│                         HERO SECTION                             │
│                      (Page-specific hero)                        │
│                                                                  │
├─────────────────────────────────────────────────────────────────┤
│                                                                  │
│                       CONTENT SECTIONS                           │
│                     (Varies by page type)                        │
│                                                                  │
├─────────────────────────────────────────────────────────────────┤
│                                                                  │
│                      CALL TO ACTION                              │
│                                                                  │
├─────────────────────────────────────────────────────────────────┤
│                           FOOTER                                 │
└─────────────────────────────────────────────────────────────────┘
```

## Design Principles

1. **Consistency** - Common elements (header, footer, CTAs) maintain consistent placement
2. **Hierarchy** - Visual hierarchy guides users through content
3. **Whitespace** - Adequate spacing improves readability
4. **Mobile-First** - Designs consider mobile constraints first
5. **Accessibility** - Touch targets, contrast, and focus states considered

## Related Documents

- [CSS Specifications](../css/)
- [Feature Requirements](../features/)
- [Architecture](../architecture/)
