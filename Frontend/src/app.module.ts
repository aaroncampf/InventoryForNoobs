import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_PROVIDERS} from '@angular/http';
import { AppComponent }  from './app.component';
import { routing }       from './app.routing';
import { NavBar } from './components/nav-bar/nav-bar';
import { FrontPage } from './pages/front-page/front-page';
import { FormsModule }    from '@angular/forms';
import { HttpModule }     from '@angular/http';



@NgModule({
  imports:      [ BrowserModule, FormsModule, routing, HttpModule ],
  declarations: [ AppComponent, NavBar, FrontPage ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
