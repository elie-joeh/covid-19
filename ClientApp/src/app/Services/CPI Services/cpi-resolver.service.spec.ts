import { TestBed } from '@angular/core/testing';

import { CpiResolverService } from './cpi-resolver.service';

describe('CpiResolverService', () => {
  let service: CpiResolverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CpiResolverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
