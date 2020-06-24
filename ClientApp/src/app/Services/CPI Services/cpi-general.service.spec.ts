import { TestBed } from '@angular/core/testing';

import { CpiGeneralService } from './cpi-general.service';

describe('CpiGeneralService', () => {
  let service: CpiGeneralService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CpiGeneralService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
