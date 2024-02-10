import { Component, OnInit } from '@angular/core';
import { TestService } from '../../../../service/test.service';
import { ListComplexeComponent } from '../../../Shared/command/list-complexe/list-complexe.component';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  constructor(public test: TestService) { }
  mytest!: any;
  
  
  ngOnInit(): void {

  }
}
