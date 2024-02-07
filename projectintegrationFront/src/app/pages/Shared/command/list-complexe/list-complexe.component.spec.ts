/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListComplexeComponent } from './list-complexe.component';

describe('ListComplexeComponent', () => {
  let component: ListComplexeComponent;
  let fixture: ComponentFixture<ListComplexeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListComplexeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListComplexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
