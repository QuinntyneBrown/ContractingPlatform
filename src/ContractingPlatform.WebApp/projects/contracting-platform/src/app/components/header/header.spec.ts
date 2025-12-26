import { TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { Header } from './header';

describe('Header', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Header],
      providers: [
        provideRouter([]),
        provideAnimationsAsync(),
      ],
    }).compileComponents();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(Header);
    const component = fixture.componentInstance;
    expect(component).toBeTruthy();
  });

  it('should have navigation links', () => {
    const fixture = TestBed.createComponent(Header);
    const component = fixture.componentInstance;
    expect(component.navLinks.length).toBeGreaterThan(0);
  });

  it('should have Home link', () => {
    const fixture = TestBed.createComponent(Header);
    const component = fixture.componentInstance;
    const homeLink = component.navLinks.find(link => link.label === 'Home');
    expect(homeLink).toBeTruthy();
    expect(homeLink?.path).toBe('/');
  });

  it('should toggle mobile menu', () => {
    const fixture = TestBed.createComponent(Header);
    const component = fixture.componentInstance;
    expect(component.mobileMenuOpen).toBe(false);
    component.toggleMobileMenu();
    expect(component.mobileMenuOpen).toBe(true);
    component.toggleMobileMenu();
    expect(component.mobileMenuOpen).toBe(false);
  });

  it('should close mobile menu', () => {
    const fixture = TestBed.createComponent(Header);
    const component = fixture.componentInstance;
    component.mobileMenuOpen = true;
    component.closeMobileMenu();
    expect(component.mobileMenuOpen).toBe(false);
  });
});
