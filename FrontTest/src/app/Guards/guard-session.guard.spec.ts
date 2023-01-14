import { TestBed } from '@angular/core/testing';

import { GuardSessionGuard } from './guard-session.guard';

describe('GuardSessionGuard', () => {
  let guard: GuardSessionGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(GuardSessionGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
