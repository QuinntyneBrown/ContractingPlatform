# CSS Responsive Design Specifications

## Overview

This document defines the responsive design approach, breakpoints, and mobile-specific considerations for the Contractors Platform website.

---

## Breakpoint Strategy

### Mobile-First Approach

All base styles are written for mobile devices first. Larger screen styles are added using `min-width` media queries.

```css
/* Base styles: Mobile (0-639px) */
.element {
  font-size: 14px;
  padding: 16px;
}

/* Small screens and up (640px+) */
@media (min-width: 640px) {
  .element {
    font-size: 15px;
    padding: 20px;
  }
}

/* Medium screens and up (768px+) */
@media (min-width: 768px) {
  .element {
    font-size: 16px;
    padding: 24px;
  }
}

/* Large screens and up (1024px+) */
@media (min-width: 1024px) {
  .element {
    font-size: 18px;
    padding: 32px;
  }
}
```

### Breakpoint Reference

| Breakpoint | Prefix | Min Width | Typical Devices |
|------------|--------|-----------|-----------------|
| Default | - | 0px | Mobile phones (portrait) |
| sm | sm: | 640px | Mobile phones (landscape), small tablets |
| md | md: | 768px | Tablets (portrait) |
| lg | lg: | 1024px | Tablets (landscape), small laptops |
| xl | xl: | 1280px | Laptops, desktops |
| 2xl | 2xl: | 1536px | Large desktops, wide monitors |

---

## Component Responsive Behavior

### Header

```css
/* Mobile Header */
.header {
  height: 60px;
}

.header__nav {
  display: none; /* Hidden on mobile */
}

.header__menu-btn {
  display: flex; /* Hamburger visible on mobile */
}

.header__cta {
  display: none; /* CTA hidden on mobile */
}

.header__phone {
  font-size: var(--font-size-sm);
}

/* Tablet and up */
@media (min-width: 768px) {
  .header {
    height: 70px;
  }

  .header__phone {
    font-size: var(--font-size-base);
  }
}

/* Desktop */
@media (min-width: 1024px) {
  .header {
    height: 80px;
  }

  .header__nav {
    display: flex; /* Navigation visible */
  }

  .header__menu-btn {
    display: none; /* Hamburger hidden */
  }

  .header__cta {
    display: inline-flex; /* CTA visible */
  }
}
```

### Hero Section

```css
/* Mobile Hero */
.hero {
  min-height: 60vh;
  padding: var(--space-16) var(--space-4);
}

.hero__title {
  font-size: var(--font-size-3xl); /* 30px */
}

.hero__subtitle {
  font-size: var(--font-size-base); /* 16px */
}

.hero__actions {
  flex-direction: column;
  gap: var(--space-3);
}

.hero__actions .btn {
  width: 100%;
}

/* Tablet */
@media (min-width: 768px) {
  .hero {
    min-height: 70vh;
  }

  .hero__title {
    font-size: var(--font-size-4xl); /* 36px */
  }

  .hero__subtitle {
    font-size: var(--font-size-lg); /* 18px */
  }

  .hero__actions {
    flex-direction: row;
    justify-content: center;
  }

  .hero__actions .btn {
    width: auto;
  }
}

/* Desktop */
@media (min-width: 1024px) {
  .hero {
    min-height: 80vh;
  }

  .hero__title {
    font-size: var(--font-size-5xl); /* 48px */
  }

  .hero__subtitle {
    font-size: var(--font-size-xl); /* 20px */
  }
}
```

### Services Grid

```css
/* Mobile: Single column */
.services-grid {
  display: grid;
  grid-template-columns: 1fr;
  gap: var(--space-4);
}

/* Small tablet: 2 columns */
@media (min-width: 640px) {
  .services-grid {
    grid-template-columns: repeat(2, 1fr);
    gap: var(--space-5);
  }
}

/* Desktop: 3 columns */
@media (min-width: 1024px) {
  .services-grid {
    grid-template-columns: repeat(3, 1fr);
    gap: var(--space-6);
  }
}
```

### Statistics Section

```css
/* Mobile: 2x2 grid */
.stats-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: var(--space-6);
}

.stats__number {
  font-size: var(--font-size-3xl);
}

.stats__label {
  font-size: var(--font-size-xs);
}

/* Desktop: 4 columns */
@media (min-width: 768px) {
  .stats-grid {
    grid-template-columns: repeat(4, 1fr);
  }

  .stats__number {
    font-size: var(--font-size-5xl);
  }

  .stats__label {
    font-size: var(--font-size-sm);
  }
}
```

### Testimonial Carousel

```css
/* Mobile: Single testimonial, smaller text */
.testimonial__text {
  font-size: var(--font-size-base);
}

.testimonial__quote-mark {
  font-size: 48px;
}

/* Desktop: Larger text, more elaborate */
@media (min-width: 768px) {
  .testimonial__text {
    font-size: var(--font-size-lg);
  }

  .testimonial__quote-mark {
    font-size: 72px;
  }
}
```

### Contact Form Layout

```css
/* Mobile: Stacked layout, form first priority */
.contact-layout {
  display: flex;
  flex-direction: column;
  gap: var(--space-8);
}

/* Contact info shown BEFORE form on mobile for quick access */
.contact-info {
  order: -1;
}

/* Desktop: Side by side */
@media (min-width: 1024px) {
  .contact-layout {
    display: grid;
    grid-template-columns: 3fr 2fr;
    gap: var(--space-12);
    align-items: start;
  }

  .contact-info {
    order: 0;
    position: sticky;
    top: 100px;
  }
}
```

### Footer

```css
/* Mobile: Stacked columns */
.footer-grid {
  display: grid;
  grid-template-columns: 1fr;
  gap: var(--space-8);
  text-align: center;
}

.footer__social {
  justify-content: center;
}

/* Tablet: 2x2 grid */
@media (min-width: 640px) {
  .footer-grid {
    grid-template-columns: repeat(2, 1fr);
    text-align: left;
  }

  .footer__social {
    justify-content: flex-start;
  }
}

/* Desktop: 4 columns */
@media (min-width: 1024px) {
  .footer-grid {
    grid-template-columns: 2fr 1fr 1fr 1.5fr;
  }
}
```

---

## Typography Responsive Scaling

### Heading Scale

```css
h1, .h1 {
  font-size: var(--font-size-3xl);  /* 30px mobile */
}

h2, .h2 {
  font-size: var(--font-size-2xl);  /* 24px mobile */
}

h3, .h3 {
  font-size: var(--font-size-xl);   /* 20px mobile */
}

@media (min-width: 768px) {
  h1, .h1 {
    font-size: var(--font-size-4xl);  /* 36px tablet */
  }

  h2, .h2 {
    font-size: var(--font-size-3xl);  /* 30px tablet */
  }

  h3, .h3 {
    font-size: var(--font-size-2xl);  /* 24px tablet */
  }
}

@media (min-width: 1024px) {
  h1, .h1 {
    font-size: var(--font-size-5xl);  /* 48px desktop */
  }

  h2, .h2 {
    font-size: var(--font-size-4xl);  /* 36px desktop */
  }

  h3, .h3 {
    font-size: var(--font-size-2xl);  /* 24px desktop */
  }
}
```

### Body Text

```css
body {
  font-size: var(--font-size-base);  /* 16px - consistent across devices */
  line-height: var(--line-height-relaxed);
}

/* Larger text on desktop for better readability */
@media (min-width: 1024px) {
  .lead-text {
    font-size: var(--font-size-lg);
  }
}
```

---

## Spacing Responsive Adjustments

### Section Padding

```css
.section {
  padding-top: var(--space-12);    /* 48px mobile */
  padding-bottom: var(--space-12);
}

@media (min-width: 768px) {
  .section {
    padding-top: var(--space-16);   /* 64px tablet */
    padding-bottom: var(--space-16);
  }
}

@media (min-width: 1024px) {
  .section {
    padding-top: var(--space-20);   /* 80px desktop */
    padding-bottom: var(--space-20);
  }
}
```

### Component Gaps

```css
.card-grid {
  gap: var(--space-4);  /* 16px mobile */
}

@media (min-width: 640px) {
  .card-grid {
    gap: var(--space-5);  /* 20px small tablet */
  }
}

@media (min-width: 1024px) {
  .card-grid {
    gap: var(--space-6);  /* 24px desktop */
  }
}
```

---

## Touch & Interaction Considerations

### Touch Targets

```css
/* Minimum 44x44px touch targets for mobile */
.btn,
.nav-link,
.form-input,
.form-select,
button,
a {
  min-height: 44px;
  min-width: 44px;
}

/* Links in text can be smaller but need adequate padding */
p a,
.text-link {
  min-height: auto;
  min-width: auto;
  padding: var(--space-1) var(--space-0-5);
  margin: calc(var(--space-1) * -1) calc(var(--space-0-5) * -1);
}
```

### Hover States (Desktop Only)

```css
/* Only apply hover effects on devices that support hover */
@media (hover: hover) and (pointer: fine) {
  .card:hover {
    transform: translateY(-4px);
    box-shadow: var(--shadow-lg);
  }

  .btn:hover {
    background-color: var(--color-primary-900);
  }

  .nav-link:hover {
    color: var(--color-primary-700);
  }
}
```

### Mobile-Specific Interactions

```css
/* Tap highlight color */
* {
  -webkit-tap-highlight-color: rgba(30, 64, 175, 0.1);
}

/* Prevent zoom on input focus (iOS) */
input,
select,
textarea {
  font-size: 16px; /* Prevents zoom on iOS */
}

/* Touch-friendly scrolling */
.scroll-container {
  -webkit-overflow-scrolling: touch;
  scroll-behavior: smooth;
}
```

---

## Image Responsive Handling

### Responsive Images

```css
img {
  max-width: 100%;
  height: auto;
}

/* Art direction for hero images */
.hero__image {
  object-fit: cover;
  object-position: center;
}

@media (max-width: 767px) {
  .hero__image {
    object-position: center right; /* Focus on subject on mobile */
  }
}
```

### Picture Element Usage

```html
<picture>
  <source media="(min-width: 1024px)" srcset="hero-desktop.webp">
  <source media="(min-width: 640px)" srcset="hero-tablet.webp">
  <img src="hero-mobile.webp" alt="Hero image">
</picture>
```

---

## Visibility Utilities

### Hide/Show at Breakpoints

```css
/* Hide on mobile, show on larger screens */
.hide-mobile {
  display: none;
}

@media (min-width: 768px) {
  .hide-mobile {
    display: block;
  }
}

/* Show on mobile only */
.show-mobile {
  display: block;
}

@media (min-width: 768px) {
  .show-mobile {
    display: none;
  }
}

/* Hide on desktop */
@media (min-width: 1024px) {
  .hide-desktop {
    display: none;
  }
}
```

### Screen Reader Only

```css
.sr-only {
  position: absolute;
  width: 1px;
  height: 1px;
  padding: 0;
  margin: -1px;
  overflow: hidden;
  clip: rect(0, 0, 0, 0);
  white-space: nowrap;
  border: 0;
}
```

---

## Performance Considerations

### Critical CSS

Inline critical above-the-fold CSS for:
- Header/navigation
- Hero section
- First visible content section

### Deferred Loading

```css
/* Lazy load non-critical styles */
@media print {
  /* Print styles deferred */
}

/* Animation only when visible */
@media (prefers-reduced-motion: no-preference) {
  .animate-on-scroll {
    opacity: 0;
    transform: translateY(20px);
    transition: opacity 0.6s ease, transform 0.6s ease;
  }

  .animate-on-scroll.visible {
    opacity: 1;
    transform: translateY(0);
  }
}
```

### Reduced Motion

```css
@media (prefers-reduced-motion: reduce) {
  *,
  *::before,
  *::after {
    animation-duration: 0.01ms !important;
    animation-iteration-count: 1 !important;
    transition-duration: 0.01ms !important;
    scroll-behavior: auto !important;
  }
}
```

---

## Testing Checklist

### Mobile Testing (320px - 767px)

- [ ] All touch targets are at least 44x44px
- [ ] Text is readable without zooming (minimum 16px)
- [ ] No horizontal scrolling
- [ ] Forms are usable with touch keyboard
- [ ] Navigation hamburger menu works
- [ ] Images scale properly
- [ ] Buttons are full width
- [ ] Phone numbers are clickable (tel:)

### Tablet Testing (768px - 1023px)

- [ ] Layouts adapt to 2-column grids where appropriate
- [ ] Images don't stretch or distort
- [ ] Navigation transitions smoothly
- [ ] Touch and hover states both work

### Desktop Testing (1024px+)

- [ ] Full navigation is visible
- [ ] Hover states are active
- [ ] Layouts use full 3-4 column grids
- [ ] Content doesn't feel cramped or stretched
- [ ] Sticky elements work correctly

---

## Related Documents

- [Design System](./design-system.md)
- [Components](./components.md)
- [Layout](./layout.md)
