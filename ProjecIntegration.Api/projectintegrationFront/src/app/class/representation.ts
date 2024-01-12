import { SalledeTheatre } from './salledetheatre';
import { Catalogue } from "./catalogue";

export class Representation {
   Name: string;
  Description: string;
  Type: string;
  Seance: Date;
  Catalogue: Catalogue;
  CatalogueId: number;
  SalleDeTheatre: SalledeTheatre;
  IdSalledeTheatre: number;

  constructor(
    Name: string,
    Description: string,
    Type: string,
    Seance: Date,
    Catalogue: Catalogue,
    CatalogueId: number,
    SalleDeTheatre: SalledeTheatre,
    IdSalledeTheatre: number
  ) {
    this.Name = Name;
    this.Description = Description;
    this.Type = Type;
    this.Seance = Seance;
    this.Catalogue = Catalogue;
    this.CatalogueId = CatalogueId;
    this.SalleDeTheatre = SalleDeTheatre;
    this.IdSalledeTheatre = IdSalledeTheatre;
  }
}


