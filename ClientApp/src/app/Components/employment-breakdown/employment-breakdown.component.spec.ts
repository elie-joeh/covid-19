import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmploymentBreakdownComponent } from './employment-breakdown.component';

describe('EmploymentBreakdownComponent', () => {
  let component: EmploymentBreakdownComponent;
  let fixture: ComponentFixture<EmploymentBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmploymentBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmploymentBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
