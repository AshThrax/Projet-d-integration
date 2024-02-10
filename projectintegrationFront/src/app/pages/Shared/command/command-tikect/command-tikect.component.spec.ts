import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommandTikectComponent } from './command-tikect.component';

describe('CommandTikectComponent', () => {
  let component: CommandTikectComponent;
  let fixture: ComponentFixture<CommandTikectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CommandTikectComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CommandTikectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
