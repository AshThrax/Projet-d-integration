import { Catalogue } from "./catalogue";
import { SalledeTheatre } from "./salledetheatre";

export class Complexe {
   Name: string;
  Description: string;
  SalleDeTheatres: SalledeTheatre[];
  Catalogues: Catalogue[];

  constructor(
    Name: string,
    Description: string,
    SalleDeTheatres: SalledeTheatre[],
    Catalogues: Catalogue[]
  ) {
    this.Name = Name;
    this.Description = Description;
    this.SalleDeTheatres = SalleDeTheatres;
    this.Catalogues = Catalogues;
  }
}
