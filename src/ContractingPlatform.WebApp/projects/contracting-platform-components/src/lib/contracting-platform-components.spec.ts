import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractingPlatformComponents } from './contracting-platform-components';

describe('ContractingPlatformComponents', () => {
  let component: ContractingPlatformComponents;
  let fixture: ComponentFixture<ContractingPlatformComponents>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContractingPlatformComponents]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContractingPlatformComponents);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
