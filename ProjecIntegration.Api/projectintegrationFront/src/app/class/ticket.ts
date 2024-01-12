import { Command } from "./command";
import { Prix } from "./prix";
import { Representation } from "./representation";

export class Ticket {
   Name: string;
  Representation: Representation;
  IdRepresnentation: number;
  Command: Command;
  CommandId: number;
  Prix: Prix;
  IdPrix: number;

  constructor(
    Name: string,
    Representation: Representation,
    IdRepresnentation: number,
    Command: Command,
    CommandId: number,
    Prix: Prix,
    IdPrix: number
  )
  {
    this.Name = Name;
    this.Representation = Representation;
    this.IdRepresnentation = IdRepresnentation;
    this.Command = Command;
    this.CommandId = CommandId;
    this.Prix = Prix;
    this.IdPrix = IdPrix;
  }
}

