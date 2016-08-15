import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }  from './app.component';
import { routing }       from './app.routing';
import { NavBar } from './components/nav-bar/nav-bar';
import { FrontPage } from './pages/front-page/front-page';

@NgModule({
  imports:      [ BrowserModule, routing ],
  declarations: [ AppComponent, NavBar, FrontPage ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
