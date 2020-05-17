import { TestBed } from '@angular/core/testing';

import { CitiesBreakdownResolverService } from './cities-breakdown-resolver.service';

describe('CitiesBreakdownResolverService', () => {
  let service: CitiesBreakdownResolverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CitiesBreakdownResolverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
