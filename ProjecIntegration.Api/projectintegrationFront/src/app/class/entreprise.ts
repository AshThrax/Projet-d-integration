import { Complexe } from "./complexe";

export class Entreprise {
  Nom: string;
  Adress: string;
  Complexes: Complexe[]; // Assuming Complexe is another class

  constructor(Nom: string, Adress: string, Complexes: Complexe[]) {
    this.Nom = Nom;
    this.Adress = Adress;
    this.Complexes = Complexes;
  }
}
