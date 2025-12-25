# CSS Layout Specifications

## Overview

This document defines the layout system, grid, and container specifications for the Contractors Platform website.

---

## Container System

### Base Container

```css
.container {
  width: 100%;
  max-width: var(--container-xl); /* 1280px */
  margin-left: auto;
  margin-right: auto;
  padding-left: var(--container-padding);
  padding-right: var(--container-padding);
}

/* Container padding responsive adjustments */
.container {
  --container-padding: var(--space-4); /* 16px mobile */
}

@media (min-width: 640px) {
  .container {
    --container-padding: var(--space-6); /* 24px tablet */
  }
}

@media (min-width: 1024px) {
  .container {
    --container-padding: var(--space-8); /* 32px desktop */
  }
}
```

### Container Variants

```css
/* Narrow container for text-heavy content */
.container--narrow {
  max-width: var(--container-md); /* 768px */
}

/* Wide container for full-width sections */
.container--wide {
  max-width: var(--container-2xl); /* 1536px */
}

/* Full-width container */
.container--full {
  max-width: 100%;
}
```

---

## Grid System

### Base Grid

```css
.grid {
  display: grid;
  gap: var(--grid-gap);
}

/* Column configurations */
.grid--cols-1 { grid-template-columns: repeat(1, minmax(0, 1fr)); }
.grid--cols-2 { grid-template-columns: repeat(2, minmax(0, 1fr)); }
.grid--cols-3 { grid-template-columns: repeat(3, minmax(0, 1fr)); }
.grid--cols-4 { grid-template-columns: repeat(4, minmax(0, 1fr)); }
.grid--cols-6 { grid-template-columns: repeat(6, minmax(0, 1fr)); }
.grid--cols-12 { grid-template-columns: repeat(12, minmax(0, 1fr)); }
```

### Responsive Grid

```css
/* Mobile first responsive grid */
.grid--responsive {
  grid-template-columns: 1fr;
}

@media (min-width: 640px) {
  .grid--responsive--sm-2 {
    grid-template-columns: repeat(2, minmax(0, 1fr));
  }
}

@media (min-width: 768px) {
  .grid--responsive--md-2 {
    grid-template-columns: repeat(2, minmax(0, 1fr));
  }
  .grid--responsive--md-3 {
    grid-template-columns: repeat(3, minmax(0, 1fr));
  }
}

@media (min-width: 1024px) {
  .grid--responsive--lg-3 {
    grid-template-columns: repeat(3, minmax(0, 1fr));
  }
  .grid--responsive--lg-4 {
    grid-template-columns: repeat(4, minmax(0, 1fr));
  }
}
```

### Grid Gap Variants

```css
.grid--gap-sm { gap: var(--space-4); }  /* 16px */
.grid--gap-md { gap: var(--space-6); }  /* 24px */
.grid--gap-lg { gap: var(--space-8); }  /* 32px */
.grid--gap-xl { gap: var(--space-12); } /* 48px */
```

---

## Page Layout

### Base Page Structure

```css
.page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.page__header {
  flex-shrink: 0;
}

.page__main {
  flex-grow: 1;
}

.page__footer {
  flex-shrink: 0;
}
```

### Section Layout

```css
.section {
  padding-top: var(--section-padding-y-md);
  padding-bottom: var(--section-padding-y-md);
}

@media (min-width: 768px) {
  .section {
    padding-top: var(--section-padding-y-lg);
    padding-bottom: var(--section-padding-y-lg);
  }
}

/* Section variants */
.section--sm {
  padding-top: var(--section-padding-y-sm);
  padding-bottom: var(--section-padding-y-sm);
}

.section--lg {
  padding-top: var(--section-padding-y-xl);
  padding-bottom: var(--section-padding-y-xl);
}

/* Section backgrounds */
.section--primary {
  background-color: var(--color-primary-800);
  color: white;
}

.section--light {
  background-color: var(--color-gray-50);
}

.section--dark {
  background-color: var(--color-gray-900);
  color: white;
}
```

---

## Flexbox Utilities

### Flex Container

```css
.flex { display: flex; }
.flex-inline { display: inline-flex; }

/* Direction */
.flex-row { flex-direction: row; }
.flex-col { flex-direction: column; }
.flex-row-reverse { flex-direction: row-reverse; }
.flex-col-reverse { flex-direction: column-reverse; }

/* Wrap */
.flex-wrap { flex-wrap: wrap; }
.flex-nowrap { flex-wrap: nowrap; }

/* Justify Content */
.justify-start { justify-content: flex-start; }
.justify-end { justify-content: flex-end; }
.justify-center { justify-content: center; }
.justify-between { justify-content: space-between; }
.justify-around { justify-content: space-around; }
.justify-evenly { justify-content: space-evenly; }

/* Align Items */
.items-start { align-items: flex-start; }
.items-end { align-items: flex-end; }
.items-center { align-items: center; }
.items-baseline { align-items: baseline; }
.items-stretch { align-items: stretch; }

/* Gap */
.gap-1 { gap: var(--space-1); }
.gap-2 { gap: var(--space-2); }
.gap-3 { gap: var(--space-3); }
.gap-4 { gap: var(--space-4); }
.gap-6 { gap: var(--space-6); }
.gap-8 { gap: var(--space-8); }
```

### Flex Items

```css
.flex-1 { flex: 1 1 0%; }
.flex-auto { flex: 1 1 auto; }
.flex-initial { flex: 0 1 auto; }
.flex-none { flex: none; }

.grow { flex-grow: 1; }
.grow-0 { flex-grow: 0; }

.shrink { flex-shrink: 1; }
.shrink-0 { flex-shrink: 0; }
```

---

## Two-Column Layouts

### Content + Sidebar

```css
.layout-sidebar {
  display: grid;
  gap: var(--space-8);
  grid-template-columns: 1fr;
}

@media (min-width: 1024px) {
  .layout-sidebar {
    grid-template-columns: 1fr 380px;
  }
}

.layout-sidebar--reverse {
  @media (min-width: 1024px) {
    grid-template-columns: 380px 1fr;
  }
}
```

### 50/50 Split

```css
.layout-split {
  display: grid;
  gap: var(--space-8);
  grid-template-columns: 1fr;
  align-items: center;
}

@media (min-width: 768px) {
  .layout-split {
    grid-template-columns: 1fr 1fr;
  }
}

.layout-split--40-60 {
  @media (min-width: 768px) {
    grid-template-columns: 2fr 3fr;
  }
}

.layout-split--60-40 {
  @media (min-width: 768px) {
    grid-template-columns: 3fr 2fr;
  }
}
```

---

## Card Grid Layouts

### Services Grid

```css
.services-grid {
  display: grid;
  gap: var(--space-6);
  grid-template-columns: 1fr;
}

@media (min-width: 640px) {
  .services-grid {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (min-width: 1024px) {
  .services-grid {
    grid-template-columns: repeat(3, 1fr);
  }
}
```

### Projects Grid

```css
.projects-grid {
  display: grid;
  gap: var(--space-6);
  grid-template-columns: 1fr;
}

@media (min-width: 640px) {
  .projects-grid {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (min-width: 1024px) {
  .projects-grid {
    grid-template-columns: repeat(3, 1fr);
  }
}

/* Masonry-style variant using CSS columns */
.projects-grid--masonry {
  display: block;
  column-count: 1;
  column-gap: var(--space-6);
}

@media (min-width: 640px) {
  .projects-grid--masonry {
    column-count: 2;
  }
}

@media (min-width: 1024px) {
  .projects-grid--masonry {
    column-count: 3;
  }
}

.projects-grid--masonry > * {
  break-inside: avoid;
  margin-bottom: var(--space-6);
}
```

### Team Grid

```css
.team-grid {
  display: grid;
  gap: var(--space-8);
  grid-template-columns: 1fr;
}

@media (min-width: 640px) {
  .team-grid {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (min-width: 1024px) {
  .team-grid {
    grid-template-columns: repeat(3, 1fr);
  }
}
```

---

## Special Layouts

### Statistics Bar

```css
.stats-bar {
  display: grid;
  gap: var(--space-6);
  grid-template-columns: repeat(2, 1fr);
  text-align: center;
}

@media (min-width: 768px) {
  .stats-bar {
    grid-template-columns: repeat(4, 1fr);
    gap: var(--space-8);
  }
}
```

### Values Grid (5 columns)

```css
.values-grid {
  display: grid;
  gap: var(--space-6);
  grid-template-columns: repeat(2, 1fr);
}

@media (min-width: 768px) {
  .values-grid {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media (min-width: 1024px) {
  .values-grid {
    grid-template-columns: repeat(5, 1fr);
  }
}
```

### Contact Layout

```css
.contact-layout {
  display: grid;
  gap: var(--space-12);
  grid-template-columns: 1fr;
}

@media (min-width: 1024px) {
  .contact-layout {
    grid-template-columns: 1.2fr 1fr;
    align-items: start;
  }
}
```

### Footer Columns

```css
.footer-grid {
  display: grid;
  gap: var(--space-10);
  grid-template-columns: 1fr;
}

@media (min-width: 640px) {
  .footer-grid {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (min-width: 1024px) {
  .footer-grid {
    grid-template-columns: 2fr 1fr 1fr 1.5fr;
  }
}
```

---

## Positioning

### Position Utilities

```css
.relative { position: relative; }
.absolute { position: absolute; }
.fixed { position: fixed; }
.sticky { position: sticky; }

/* Inset utilities */
.inset-0 { top: 0; right: 0; bottom: 0; left: 0; }
.inset-x-0 { left: 0; right: 0; }
.inset-y-0 { top: 0; bottom: 0; }

.top-0 { top: 0; }
.right-0 { right: 0; }
.bottom-0 { bottom: 0; }
.left-0 { left: 0; }
```

### Z-Index

```css
.z-0 { z-index: 0; }
.z-10 { z-index: 10; }
.z-20 { z-index: 20; }
.z-30 { z-index: 30; }
.z-40 { z-index: 40; }
.z-50 { z-index: 50; }
```

---

## Spacing Utilities

### Margin

```css
/* All sides */
.m-0 { margin: 0; }
.m-auto { margin: auto; }
.m-4 { margin: var(--space-4); }
.m-8 { margin: var(--space-8); }

/* Horizontal */
.mx-auto { margin-left: auto; margin-right: auto; }
.mx-4 { margin-left: var(--space-4); margin-right: var(--space-4); }

/* Vertical */
.my-4 { margin-top: var(--space-4); margin-bottom: var(--space-4); }
.my-8 { margin-top: var(--space-8); margin-bottom: var(--space-8); }

/* Individual sides */
.mt-4 { margin-top: var(--space-4); }
.mr-4 { margin-right: var(--space-4); }
.mb-4 { margin-bottom: var(--space-4); }
.ml-4 { margin-left: var(--space-4); }
```

### Padding

```css
/* All sides */
.p-0 { padding: 0; }
.p-4 { padding: var(--space-4); }
.p-8 { padding: var(--space-8); }

/* Horizontal */
.px-4 { padding-left: var(--space-4); padding-right: var(--space-4); }
.px-8 { padding-left: var(--space-8); padding-right: var(--space-8); }

/* Vertical */
.py-4 { padding-top: var(--space-4); padding-bottom: var(--space-4); }
.py-8 { padding-top: var(--space-8); padding-bottom: var(--space-8); }

/* Individual sides */
.pt-4 { padding-top: var(--space-4); }
.pr-4 { padding-right: var(--space-4); }
.pb-4 { padding-bottom: var(--space-4); }
.pl-4 { padding-left: var(--space-4); }
```

---

## Width & Height

```css
/* Width */
.w-full { width: 100%; }
.w-auto { width: auto; }
.w-screen { width: 100vw; }
.max-w-none { max-width: none; }
.max-w-md { max-width: var(--container-md); }
.max-w-lg { max-width: var(--container-lg); }
.max-w-xl { max-width: var(--container-xl); }

/* Height */
.h-full { height: 100%; }
.h-auto { height: auto; }
.h-screen { height: 100vh; }
.min-h-screen { min-height: 100vh; }
```

---

## Related Documents

- [Design System](./design-system.md)
- [Components](./components.md)
- [Responsive](./responsive.md)
