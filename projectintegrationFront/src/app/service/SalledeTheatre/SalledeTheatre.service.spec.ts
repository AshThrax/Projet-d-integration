/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SalledetheatreService } from './salledetheatre.service';

describe('Service: Salledetheatre', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SalledetheatreService]
    });
  });

  it('should ...', inject([SalledetheatreService], (service: SalledetheatreService) => {
    expect(service).toBeTruthy();
  }));
});
