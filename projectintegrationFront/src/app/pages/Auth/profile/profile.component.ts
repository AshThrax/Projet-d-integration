import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Command } from '../../../class/command';
import { CommandService } from '../../../service/CommandService/Command.service';
import { ListCommandComponent } from '../../Shared/command/list-command/list-command.component';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})

export class ProfileComponent implements OnInit {
  user$ = this.auth.user$;
  itemCommand: any;
  authid!: any;
IsitemFill: boolean=false;
  constructor(
    public auth: AuthService,
    private CmdUser: CommandService) { }

  ngOnInit()
  {
    //this.getUserCommand();
    this.getauth();
  }
  getUserCommand()
  {
    this.CmdUser.getbyUser().subscribe((cmd: Command[]) => {
      this.itemCommand = cmd; this.IsitemFill=true});
      
  }
  getauth() { 
    this.CmdUser.getAuth()
      .subscribe((cmd: string) => { this.authid = cmd })
  }
}
