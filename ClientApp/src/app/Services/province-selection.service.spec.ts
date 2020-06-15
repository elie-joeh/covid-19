import { TestBed } from '@angular/core/testing';

import { ProvinceSelectionService } from './province-selection.service';

describe('ProvinceSelectionService', () => {
  let service: ProvinceSelectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProvinceSelectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
