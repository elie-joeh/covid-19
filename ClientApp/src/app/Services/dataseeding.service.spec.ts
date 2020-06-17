import { TestBed } from '@angular/core/testing';

import { DataseedingService } from './dataseeding.service';

describe('DataseedingService', () => {
  let service: DataseedingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataseedingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
