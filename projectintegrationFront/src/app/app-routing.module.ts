import { Piece } from './class/piece';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/client/home/home/home.component';
import { ContactComponent } from './pages/client/contact/contact/contact.component';
import { ProfileComponent } from './pages/Auth/profile/profile.component';
import { LstPieceComponent } from './pages/Shared/command/lst-Piece/lst-Piece.component';
import { ManagerComponent } from './pages/management/manager/manager.component';
import { LstRepresentationComponent } from './pages/Shared/command/lst-representation/lst-representation.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'profile', component: ProfileComponent},
  { path: 'contact', component: ContactComponent },
  { path: 'manager', component: ManagerComponent },
  { path: 'piece', component: LstPieceComponent },
  { path: 'representation', component: LstRepresentationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
