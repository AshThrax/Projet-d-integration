import { Complexe } from "./complexe";
import { Representation } from "./representation";

export class SalledeTheatre { Name: string;
  PlaceMax: number;
  PlaceCurrent: number;
  representations: Representation[];
  Complexe: Complexe;
  ComplexeId: number;

  constructor(
    Name: string,
    PlaceMax: number,
    PlaceCurrent: number,
    representations: Representation[],
    Complexe: Complexe,
    ComplexeId: number
  ) {
    this.Name = Name;
    this.PlaceMax = PlaceMax;
    this.PlaceCurrent = PlaceCurrent;
    this.representations = representations;
    this.Complexe = Complexe;
    this.ComplexeId = ComplexeId;
  }
}
