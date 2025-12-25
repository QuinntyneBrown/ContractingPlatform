# CSS Component Specifications

## Overview

This document defines CSS specifications for all reusable UI components in the Contractors Platform website. Each component includes its styles, variants, and states.

---

## Buttons

### Primary Button

```css
.btn-primary {
  /* Layout */
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: var(--space-2);
  min-height: var(--touch-target-min);
  padding: var(--space-3) var(--space-6);

  /* Typography */
  font-family: var(--font-family-sans);
  font-size: var(--font-size-base);
  font-weight: var(--font-weight-semibold);
  line-height: var(--line-height-normal);
  text-decoration: none;

  /* Appearance */
  background-color: var(--color-primary-800);
  color: white;
  border: none;
  border-radius: var(--radius-lg);
  box-shadow: var(--shadow-sm);
  cursor: pointer;

  /* Transition */
  transition: var(--transition-colors), var(--transition-shadow),
              var(--transition-transform);
}

.btn-primary:hover {
  background-color: var(--color-primary-900);
  box-shadow: var(--shadow-md);
}

.btn-primary:active {
  transform: translateY(1px);
}

.btn-primary:focus-visible {
  outline: none;
  box-shadow: var(--focus-ring);
}

.btn-primary:disabled {
  background-color: var(--color-gray-400);
  cursor: not-allowed;
  box-shadow: none;
}
```

### Secondary Button

```css
.btn-secondary {
  /* Inherits from btn-primary layout */
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: var(--space-2);
  min-height: var(--touch-target-min);
  padding: var(--space-3) var(--space-6);

  /* Typography */
  font-family: var(--font-family-sans);
  font-size: var(--font-size-base);
  font-weight: var(--font-weight-semibold);

  /* Appearance */
  background-color: transparent;
  color: var(--color-primary-800);
  border: 2px solid var(--color-primary-800);
  border-radius: var(--radius-lg);
  cursor: pointer;
  transition: var(--transition-colors);
}

.btn-secondary:hover {
  background-color: var(--color-primary-50);
}

.btn-secondary:focus-visible {
  outline: none;
  box-shadow: var(--focus-ring);
}
```

### Button Sizes

```css
/* Small */
.btn-sm {
  min-height: 36px;
  padding: var(--space-2) var(--space-4);
  font-size: var(--font-size-sm);
}

/* Medium (default) */
.btn-md {
  min-height: 44px;
  padding: var(--space-3) var(--space-6);
  font-size: var(--font-size-base);
}

/* Large */
.btn-lg {
  min-height: 56px;
  padding: var(--space-4) var(--space-8);
  font-size: var(--font-size-lg);
}

/* Full Width */
.btn-full {
  width: 100%;
}
```

---

## Cards

### Service Card

```css
.card-service {
  /* Layout */
  display: flex;
  flex-direction: column;
  padding: var(--space-8);
  height: 100%;

  /* Appearance */
  background-color: white;
  border-radius: var(--radius-xl);
  box-shadow: var(--shadow-md);

  /* Transition */
  transition: var(--transition-transform), var(--transition-shadow);
}

.card-service:hover {
  transform: translateY(-4px);
  box-shadow: var(--shadow-lg);
}

.card-service__icon {
  width: 48px;
  height: 48px;
  margin-bottom: var(--space-4);
  color: var(--color-primary-600);
}

.card-service__title {
  font-size: var(--font-size-xl);
  font-weight: var(--font-weight-semibold);
  color: var(--color-gray-900);
  margin-bottom: var(--space-2);
}

.card-service__description {
  font-size: var(--font-size-sm);
  color: var(--color-gray-600);
  line-height: var(--line-height-relaxed);
  flex-grow: 1;
  margin-bottom: var(--space-4);
}

.card-service__link {
  display: inline-flex;
  align-items: center;
  gap: var(--space-2);
  font-size: var(--font-size-sm);
  font-weight: var(--font-weight-medium);
  color: var(--color-primary-700);
  text-decoration: none;
  transition: var(--transition-colors);
}

.card-service__link:hover {
  color: var(--color-primary-800);
}

.card-service__link::after {
  content: "→";
  transition: transform var(--duration-200) var(--ease-out);
}

.card-service__link:hover::after {
  transform: translateX(4px);
}
```

### Project Card

```css
.card-project {
  position: relative;
  overflow: hidden;
  border-radius: var(--radius-xl);
  box-shadow: var(--shadow-md);
  cursor: pointer;
  transition: var(--transition-transform), var(--transition-shadow);
}

.card-project:hover {
  transform: scale(1.02);
  box-shadow: var(--shadow-xl);
}

.card-project__image {
  aspect-ratio: 4 / 3;
  width: 100%;
  object-fit: cover;
  transition: transform var(--duration-300) var(--ease-out);
}

.card-project:hover .card-project__image {
  transform: scale(1.05);
}

.card-project__overlay {
  position: absolute;
  inset: 0;
  background: linear-gradient(
    to top,
    rgba(0, 0, 0, 0.8) 0%,
    rgba(0, 0, 0, 0.4) 50%,
    transparent 100%
  );
  opacity: 0;
  transition: opacity var(--duration-300) var(--ease-out);
  display: flex;
  align-items: center;
  justify-content: center;
}

.card-project:hover .card-project__overlay {
  opacity: 1;
}

.card-project__content {
  padding: var(--space-4);
  background: white;
}

.card-project__title {
  font-size: var(--font-size-lg);
  font-weight: var(--font-weight-semibold);
  color: var(--color-gray-900);
  margin-bottom: var(--space-1);
}

.card-project__meta {
  display: flex;
  align-items: center;
  gap: var(--space-2);
  font-size: var(--font-size-sm);
  color: var(--color-gray-500);
}

.card-project__badge {
  display: inline-flex;
  padding: var(--space-1) var(--space-2);
  font-size: var(--font-size-xs);
  font-weight: var(--font-weight-medium);
  background-color: var(--color-primary-100);
  color: var(--color-primary-800);
  border-radius: var(--radius-full);
}
```

### Testimonial Card

```css
.card-testimonial {
  background-color: white;
  border-radius: var(--radius-2xl);
  padding: var(--space-8);
  box-shadow: var(--shadow-md);
  position: relative;
}

.card-testimonial__quote-mark {
  position: absolute;
  top: var(--space-4);
  left: var(--space-6);
  font-size: 72px;
  color: var(--color-primary-200);
  font-family: Georgia, serif;
  line-height: 1;
}

.card-testimonial__text {
  font-size: var(--font-size-lg);
  font-style: italic;
  color: var(--color-gray-700);
  line-height: var(--line-height-relaxed);
  margin-bottom: var(--space-6);
  position: relative;
  z-index: 1;
}

.card-testimonial__rating {
  display: flex;
  gap: var(--space-1);
  margin-bottom: var(--space-4);
}

.card-testimonial__star {
  width: 20px;
  height: 20px;
  color: var(--color-warning-500);
}

.card-testimonial__author {
  font-weight: var(--font-weight-semibold);
  color: var(--color-gray-900);
}

.card-testimonial__location {
  font-size: var(--font-size-sm);
  color: var(--color-gray-500);
}

.card-testimonial__service {
  display: inline-flex;
  margin-top: var(--space-2);
  padding: var(--space-1) var(--space-3);
  font-size: var(--font-size-xs);
  background-color: var(--color-gray-100);
  color: var(--color-gray-600);
  border-radius: var(--radius-full);
}
```

---

## Form Elements

### Input Field

```css
.form-input {
  /* Layout */
  width: 100%;
  height: 48px;
  padding: var(--space-3) var(--space-4);

  /* Typography */
  font-family: var(--font-family-sans);
  font-size: var(--font-size-base);
  color: var(--color-gray-900);

  /* Appearance */
  background-color: white;
  border: 1px solid var(--color-gray-300);
  border-radius: var(--radius-lg);

  /* Transition */
  transition: var(--transition-colors);
}

.form-input::placeholder {
  color: var(--color-gray-400);
}

.form-input:hover {
  border-color: var(--color-gray-400);
}

.form-input:focus {
  outline: none;
  border-color: var(--color-primary-500);
  box-shadow: 0 0 0 3px var(--color-primary-100);
}

.form-input--error {
  border-color: var(--color-error-500);
}

.form-input--error:focus {
  box-shadow: 0 0 0 3px var(--color-error-100);
}
```

### Textarea

```css
.form-textarea {
  /* Extends .form-input */
  min-height: 120px;
  resize: vertical;
  line-height: var(--line-height-normal);
}
```

### Select

```css
.form-select {
  /* Extends .form-input styles */
  appearance: none;
  background-image: url("data:image/svg+xml,..."); /* Chevron down */
  background-repeat: no-repeat;
  background-position: right var(--space-4) center;
  background-size: 16px;
  padding-right: var(--space-10);
  cursor: pointer;
}
```

### Label

```css
.form-label {
  display: block;
  margin-bottom: var(--space-2);
  font-size: var(--font-size-sm);
  font-weight: var(--font-weight-medium);
  color: var(--color-gray-700);
}

.form-label--required::after {
  content: " *";
  color: var(--color-error-500);
}
```

### Error Message

```css
.form-error {
  display: flex;
  align-items: center;
  gap: var(--space-1);
  margin-top: var(--space-1);
  font-size: var(--font-size-sm);
  color: var(--color-error-600);
}

.form-error__icon {
  width: 16px;
  height: 16px;
  flex-shrink: 0;
}
```

### File Upload

```css
.form-upload {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: var(--space-2);
  padding: var(--space-8);
  border: 2px dashed var(--color-gray-300);
  border-radius: var(--radius-lg);
  background-color: var(--color-gray-50);
  cursor: pointer;
  transition: var(--transition-colors);
}

.form-upload:hover {
  border-color: var(--color-primary-400);
  background-color: var(--color-primary-50);
}

.form-upload--dragover {
  border-color: var(--color-primary-500);
  background-color: var(--color-primary-100);
}

.form-upload__icon {
  width: 48px;
  height: 48px;
  color: var(--color-gray-400);
}

.form-upload__text {
  font-size: var(--font-size-sm);
  color: var(--color-gray-600);
  text-align: center;
}

.form-upload__hint {
  font-size: var(--font-size-xs);
  color: var(--color-gray-400);
}
```

---

## Navigation

### Header

```css
.header {
  position: sticky;
  top: 0;
  z-index: var(--z-sticky);
  background-color: white;
  border-bottom: 1px solid var(--color-gray-200);
  transition: box-shadow var(--duration-200) var(--ease-out);
}

.header--scrolled {
  box-shadow: var(--shadow-md);
}

.header__container {
  display: flex;
  align-items: center;
  justify-content: space-between;
  max-width: var(--container-xl);
  margin: 0 auto;
  padding: var(--space-4) var(--container-padding);
  height: 80px;
}

.header__logo {
  height: 50px;
  width: auto;
}

.header__nav {
  display: none;
  align-items: center;
  gap: var(--space-8);
}

@media (min-width: 992px) {
  .header__nav {
    display: flex;
  }
}

.header__link {
  font-size: var(--font-size-base);
  font-weight: var(--font-weight-medium);
  color: var(--color-gray-700);
  text-decoration: none;
  transition: var(--transition-colors);
}

.header__link:hover,
.header__link--active {
  color: var(--color-primary-700);
}

.header__phone {
  display: flex;
  align-items: center;
  gap: var(--space-2);
  font-size: var(--font-size-lg);
  font-weight: var(--font-weight-semibold);
  color: var(--color-primary-800);
}

.header__menu-btn {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 44px;
  height: 44px;
  background: none;
  border: none;
  cursor: pointer;
}

@media (min-width: 992px) {
  .header__menu-btn {
    display: none;
  }
}
```

### Mobile Menu

```css
.mobile-menu {
  position: fixed;
  top: 0;
  right: 0;
  bottom: 0;
  width: 100%;
  max-width: 400px;
  background-color: white;
  box-shadow: var(--shadow-2xl);
  z-index: var(--z-modal);
  transform: translateX(100%);
  transition: transform var(--duration-300) var(--ease-out);
}

.mobile-menu--open {
  transform: translateX(0);
}

.mobile-menu__header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: var(--space-4);
  border-bottom: 1px solid var(--color-gray-200);
}

.mobile-menu__close {
  width: 44px;
  height: 44px;
  display: flex;
  align-items: center;
  justify-content: center;
  background: none;
  border: none;
  cursor: pointer;
}

.mobile-menu__nav {
  padding: var(--space-4);
}

.mobile-menu__link {
  display: block;
  padding: var(--space-4);
  font-size: var(--font-size-lg);
  font-weight: var(--font-weight-medium);
  color: var(--color-gray-900);
  text-decoration: none;
  border-bottom: 1px solid var(--color-gray-100);
}

.mobile-menu__backdrop {
  position: fixed;
  inset: 0;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: calc(var(--z-modal) - 1);
  opacity: 0;
  visibility: hidden;
  transition: opacity var(--duration-300) var(--ease-out);
}

.mobile-menu__backdrop--visible {
  opacity: 1;
  visibility: visible;
}
```

---

## Hero Section

```css
.hero {
  position: relative;
  min-height: 70vh;
  display: flex;
  align-items: center;
  justify-content: center;
  overflow: hidden;
}

.hero__background {
  position: absolute;
  inset: 0;
  z-index: -1;
}

.hero__image {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.hero__overlay {
  position: absolute;
  inset: 0;
  background: linear-gradient(
    to right,
    rgba(0, 0, 0, 0.7) 0%,
    rgba(0, 0, 0, 0.5) 50%,
    rgba(0, 0, 0, 0.3) 100%
  );
}

.hero__content {
  position: relative;
  z-index: 1;
  max-width: var(--container-lg);
  padding: var(--space-8) var(--container-padding);
  text-align: center;
  color: white;
}

.hero__title {
  font-size: var(--font-size-4xl);
  font-weight: var(--font-weight-bold);
  line-height: var(--line-height-tight);
  margin-bottom: var(--space-4);
}

@media (min-width: 768px) {
  .hero__title {
    font-size: var(--font-size-5xl);
  }
}

.hero__subtitle {
  font-size: var(--font-size-lg);
  max-width: 600px;
  margin: 0 auto var(--space-8);
  opacity: 0.9;
}

@media (min-width: 768px) {
  .hero__subtitle {
    font-size: var(--font-size-xl);
  }
}

.hero__actions {
  display: flex;
  flex-direction: column;
  gap: var(--space-4);
  align-items: center;
}

@media (min-width: 640px) {
  .hero__actions {
    flex-direction: row;
    justify-content: center;
  }
}
```

---

## Statistics Section

```css
.stats {
  background-color: var(--color-primary-800);
  padding: var(--space-16) var(--container-padding);
}

.stats__grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: var(--space-8);
  max-width: var(--container-xl);
  margin: 0 auto;
}

@media (min-width: 768px) {
  .stats__grid {
    grid-template-columns: repeat(4, 1fr);
  }
}

.stats__item {
  text-align: center;
  color: white;
}

.stats__number {
  font-size: var(--font-size-4xl);
  font-weight: var(--font-weight-bold);
  line-height: 1;
  margin-bottom: var(--space-2);
}

@media (min-width: 768px) {
  .stats__number {
    font-size: var(--font-size-5xl);
  }
}

.stats__label {
  font-size: var(--font-size-sm);
  font-weight: var(--font-weight-medium);
  opacity: 0.9;
  text-transform: uppercase;
  letter-spacing: var(--tracking-wide);
}
```

---

## Carousel

```css
.carousel {
  position: relative;
  overflow: hidden;
}

.carousel__track {
  display: flex;
  transition: transform var(--duration-500) var(--ease-out);
}

.carousel__slide {
  flex: 0 0 100%;
  min-width: 0;
}

.carousel__nav {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  width: 48px;
  height: 48px;
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: white;
  border: none;
  border-radius: var(--radius-full);
  box-shadow: var(--shadow-lg);
  cursor: pointer;
  transition: var(--transition-transform);
  z-index: 10;
}

.carousel__nav:hover {
  transform: translateY(-50%) scale(1.1);
}

.carousel__nav--prev {
  left: var(--space-4);
}

.carousel__nav--next {
  right: var(--space-4);
}

.carousel__dots {
  display: flex;
  justify-content: center;
  gap: var(--space-2);
  margin-top: var(--space-6);
}

.carousel__dot {
  width: 10px;
  height: 10px;
  border-radius: var(--radius-full);
  background-color: var(--color-gray-300);
  border: none;
  cursor: pointer;
  transition: var(--transition-colors);
}

.carousel__dot--active {
  background-color: var(--color-primary-600);
}
```

---

## Footer

```css
.footer {
  background-color: var(--color-gray-900);
  color: white;
  padding-top: var(--space-16);
}

.footer__main {
  display: grid;
  grid-template-columns: 1fr;
  gap: var(--space-10);
  max-width: var(--container-xl);
  margin: 0 auto;
  padding: 0 var(--container-padding);
}

@media (min-width: 768px) {
  .footer__main {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media (min-width: 1024px) {
  .footer__main {
    grid-template-columns: 2fr 1fr 1fr 1.5fr;
  }
}

.footer__logo {
  height: 40px;
  margin-bottom: var(--space-4);
}

.footer__description {
  font-size: var(--font-size-sm);
  color: var(--color-gray-400);
  line-height: var(--line-height-relaxed);
  max-width: 300px;
}

.footer__heading {
  font-size: var(--font-size-lg);
  font-weight: var(--font-weight-semibold);
  margin-bottom: var(--space-6);
}

.footer__link {
  display: block;
  font-size: var(--font-size-sm);
  color: var(--color-gray-400);
  text-decoration: none;
  padding: var(--space-1) 0;
  transition: var(--transition-colors);
}

.footer__link:hover {
  color: white;
}

.footer__contact-item {
  display: flex;
  align-items: flex-start;
  gap: var(--space-3);
  margin-bottom: var(--space-4);
}

.footer__contact-icon {
  width: 20px;
  height: 20px;
  color: var(--color-primary-400);
  flex-shrink: 0;
  margin-top: 2px;
}

.footer__contact-text {
  font-size: var(--font-size-sm);
  color: var(--color-gray-400);
}

.footer__areas {
  background-color: rgba(255, 255, 255, 0.05);
  padding: var(--space-6) var(--container-padding);
  margin-top: var(--space-12);
  text-align: center;
}

.footer__areas-text {
  font-size: var(--font-size-sm);
  color: var(--color-gray-400);
}

.footer__bottom {
  border-top: 1px solid rgba(255, 255, 255, 0.1);
  padding: var(--space-6) var(--container-padding);
}

.footer__bottom-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: var(--space-4);
  max-width: var(--container-xl);
  margin: 0 auto;
}

@media (min-width: 768px) {
  .footer__bottom-content {
    flex-direction: row;
    justify-content: space-between;
  }
}

.footer__copyright {
  font-size: var(--font-size-sm);
  color: var(--color-gray-500);
}

.footer__legal {
  display: flex;
  gap: var(--space-6);
}

.footer__legal-link {
  font-size: var(--font-size-sm);
  color: var(--color-gray-500);
  text-decoration: none;
  transition: var(--transition-colors);
}

.footer__legal-link:hover {
  color: white;
}

.footer__social {
  display: flex;
  gap: var(--space-3);
}

.footer__social-link {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
  background-color: rgba(255, 255, 255, 0.1);
  border-radius: var(--radius-full);
  color: white;
  transition: var(--transition-colors);
}

.footer__social-link:hover {
  background-color: var(--color-primary-600);
}
```

---

## Related Documents

- [Design System](./design-system.md)
- [Layout](./layout.md)
- [Responsive](./responsive.md)
