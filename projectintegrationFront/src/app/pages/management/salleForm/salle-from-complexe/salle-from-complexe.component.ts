import { Component, OnInit } from '@angular/core';
import { SalledetheatreService } from '../../../../service/SalledeTheatre/SalledeTheatre.service';
import { SalleDeTheatre } from '../../../../class/salledetheatre';

@Component({
  selector: 'app-salle-from-complexe',
  templateUrl: './salle-from-complexe.component.html',
  styleUrl: './salle-from-complexe.component.css'
})
export class SalleFromComplexeComponent implements OnInit {

  isThisfill: boolean = false;
  listSalle: SalleDeTheatre[] = [];

  constructor(
    public service: SalledetheatreService
  ) { }

  ngOnInit() {
    this.service.get().subscribe(
      (params: SalleDeTheatre[]) => {
        this.listSalle = params;
        this.isThisfill = true;
    });
  }
}
