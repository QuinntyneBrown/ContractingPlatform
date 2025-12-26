import { TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { Home } from './home';

describe('Home', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Home],
      providers: [
        provideRouter([]),
        provideHttpClient(),
        provideAnimationsAsync(),
      ],
    }).compileComponents();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(Home);
    const component = fixture.componentInstance;
    expect(component).toBeTruthy();
  });

  it('should have viewModel$', () => {
    const fixture = TestBed.createComponent(Home);
    const component = fixture.componentInstance;
    expect(component.viewModel$).toBeTruthy();
  });

  it('should have onGetEstimate method', () => {
    const fixture = TestBed.createComponent(Home);
    const component = fixture.componentInstance;
    expect(typeof component.onGetEstimate).toBe('function');
  });

  it('should have onCallNow method', () => {
    const fixture = TestBed.createComponent(Home);
    const component = fixture.componentInstance;
    expect(typeof component.onCallNow).toBe('function');
  });
});
