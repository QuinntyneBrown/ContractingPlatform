import { TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { Footer } from './footer';

describe('Footer', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Footer],
      providers: [
        provideRouter([]),
      ],
    }).compileComponents();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(Footer);
    const component = fixture.componentInstance;
    expect(component).toBeTruthy();
  });

  it('should have current year', () => {
    const fixture = TestBed.createComponent(Footer);
    const component = fixture.componentInstance;
    expect(component.currentYear).toBe(new Date().getFullYear());
  });

  it('should have quick links', () => {
    const fixture = TestBed.createComponent(Footer);
    const component = fixture.componentInstance;
    expect(component.quickLinks.length).toBeGreaterThan(0);
  });

  it('should have services list', () => {
    const fixture = TestBed.createComponent(Footer);
    const component = fixture.componentInstance;
    expect(component.services.length).toBeGreaterThan(0);
  });

  it('should have all NYC boroughs', () => {
    const fixture = TestBed.createComponent(Footer);
    const component = fixture.componentInstance;
    expect(component.boroughs).toContain('Manhattan');
    expect(component.boroughs).toContain('Brooklyn');
    expect(component.boroughs).toContain('Queens');
    expect(component.boroughs).toContain('Bronx');
    expect(component.boroughs).toContain('Staten Island');
  });
});
