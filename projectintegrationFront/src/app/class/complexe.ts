import { SalleDeTheatre } from "./salledetheatre";

export class Complexe {
  id: number;
  name: string;
  description: string;
  adress: string;
  salleDeTheatres: SalleDeTheatre[];


  constructor(
    id: number,
    name: string,
    description: string,
    adress: string,
    salleDeTheatres: SalleDeTheatre[]

  ) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.adress=adress
    this.salleDeTheatres = salleDeTheatres;
  }
}
export class AddComplexe{
    name: string;
    description: string;
  address: string;
  constructor(
        name: string,
        description: string,
        address: string
  ) {
    this.name = name;
    this.description = description;
    this.address=address
    }
}

// UpdateComplexeDto
export class UpdateComplexe{
    id: number;
    name: string;
    description: string;
    address: string;
  constructor(
    id:number,
    name: string,
    description: string,
    address: string
  )
  { 
    this.id = id;
    this.name = name;
    this.description = description;
    this.address = address;
  }
}
