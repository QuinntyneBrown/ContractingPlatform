import { TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { Services } from './services';

describe('Services', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Services],
      providers: [
        provideRouter([]),
        provideHttpClient(),
        provideAnimationsAsync(),
      ],
    }).compileComponents();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(Services);
    const component = fixture.componentInstance;
    expect(component).toBeTruthy();
  });

  it('should have viewModel$', () => {
    const fixture = TestBed.createComponent(Services);
    const component = fixture.componentInstance;
    expect(component.viewModel$).toBeTruthy();
  });
});
