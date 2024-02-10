import { Representation } from "./representation";

export class Piece {
  id: number;
  titre: string;
  duree: number;
  description: string;
  representations: Representation[];
  

  constructor(
    id: number,
    titre: string,
    duree: number,
    description: string,
    representations: Representation[]
  ) {
    this.id = id;
    this.titre = titre;
    this.duree = duree;
    this.description = description;
    this.representations = representations;
  }
}
export class AddPiece {
  titre: string ;
  duree: number;
  description: string ;

  constructor(titre: string, duree: number, description: string)
  {
    this.titre = titre;
    this.duree = duree;
    this.description = description;
  }
  
}
export class UpdatePiece {
  id: number;
  titre: string;
  duree: number;
  description: string;
  idSalle: number;
  constructor(
    id: number,
    titre: string,
    duree: number,
    description: string,
    idSalle: number
  ) {
    this.id = id;
    this.titre = titre;
    this.duree = duree;
    this.description = description; 
    this.idSalle = idSalle;
  }
}