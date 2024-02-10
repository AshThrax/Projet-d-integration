import { Piece } from './piece';
import { Complexe } from "./complexe";
import { Representation } from "./representation";

export class SalleDeTheatre {
  id: number;
  name: string;
  placeMax: number;
  placeCurrent: number;
  complexeId: number;
  complexe: Complexe;
  representations: Representation[];
  Piece: Piece[];
  constructor(
    id: number,
    name: string,
    placeMax: number,
    placeCurrent: number,
    complexeId: number,
    complexe: Complexe,
    representations: Representation[],
    Piece: Piece[]
  ) {
    this.id = id;
    this.name = name;
    this.placeMax = placeMax;
    this.placeCurrent = placeCurrent;
    this.complexeId = complexeId;
    this.complexe = complexe;
    this.representations = representations;
    this.Piece = Piece;
  }
}
export class AddSalleDeTheatre{
    public Name: string;
    public PlaceMax: number;
    public PlaceCurrent: number;
    public ComplexeId: number;

    constructor(Name: string, PlaceMax: number, PlaceCurrent: number, ComplexeId: number) {
        this.Name = Name;
        this.PlaceMax = PlaceMax;
        this.PlaceCurrent = PlaceCurrent;
        this.ComplexeId = ComplexeId;
    }
}
export class UpdateSalleDeTheatre{
    id: number;
    Name: string;
    PlaceMax: number;
    PlaceCurrent: number;
    ComplexeId: number;
    

    constructor(id: number,Name: string, PlaceMax: number, PlaceCurrent: number, ComplexeId: number) {
        this.id = id;
        this.Name = Name;
        this.PlaceMax = PlaceMax;
        this.PlaceCurrent = PlaceCurrent;
        this.ComplexeId = ComplexeId;
       
    }
}