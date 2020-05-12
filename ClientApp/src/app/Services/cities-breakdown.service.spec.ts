import { TestBed } from '@angular/core/testing';

import { CitiesBreakdownService } from './cities-breakdown.service';

describe('CitiesBreakdownService', () => {
  let service: CitiesBreakdownService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CitiesBreakdownService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
