import { TestBed } from '@angular/core/testing';

import { InfectionBreakdownResolverService } from './infection-breakdown-resolver.service';

describe('InfectionBreakdownResolverService', () => {
  let service: InfectionBreakdownResolverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InfectionBreakdownResolverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
