import { Router } from '@angular/router';
import { SalledetheatreService } from '../../../../service/SalledeTheatre/SalledeTheatre.service';
import { SalleDeTheatre } from './../../../../class/salledetheatre';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lst-salle',
  templateUrl: './lst-salle.component.html',
  styleUrl: './lst-salle.component.css'
})
export class LstSalleComponent implements OnInit {

  Sallelst : SalleDeTheatre []=[]
  constructor(
    private SalleService: SalledetheatreService,
    private router: Router
  ) { }

  ngOnInit() { 
    this.SalleService.get()
      .subscribe(
      params => { 
        this.Sallelst = params;
      }
    )
  }
  getPiece(id:number): void
  { 
    
  }
  AddPiece(id: number) {
    this.router.navigate(['piece/add'],{ queryParams: { id: id } });
  }
  updateSalle(item:SalleDeTheatre) {
    this.router.navigate(['piece/update'],{ queryParams: {item: SalleDeTheatre} });
  }
}
