import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataseedingComponent } from './dataseeding.component';

describe('DataseedingComponent', () => {
  let component: DataseedingComponent;
  let fixture: ComponentFixture<DataseedingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataseedingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataseedingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
