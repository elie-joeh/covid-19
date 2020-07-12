import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DebtBreakdownComponent } from './debt-breakdown.component';

describe('DebtBreakdownComponent', () => {
  let component: DebtBreakdownComponent;
  let fixture: ComponentFixture<DebtBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DebtBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DebtBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
