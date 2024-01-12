import { Component } from '@angular/core';
import { AuthService } from '../../../auth.service';

@Component({
  selector: 'app-auth-nav',
  templateUrl: './auth-nav.component.html',
  styleUrl: './auth-nav.component.css'
})
export class AuthNavComponent {

  constructor(public auth: AuthService) { }
}
