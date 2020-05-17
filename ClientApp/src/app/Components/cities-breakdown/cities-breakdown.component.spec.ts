import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CitiesBreakdownComponent } from './cities-breakdown.component';

describe('CitiesBreakdownComponent', () => {
  let component: CitiesBreakdownComponent;
  let fixture: ComponentFixture<CitiesBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CitiesBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CitiesBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
