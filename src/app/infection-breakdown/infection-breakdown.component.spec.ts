import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InfectionBreakdownComponent } from './infection-breakdown.component';

describe('InfectionBreakdownComponent', () => {
  let component: InfectionBreakdownComponent;
  let fixture: ComponentFixture<InfectionBreakdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InfectionBreakdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InfectionBreakdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
