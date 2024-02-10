import { ComplexeService } from '../../../../service/ComplexeService/complexe.service';
import { Complexe } from '../../../../class/complexe';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list-complexe',
  templateUrl: './list-complexe.component.html',
  styleUrls: ['./list-complexe.component.css']
})
export class ListComplexeComponent implements OnInit {

  IsitemFill: boolean = false;
  items: Complexe[]=[];
  constructor(public compServ: ComplexeService,
    private router: Router) { }

  ngOnInit() {
    this.compServ.get().subscribe((data: Complexe[]) => {
      this.items = data;
      this.IsitemFill = true;
    });
  }

  getPieceComposant(id: number) {
    this.router.navigate(['piece'],{ queryParams: { id: id } });
  }
}
