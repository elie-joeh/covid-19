import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesBreakdownComponent } from './sales-breakdown.component';

describe('SalesBreakdownComponent', () => {
  let component: SalesBreakdownComponent;
  let fixture: ComponentFixture<SalesBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
