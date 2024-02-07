import { Component, OnInit } from '@angular/core';
import { Complexe } from '../../../../class/complexe';
import { ComplexeService } from '../../../../service/ComplexeService/complexe.service';

@Component({
  selector: 'app-lst-complexe',
  templateUrl: './lst-complexe.component.html',
  styleUrl: './lst-complexe.component.css'
})
export class LstComplexeComponent implements OnInit {

  compItem: Complexe[]=[];

  constructor(
    public service: ComplexeService,
  ) { }
  
  ngOnInit(): void {
    this.service.get().subscribe(
      (Params:Complexe[]) => { 
      this.compItem = Params;
    }
    );
  }
  getComplexe(): void { 
      this.service.get().subscribe((data: Complexe[]) => {
     this.compItem = data;
    });
  }

}
