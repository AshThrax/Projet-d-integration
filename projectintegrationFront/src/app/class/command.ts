import { Representation } from "./representation";

export class Command {
  id: number;
  authId: string;
  nombreDePlace: number;
  representation: Representation;
  idRepresnetation: number;

  constructor(
    id: number,
    authId: string,
    nombreDePlace: number,
    representation: Representation,
    idRepresnetation: number
  ) {
    this.id = id;
    this.authId = authId;
    this.nombreDePlace = nombreDePlace;
    this.representation = representation;
    this.idRepresnetation = idRepresnetation;
  }
}
export class addCommand
{
  nombreDePlace: number;
  representation: Representation;
  idRepresnetation: number;
    constructor(
   
    nombreDePlace: number,
    representation: Representation,
    idRepresnetation: number
  ) {
    this.nombreDePlace = nombreDePlace;
      this.representation = representation;
      this.idRepresnetation = idRepresnetation;
  }
}

export class UpdateCommand
{
   id: number;
   nombreDePlace: number;
   representation: Representation;
   idRepresnetation: number;
    constructor(
    id: number,
    nombreDePlace: number,
    representation: Representation,
    idRepresnetation: number
    ) {
      this.id = id;
      this.nombreDePlace = nombreDePlace;
      this.representation = representation;
      this.idRepresnetation = idRepresnetation;
  }
}
