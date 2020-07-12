import { TestBed } from '@angular/core/testing';

import { DebtGeneralService } from './debt-general.service';

describe('DebtGeneralService', () => {
  let service: DebtGeneralService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DebtGeneralService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
