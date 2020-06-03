import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EconomicBreakdownComponent } from './economic-breakdown.component';

describe('EconomicBreakdownComponent', () => {
  let component: EconomicBreakdownComponent;
  let fixture: ComponentFixture<EconomicBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EconomicBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EconomicBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
