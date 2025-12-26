import { test, expect } from '@playwright/test';

test.describe('Contact Page', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/contact');
  });

  test('should display the header', async ({ page }) => {
    await expect(page.locator('app-header')).toBeVisible();
  });

  test('should display the footer', async ({ page }) => {
    await expect(page.locator('app-footer')).toBeVisible();
  });

  test('should display hero section', async ({ page }) => {
    await expect(page.locator('cp-hero-section')).toBeVisible();
  });

  test('should display emergency banner', async ({ page }) => {
    await expect(page.locator('.contact__emergency')).toBeVisible();
  });

  test('should display contact form', async ({ page }) => {
    await expect(page.locator('form')).toBeVisible();
  });

  test('should have full name field', async ({ page }) => {
    await expect(page.locator('input[formcontrolname="fullName"]')).toBeVisible();
  });

  test('should have email field', async ({ page }) => {
    await expect(page.locator('input[formcontrolname="email"]')).toBeVisible();
  });

  test('should have phone field', async ({ page }) => {
    await expect(page.locator('input[formcontrolname="phone"]')).toBeVisible();
  });

  test('should have service type dropdown', async ({ page }) => {
    await expect(page.locator('mat-select[formcontrolname="serviceType"]')).toBeVisible();
  });

  test('should have submit button', async ({ page }) => {
    await expect(page.locator('button[type="submit"]')).toBeVisible();
  });

  test('should validate required fields on submit', async ({ page }) => {
    await page.click('button[type="submit"]');
    // Form should not submit due to validation
    await expect(page).toHaveURL('/contact');
  });

  test('should display contact information', async ({ page }) => {
    await expect(page.locator('.contact__info')).toBeVisible();
  });

  test('should display phone number in contact info', async ({ page }) => {
    await expect(page.locator('.contact__info')).toContainText('(718) 550-2779');
  });
});
