import { Component } from '@angular/core';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrl: './manager.component.css'
})
export class ManagerComponent {
getComplexe() {
 this.isComplexe = true;
  this.isPiece = false;
  this.isSalle = false;
  this.isrepresentation = false;
}
getSalle() {
 this.isComplexe = false;
  this.isPiece = false;
  this.isSalle = true;
  this.isrepresentation = false;
}
getrepresentation() {
 this.isComplexe = false;
  this.isPiece = false;
  this.isSalle = false;
  this.isrepresentation = true;
}
getPiece() {
  this.isComplexe = false;
  this.isPiece = true;
  this.isSalle = false;
  this.isrepresentation = false;
}

  isComplexe: boolean = true;
  isrepresentation: boolean = false;
  isPiece: boolean = false;
  isSalle: boolean = false;
}
