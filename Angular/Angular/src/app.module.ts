import { NgModule }      from '@angular/core';
import { BrowserModule,   } from '@angular/platform-browser';
import {HTTP_PROVIDERS} from '@angular/http';
import { AppComponent }  from './app.component';
import { routing }       from './app.routing';
import { NavBar } from './components/nav-bar/nav-bar';
import { FrontPage } from './pages/front-page/front-page';
import { FormsModule }    from '@angular/forms';
import { HttpModule }     from '@angular/http';

import { ModalModule } from 'angular2-modal';
import { BootstrapModalModule } from 'angular2-modal/plugins/bootstrap';

//import { CustomModal } from './components/ng-modal/modal.component';

@NgModule({
  imports:      [ BrowserModule, FormsModule, routing, HttpModule ],
  declarations: [ AppComponent, NavBar, FrontPage ],
  bootstrap:    [ AppComponent ]
 // entryComponents: [ CustomModal ]
 
})
export class AppModule { }
