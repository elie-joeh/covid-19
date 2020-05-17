import { TestBed } from '@angular/core/testing';

import { InfectionBreakdownService } from './infection-breakdown.service';

describe('InfectionBreakdownService', () => {
  let service: InfectionBreakdownService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InfectionBreakdownService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
