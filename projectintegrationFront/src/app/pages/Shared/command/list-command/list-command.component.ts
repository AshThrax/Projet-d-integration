import { CommandService } from '../../../../service/CommandService/Command.service';
import { Command } from './../../../../class/command';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-command',
  templateUrl: './list-command.component.html',
  styleUrl: './list-command.component.css'
})
export class ListCommandComponent implements OnInit {
  CmItems: Command[] = [];

  constructor(
    private service:CommandService
  ) { }
  ngOnInit(): void {

  }
  getCommand(): void
  { 
    this.service.getbyUser().subscribe((params:Command []) =>
    { 
      this.CmItems = params;
    })
  }
}
