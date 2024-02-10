/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ComplexeService } from './complexe.service';

describe('Service: Complexe', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ComplexeService]
    });
  });

  it('should ...', inject([ComplexeService], (service: ComplexeService) => {
    expect(service).toBeTruthy();
  }));
});
