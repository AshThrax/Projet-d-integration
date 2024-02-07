/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LstPieceComponent } from './lst-Piece.component';

describe('LstPieceComponent', () => {
  let component: LstPieceComponent;
  let fixture: ComponentFixture<LstPieceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LstPieceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LstPieceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
