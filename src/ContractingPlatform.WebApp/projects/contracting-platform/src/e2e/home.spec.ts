import { test, expect } from '@playwright/test';

test.describe('Home Page', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/');
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

  test('should display statistics section', async ({ page }) => {
    await expect(page.locator('.home__stats')).toBeVisible();
  });

  test('should display services section', async ({ page }) => {
    await expect(page.locator('.home__services')).toBeVisible();
  });

  test('should display trust badges section', async ({ page }) => {
    await expect(page.locator('.home__trust')).toBeVisible();
  });

  test('should navigate to services page', async ({ page }) => {
    await page.click('a[href="/services"]');
    await expect(page).toHaveURL('/services');
  });

  test('should navigate to contact page', async ({ page }) => {
    await page.click('a[href="/contact"]');
    await expect(page).toHaveURL('/contact');
  });

  test('should have Get Free Estimate button in hero', async ({ page }) => {
    const heroButton = page.locator('cp-hero-section button').first();
    await expect(heroButton).toBeVisible();
  });
});
