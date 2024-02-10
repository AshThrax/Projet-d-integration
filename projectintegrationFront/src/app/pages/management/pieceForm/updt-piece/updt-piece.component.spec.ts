import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdtPieceComponent } from './updt-piece.component';

describe('UpdtPieceComponent', () => {
  let component: UpdtPieceComponent;
  let fixture: ComponentFixture<UpdtPieceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdtPieceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdtPieceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
