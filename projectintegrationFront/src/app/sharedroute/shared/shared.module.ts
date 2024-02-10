import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalleFromComplexeComponent } from '../../pages/management/salleForm/salle-from-complexe/salle-from-complexe.component';
import { LstPieceComponent } from '../../pages/Shared/command/lst-Piece/lst-Piece.component';
import { LstRepresentationComponent } from '../../pages/Shared/command/lst-representation/lst-representation.component';
import { AddComplexeComponent } from '../../pages/management/complexeForm/add-complexe/add-complexe.component';
import { LstComplexeComponent } from '../../pages/management/complexeForm/lst-complexe/lst-complexe.component';
import { UpdtComplexeComponent } from '../../pages/management/complexeForm/updt-complexe/updt-complexe.component';
import { AddPieceComponent } from '../../pages/management/pieceForm/add-piece/add-piece.component';
import { UpdtPieceComponent } from '../../pages/management/pieceForm/updt-piece/updt-piece.component';
import { AddRepresentationComponent } from '../../pages/management/representationForm/add-representation/add-representation.component';
import { AddSalleComponent } from '../../pages/management/salleForm/add-salle/add-salle.component';

@NgModule({
  declarations: [],
  imports: [
    CommonModule

  ],
  exports: [
    SharedModule,
    
    SalleFromComplexeComponent,
    AddSalleComponent,
    AddRepresentationComponent,
    UpdtPieceComponent,
    AddPieceComponent,
    UpdtComplexeComponent,
    LstComplexeComponent,
    AddComplexeComponent,
    LstRepresentationComponent,
    LstPieceComponent
  ]
})
export class SharedModule { }
