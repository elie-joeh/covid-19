import { TestBed } from '@angular/core/testing';

import { EconomicProvinceService } from './economic-province.service';

describe('EconomicProvinceService', () => {
  let service: EconomicProvinceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EconomicProvinceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
