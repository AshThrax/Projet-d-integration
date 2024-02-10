import { Component,OnInit } from '@angular/core';
import { Representation } from '../../../../class/representation';
import { ActivatedRoute, Router } from '@angular/router';
import { RepresentationService } from '../../../../service/Representation/representation.service';


@Component({
  selector: 'app-lst-representation',
  templateUrl: './lst-representation.component.html',
  styleUrl: './lst-representation.component.css'
})

export class LstRepresentationComponent implements OnInit{
  IsitemFill :boolean = false;
  items: Representation[] = [];
  idPiece!: number;
  constructor(
    public rout : Router,
    public routes: ActivatedRoute,
    private service: RepresentationService
  ) { }
  ngOnInit() {
    this.routes.queryParams.subscribe(params => { this.idPiece = params['id'] });
    this.getPiecerepresentation();
  }
  makeCommand(): void {

  }
  getPiecerepresentation(): void { 
    this.service.getPiece(this.idPiece).subscribe(params =>
    { 
      this.items = params;
      this.IsitemFill = true;
    })
  }
}
