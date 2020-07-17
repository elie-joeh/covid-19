import { TestBed } from '@angular/core/testing';

import { SalesGeneralService } from './sales-general.service';

describe('SalesGeneralService', () => {
  let service: SalesGeneralService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalesGeneralService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
