import { TestBed } from '@angular/core/testing';

import { InventarieService } from './inventarie.service';

describe('InventarieService', () => {
  let service: InventarieService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InventarieService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
