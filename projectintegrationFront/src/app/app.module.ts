import { ListComplexeComponent } from './pages/Shared/command/list-complexe/list-complexe.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/client/home/home/home.component';
import { ReactiveFormsModule } from '@angular/forms';
// Import the injector module and the HTTP client module from Angular
import { HTTP_INTERCEPTORS } from '@angular/common/http';
// Import the HTTP interceptor from the Auth0 Angular SDK
import { AuthHttpInterceptor, AuthModule } from '@auth0/auth0-angular';
import { ProfileComponent } from './pages/Auth/profile/profile.component'
import { HeaderComponent } from './pages/Shared/header/header.component';
import { AuthNavComponent } from './pages/Auth/auth-nav/auth-nav.component';
import { ContactComponent } from './pages/client/contact/contact/contact.component';
import { LstRepresentationComponent } from './pages/Shared/command/lst-representation/lst-representation.component';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FooterComponent } from './pages/Shared/footer/footer.component';
import { ListCommandComponent } from './pages/Shared/command/list-command/list-command.component';
import { LstPieceComponent } from './pages/Shared/command/lst-Piece/lst-Piece.component';
import { AddComplexeComponent } from './pages/management/complexeForm/add-complexe/add-complexe.component';
import { UpdtComplexeComponent } from './pages/management/complexeForm/updt-complexe/updt-complexe.component';
import { AddPieceComponent } from './pages/management/pieceForm/add-piece/add-piece.component';
import { UpdtPieceComponent } from './pages/management/pieceForm/updt-piece/updt-piece.component';
import { AddRepresentationComponent } from './pages/management/representationForm/add-representation/add-representation.component';
import { AddSalleComponent } from './pages/management/salleForm/add-salle/add-salle.component';
import { ManagerComponent } from './pages/management/manager/manager.component';
import { LstSalleComponent } from './pages/management/salleForm/lst-salle/lst-salle.component';
import { RepresentationLstComponent } from './pages/management/representationForm/representation-lst/representation-lst.component';
import { LstComplexeComponent } from './pages/management/complexeForm/lst-complexe/lst-complexe.component';
import { CommandTikectComponent } from './pages/Shared/command/command-tikect/command-tikect.component';
import { TestComponent } from './pages/management/manager/test/test.component';
import { SalleFromComplexeComponent } from './pages/management/salleForm/salle-from-complexe/salle-from-complexe.component';
import { SharedModule } from './sharedroute/shared/shared.module';
@NgModule({
  declarations: [
    AddRepresentationComponent,
    LstRepresentationComponent,
    AppComponent,
    HomeComponent,
    ProfileComponent,
    HeaderComponent,
    AuthNavComponent,
    ContactComponent,
    ListComplexeComponent,
    LstRepresentationComponent,
    FooterComponent,
    ListCommandComponent,
    LstPieceComponent,
    AddComplexeComponent,
    UpdtComplexeComponent,
    AddPieceComponent,
    UpdtPieceComponent,
    AddRepresentationComponent,
    AddSalleComponent,
    ManagerComponent,
    LstSalleComponent,
    RepresentationLstComponent,
    LstComplexeComponent,
    CommandTikectComponent,
    TestComponent,
    SalleFromComplexeComponent
  ],
  imports: [
    //SubroutModule,
    SharedModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    AuthModule.forRoot({
  // The domain and clientId were configured in the previous chapter
  domain: 'dev-mhy3-faq.us.auth0.com',
  clientId: 'yG5aYSR9TrB8iJykGUKj7UrfcHgGR5hM',
  authorizationParams: {
    redirect_uri: window.location.origin,
    // Request this audience at user authentication time
    audience: 'https://hello-world.example.com',
    // Request this scope at user authentication time
  },
  // Specify configuration for the interceptor
  httpInterceptor: {
    allowedList: [
      {
        uri: 'https://localhost:44364/api/*',//my application api url
        tokenOptions: {
          authorizationParams: {
            audience: 'https://hello-world.example.com'
           //auth0 apiaudience
          }
        }
      }
    ]
  }
})
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthHttpInterceptor, multi: true },

  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
 }
