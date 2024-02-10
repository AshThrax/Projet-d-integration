import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalleFromComplexeComponent } from './salle-from-complexe.component';

describe('SalleFromComplexeComponent', () => {
  let component: SalleFromComplexeComponent;
  let fixture: ComponentFixture<SalleFromComplexeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SalleFromComplexeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalleFromComplexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
