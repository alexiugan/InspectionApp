import { TestBed } from '@angular/core/testing';

import { InspectionTypeApiService } from './inspection-type-api.service';

describe('InspectionTypeApiService', () => {
  let service: InspectionTypeApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InspectionTypeApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
