import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from '@auth0/auth0-angular';
import { CatalogueComponent } from './pages/management/catalogue/catalogue/catalogue.component';
import { ComplexeComponent } from './pages/management/complexe/complexe/complexe.component';
import { HomeComponent } from './pages/client/home/home/home.component';
import { AuthNavComponent } from './pages/Auth/auth-nav/auth-nav.component';

@NgModule({
  declarations: [
    AppComponent,
    CatalogueComponent,
    ComplexeComponent,
    HomeComponent,
    AuthNavComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AuthModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
