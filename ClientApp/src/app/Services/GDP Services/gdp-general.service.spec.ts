import { TestBed } from '@angular/core/testing';

import { GdpGeneralService } from './gdp-general.service';

describe('GdpGeneralService', () => {
  let service: GdpGeneralService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GdpGeneralService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
