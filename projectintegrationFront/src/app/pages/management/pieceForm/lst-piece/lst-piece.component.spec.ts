import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LstPieceComponent } from './lst-piece.component';

describe('LstPieceComponent', () => {
  let component: LstPieceComponent;
  let fixture: ComponentFixture<LstPieceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LstPieceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LstPieceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
