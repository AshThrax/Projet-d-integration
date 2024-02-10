import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LstSalleComponent } from './lst-salle.component';

describe('LstSalleComponent', () => {
  let component: LstSalleComponent;
  let fixture: ComponentFixture<LstSalleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LstSalleComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LstSalleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
