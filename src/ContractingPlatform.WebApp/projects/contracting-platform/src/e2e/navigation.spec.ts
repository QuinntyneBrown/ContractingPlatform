import { test, expect } from '@playwright/test';

test.describe('Navigation', () => {
  test('should navigate between all pages', async ({ page }) => {
    // Start at home
    await page.goto('/');
    await expect(page).toHaveURL('/');

    // Navigate to Services
    await page.click('a[href="/services"]');
    await expect(page).toHaveURL('/services');
    await expect(page.locator('.services')).toBeVisible();

    // Navigate to Contact
    await page.click('a[href="/contact"]');
    await expect(page).toHaveURL('/contact');
    await expect(page.locator('.contact')).toBeVisible();

    // Navigate back to Home
    await page.click('a[href="/"]');
    await expect(page).toHaveURL('/');
    await expect(page.locator('.home')).toBeVisible();
  });

  test('should have working logo link to home', async ({ page }) => {
    await page.goto('/services');
    await page.click('.header__logo');
    await expect(page).toHaveURL('/');
  });

  test('should display mobile menu on small screens', async ({ page }) => {
    // Set viewport to mobile size
    await page.setViewportSize({ width: 375, height: 667 });
    await page.goto('/');

    // Look for hamburger menu button
    const menuButton = page.locator('button[aria-label="Toggle menu"]');
    await expect(menuButton).toBeVisible();
  });

  test('should toggle mobile menu', async ({ page }) => {
    await page.setViewportSize({ width: 375, height: 667 });
    await page.goto('/');

    // Click hamburger menu
    await page.click('button[aria-label="Toggle menu"]');

    // Mobile menu should be visible
    await expect(page.locator('.header__mobile-menu--open')).toBeVisible();

    // Click again to close
    await page.click('button[aria-label="Toggle menu"]');

    // Mobile menu should be closed
    await expect(page.locator('.header__mobile-menu--open')).not.toBeVisible();
  });
});
