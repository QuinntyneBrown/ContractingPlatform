# Design System - CSS Tokens & Variables

## Overview

This document defines the core design tokens and CSS custom properties for the Contractors Platform website. All components and pages should use these values to ensure consistency.

---

## Color Palette

### Primary Colors

```css
:root {
  /* Primary Blue */
  --color-primary-50: #EFF6FF;
  --color-primary-100: #DBEAFE;
  --color-primary-200: #BFDBFE;
  --color-primary-300: #93C5FD;
  --color-primary-400: #60A5FA;
  --color-primary-500: #3B82F6;
  --color-primary-600: #2563EB;
  --color-primary-700: #1D4ED8;
  --color-primary-800: #1E40AF;  /* Primary Brand Color */
  --color-primary-900: #1E3A8A;
  --color-primary-950: #172554;
}
```

### Secondary Colors

```css
:root {
  /* Neutral Gray */
  --color-gray-50: #F9FAFB;
  --color-gray-100: #F3F4F6;
  --color-gray-200: #E5E7EB;
  --color-gray-300: #D1D5DB;
  --color-gray-400: #9CA3AF;
  --color-gray-500: #6B7280;
  --color-gray-600: #4B5563;
  --color-gray-700: #374151;
  --color-gray-800: #1F2937;
  --color-gray-900: #111827;
  --color-gray-950: #030712;
}
```

### Accent & Status Colors

```css
:root {
  /* Success - Green */
  --color-success-50: #F0FDF4;
  --color-success-100: #DCFCE7;
  --color-success-500: #22C55E;
  --color-success-600: #16A34A;
  --color-success-700: #15803D;

  /* Warning - Amber */
  --color-warning-50: #FFFBEB;
  --color-warning-100: #FEF3C7;
  --color-warning-500: #F59E0B;
  --color-warning-600: #D97706;
  --color-warning-700: #B45309;

  /* Error - Red */
  --color-error-50: #FEF2F2;
  --color-error-100: #FEE2E2;
  --color-error-500: #EF4444;
  --color-error-600: #DC2626;
  --color-error-700: #B91C1C;

  /* Info - Blue */
  --color-info-50: #EFF6FF;
  --color-info-100: #DBEAFE;
  --color-info-500: #3B82F6;
  --color-info-600: #2563EB;
}
```

### Semantic Color Assignments

```css
:root {
  /* Background */
  --bg-primary: #FFFFFF;
  --bg-secondary: var(--color-gray-50);
  --bg-tertiary: var(--color-gray-100);
  --bg-inverse: var(--color-gray-900);

  /* Text */
  --text-primary: var(--color-gray-900);
  --text-secondary: var(--color-gray-600);
  --text-tertiary: var(--color-gray-500);
  --text-inverse: #FFFFFF;
  --text-link: var(--color-primary-700);
  --text-link-hover: var(--color-primary-800);

  /* Border */
  --border-default: var(--color-gray-200);
  --border-hover: var(--color-gray-300);
  --border-focus: var(--color-primary-500);
  --border-error: var(--color-error-500);

  /* Accent */
  --accent-primary: var(--color-primary-800);
  --accent-secondary: var(--color-primary-600);
  --accent-star: var(--color-warning-500);
}
```

---

## Typography

### Font Families

```css
:root {
  /* Primary Font Stack - Sans Serif */
  --font-family-sans: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI',
    Roboto, 'Helvetica Neue', Arial, sans-serif;

  /* Heading Font (if different) */
  --font-family-heading: var(--font-family-sans);

  /* Monospace */
  --font-family-mono: 'Fira Code', 'Consolas', 'Monaco', monospace;
}
```

### Font Sizes

```css
:root {
  /* Base size: 16px */
  --font-size-xs: 0.75rem;    /* 12px */
  --font-size-sm: 0.875rem;   /* 14px */
  --font-size-base: 1rem;     /* 16px */
  --font-size-lg: 1.125rem;   /* 18px */
  --font-size-xl: 1.25rem;    /* 20px */
  --font-size-2xl: 1.5rem;    /* 24px */
  --font-size-3xl: 1.875rem;  /* 30px */
  --font-size-4xl: 2.25rem;   /* 36px */
  --font-size-5xl: 3rem;      /* 48px */
  --font-size-6xl: 3.75rem;   /* 60px */
}
```

### Font Weights

```css
:root {
  --font-weight-normal: 400;
  --font-weight-medium: 500;
  --font-weight-semibold: 600;
  --font-weight-bold: 700;
  --font-weight-extrabold: 800;
}
```

### Line Heights

```css
:root {
  --line-height-none: 1;
  --line-height-tight: 1.25;
  --line-height-snug: 1.375;
  --line-height-normal: 1.5;
  --line-height-relaxed: 1.625;
  --line-height-loose: 2;
}
```

### Letter Spacing

```css
:root {
  --tracking-tighter: -0.05em;
  --tracking-tight: -0.025em;
  --tracking-normal: 0;
  --tracking-wide: 0.025em;
  --tracking-wider: 0.05em;
}
```

### Typography Scale

| Element | Size | Weight | Line Height | Color |
|---------|------|--------|-------------|-------|
| h1 | 48px / 3rem | 700 | 1.25 | gray-900 |
| h2 | 36px / 2.25rem | 700 | 1.25 | gray-900 |
| h3 | 24px / 1.5rem | 600 | 1.375 | gray-900 |
| h4 | 20px / 1.25rem | 600 | 1.375 | gray-800 |
| h5 | 18px / 1.125rem | 600 | 1.5 | gray-800 |
| h6 | 16px / 1rem | 600 | 1.5 | gray-700 |
| body | 16px / 1rem | 400 | 1.625 | gray-700 |
| small | 14px / 0.875rem | 400 | 1.5 | gray-600 |
| caption | 12px / 0.75rem | 400 | 1.5 | gray-500 |

---

## Spacing

### Spacing Scale

```css
:root {
  --space-0: 0;
  --space-0-5: 0.125rem;  /* 2px */
  --space-1: 0.25rem;     /* 4px */
  --space-1-5: 0.375rem;  /* 6px */
  --space-2: 0.5rem;      /* 8px */
  --space-2-5: 0.625rem;  /* 10px */
  --space-3: 0.75rem;     /* 12px */
  --space-3-5: 0.875rem;  /* 14px */
  --space-4: 1rem;        /* 16px */
  --space-5: 1.25rem;     /* 20px */
  --space-6: 1.5rem;      /* 24px */
  --space-7: 1.75rem;     /* 28px */
  --space-8: 2rem;        /* 32px */
  --space-9: 2.25rem;     /* 36px */
  --space-10: 2.5rem;     /* 40px */
  --space-11: 2.75rem;    /* 44px */
  --space-12: 3rem;       /* 48px */
  --space-14: 3.5rem;     /* 56px */
  --space-16: 4rem;       /* 64px */
  --space-20: 5rem;       /* 80px */
  --space-24: 6rem;       /* 96px */
  --space-32: 8rem;       /* 128px */
}
```

### Section Spacing

```css
:root {
  /* Vertical section padding */
  --section-padding-y-sm: var(--space-12);   /* 48px */
  --section-padding-y-md: var(--space-16);   /* 64px */
  --section-padding-y-lg: var(--space-20);   /* 80px */
  --section-padding-y-xl: var(--space-24);   /* 96px */
}
```

---

## Layout

### Container Widths

```css
:root {
  --container-sm: 640px;
  --container-md: 768px;
  --container-lg: 1024px;
  --container-xl: 1280px;
  --container-2xl: 1536px;

  /* Default container */
  --container-max-width: 1280px;
  --container-padding: var(--space-4);
}

@media (min-width: 640px) {
  :root {
    --container-padding: var(--space-6);
  }
}

@media (min-width: 1024px) {
  :root {
    --container-padding: var(--space-8);
  }
}
```

### Grid

```css
:root {
  --grid-columns: 12;
  --grid-gap: var(--space-6);  /* 24px */
  --grid-gap-lg: var(--space-8);  /* 32px */
}
```

### Z-Index Scale

```css
:root {
  --z-negative: -1;
  --z-0: 0;
  --z-10: 10;
  --z-20: 20;
  --z-30: 30;
  --z-40: 40;
  --z-50: 50;

  /* Semantic z-index */
  --z-dropdown: 1000;
  --z-sticky: 1020;
  --z-fixed: 1030;
  --z-modal-backdrop: 1040;
  --z-modal: 1050;
  --z-popover: 1060;
  --z-tooltip: 1070;
}
```

---

## Borders & Radius

```css
:root {
  /* Border Width */
  --border-width-0: 0;
  --border-width-1: 1px;
  --border-width-2: 2px;
  --border-width-4: 4px;
  --border-width-8: 8px;

  /* Border Radius */
  --radius-none: 0;
  --radius-sm: 0.125rem;   /* 2px */
  --radius-default: 0.25rem; /* 4px */
  --radius-md: 0.375rem;   /* 6px */
  --radius-lg: 0.5rem;     /* 8px */
  --radius-xl: 0.75rem;    /* 12px */
  --radius-2xl: 1rem;      /* 16px */
  --radius-3xl: 1.5rem;    /* 24px */
  --radius-full: 9999px;
}
```

---

## Shadows

```css
:root {
  --shadow-sm: 0 1px 2px 0 rgb(0 0 0 / 0.05);
  --shadow-default: 0 1px 3px 0 rgb(0 0 0 / 0.1), 0 1px 2px -1px rgb(0 0 0 / 0.1);
  --shadow-md: 0 4px 6px -1px rgb(0 0 0 / 0.1), 0 2px 4px -2px rgb(0 0 0 / 0.1);
  --shadow-lg: 0 10px 15px -3px rgb(0 0 0 / 0.1), 0 4px 6px -4px rgb(0 0 0 / 0.1);
  --shadow-xl: 0 20px 25px -5px rgb(0 0 0 / 0.1), 0 8px 10px -6px rgb(0 0 0 / 0.1);
  --shadow-2xl: 0 25px 50px -12px rgb(0 0 0 / 0.25);
  --shadow-inner: inset 0 2px 4px 0 rgb(0 0 0 / 0.05);
  --shadow-none: 0 0 #0000;
}
```

---

## Transitions & Animation

```css
:root {
  /* Duration */
  --duration-75: 75ms;
  --duration-100: 100ms;
  --duration-150: 150ms;
  --duration-200: 200ms;
  --duration-300: 300ms;
  --duration-500: 500ms;
  --duration-700: 700ms;
  --duration-1000: 1000ms;

  /* Easing */
  --ease-linear: linear;
  --ease-in: cubic-bezier(0.4, 0, 1, 1);
  --ease-out: cubic-bezier(0, 0, 0.2, 1);
  --ease-in-out: cubic-bezier(0.4, 0, 0.2, 1);

  /* Default transition */
  --transition-default: all var(--duration-200) var(--ease-in-out);
  --transition-colors: color var(--duration-150) var(--ease-in-out),
                       background-color var(--duration-150) var(--ease-in-out),
                       border-color var(--duration-150) var(--ease-in-out);
  --transition-transform: transform var(--duration-200) var(--ease-in-out);
  --transition-shadow: box-shadow var(--duration-200) var(--ease-in-out);
}
```

---

## Breakpoints

```css
/* Mobile First Breakpoints */
:root {
  --breakpoint-sm: 640px;
  --breakpoint-md: 768px;
  --breakpoint-lg: 1024px;
  --breakpoint-xl: 1280px;
  --breakpoint-2xl: 1536px;
}

/* Media Query Usage */
@media (min-width: 640px) { /* sm */ }
@media (min-width: 768px) { /* md */ }
@media (min-width: 1024px) { /* lg */ }
@media (min-width: 1280px) { /* xl */ }
@media (min-width: 1536px) { /* 2xl */ }
```

---

## Accessibility

```css
:root {
  /* Focus Ring */
  --focus-ring-color: var(--color-primary-500);
  --focus-ring-width: 2px;
  --focus-ring-offset: 2px;
  --focus-ring: 0 0 0 var(--focus-ring-offset) var(--bg-primary),
                0 0 0 calc(var(--focus-ring-offset) + var(--focus-ring-width)) var(--focus-ring-color);

  /* Minimum touch target size */
  --touch-target-min: 44px;
}

/* Focus visible for keyboard navigation */
:focus-visible {
  outline: none;
  box-shadow: var(--focus-ring);
}

/* Reduced motion preference */
@media (prefers-reduced-motion: reduce) {
  *,
  *::before,
  *::after {
    animation-duration: 0.01ms !important;
    animation-iteration-count: 1 !important;
    transition-duration: 0.01ms !important;
  }
}
```

---

## Usage Example

```css
/* Example component using design tokens */
.button-primary {
  background-color: var(--accent-primary);
  color: var(--text-inverse);
  font-family: var(--font-family-sans);
  font-size: var(--font-size-base);
  font-weight: var(--font-weight-semibold);
  padding: var(--space-3) var(--space-6);
  border-radius: var(--radius-lg);
  box-shadow: var(--shadow-sm);
  transition: var(--transition-colors), var(--transition-shadow);
}

.button-primary:hover {
  background-color: var(--color-primary-900);
  box-shadow: var(--shadow-md);
}

.button-primary:focus-visible {
  box-shadow: var(--focus-ring);
}
```

---

## Related Documents

- [Components](./components.md)
- [Layout](./layout.md)
- [Responsive](./responsive.md)
