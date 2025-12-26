import { test, expect } from '@playwright/test';

test.describe('Services Page', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/services');
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

  test('should display services grid', async ({ page }) => {
    await expect(page.locator('.services__grid')).toBeVisible();
  });

  test('should display service cards', async ({ page }) => {
    const serviceCards = page.locator('cp-service-card');
    await expect(serviceCards.first()).toBeVisible();
  });

  test('should display CTA section', async ({ page }) => {
    await expect(page.locator('.services__cta')).toBeVisible();
  });

  test('should navigate to contact page from CTA', async ({ page }) => {
    await page.click('.services__cta a[href="/contact"]');
    await expect(page).toHaveURL('/contact');
  });
});
