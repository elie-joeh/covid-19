import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RestrictionsBreakdownComponent } from './restrictions-breakdown.component';

describe('RestrictionsBreakdownComponent', () => {
  let component: RestrictionsBreakdownComponent;
  let fixture: ComponentFixture<RestrictionsBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RestrictionsBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RestrictionsBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
