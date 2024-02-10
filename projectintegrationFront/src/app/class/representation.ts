import { Command } from "./command";
import { Piece } from "./piece";
import { SalleDeTheatre } from "./salledetheatre";

export class Representation {
  id: number;
  name: string;
  prix: number;
  MaxPlace: number;
  currentPLace: Number;
  description: string;
  type: string;
  seance: Date;
  salleDeTheatre: SalleDeTheatre;
  idSalledeTheatre: number;
  piece: Piece;
  idPiece: number;
  commands: Command[];

   constructor(
     id: number,
     name: string,
     prix: number,
     MaxPlace: number,
    currentPLace: Number,
     description: string,
     type: string,
     seance: Date,
     salleDeTheatre: SalleDeTheatre,
     idSalledeTheatre: number,
     piece: Piece,
     idPiece: number,
     commands: Command[]
   ) {
     this.prix = prix;
     this.id = id;
     this.name = name;
     this.MaxPlace = MaxPlace;
     this.currentPLace= currentPLace;
     this.description = description;
     this.type = type;
     this.seance = seance;
     this.salleDeTheatre = salleDeTheatre;
     this.idSalledeTheatre = idSalledeTheatre;
     this.piece = piece;
     this.idPiece = idPiece;
     this.commands = commands;
  }
}
export class AddRepresentation {

    Prix: number;
    Seance: Date;
    IdSalleDeTheatre: number;
    IdPiece: number;
    MaxPlace: number;
    currentPLace: Number;
  constructor(Prix: number,
    Seance: Date,
    IdSalleDeTheatre: number, MaxPlace: number,
    currentPLace: Number,
    IdPiece: number) {
        this.Prix = Prix;
        this.Seance = Seance;
        this.IdSalleDeTheatre = IdSalleDeTheatre;
        this.IdPiece = IdPiece;
        this.MaxPlace = MaxPlace;
        this.currentPLace = currentPLace;
    }
}
export class UpdateRepresentation{
  id: number;
  Prix: number;
  Seance: Date;
  IdSalleDeTheatre: number;
  IdPiece: number;
  MaxPlace: number;
  currentPLace: Number;
  constructor(id: number,
    Prix: number,
    Seance: Date,
    IdSalleDeTheatre: number,
    IdPiece: number,
     MaxPlace: number,
    currentPLace: Number,
  ) {
      // Assurez-vous d'appeler le constructeur de la classe de base si nécessaire
       this.id =id;
        this.Prix = Prix;
        this.Seance = Seance;
        this.IdSalleDeTheatre = IdSalleDeTheatre;
        this.IdPiece = IdPiece;
        this.MaxPlace=MaxPlace
        this.currentPLace=currentPLace
    }
}