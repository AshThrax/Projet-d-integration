import { Complexe } from "./complexe";
import { Representation } from "./representation";

export class Catalogue {Name: string;
  Description: string;
  Representations: Representation[];
  Complexe: Complexe;
  ComplexeId: number;
  DebutCatalogue: Date;
  FinCatalogue: Date;

  constructor(
    Name: string,
    Description: string,
    Representations: Representation[],
    Complexe: Complexe,
    ComplexeId: number,
    DebutCatalogue: Date,
    FinCatalogue: Date
  ) {
    this.Name = Name;
    this.Description = Description;
    this.Representations = Representations;
    this.Complexe = Complexe;
    this.ComplexeId = ComplexeId;
    this.DebutCatalogue = DebutCatalogue;
    this.FinCatalogue = FinCatalogue;
  }
}
