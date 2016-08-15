console.log("app component fired");
import { Component } from '@angular/core';
//import {FaDirective} from 'angular2-fontawesome/directives';
import { FaComponent } from 'angular2-fontawesome/components';


@Component({
  directives: [FaComponent],
  selector: 'my-app',
  template: `
 <div class="container">
    <div class="row">
        <span class="col">
            <h1>A Noobs Inventory</h1>        
            <hr> 
        </span> 
    </div>
    <div class="row">
        <span class="col-xs-4">
            A project that is in development by
            <h4> <span class="text-nowrap">The Dark Lord of the Dot Net </span></h4> <a href="mailto:aaroncampf@gmail.com"> email </a>
            <br>
            <h4> Rex the i'll Dev </h4> <a href="mailto:rex@hackd.design"> email </a>
            <hr>
            updated: 9-14-2016
            <h1>N A V</h1>
            <ul>
              <li>
                <button>
                Home
                <fa [name]="'rocket'" [size]=1></fa>
                </button>
              </li>
              <li>
                <button>
                Inventory
                <fa [name]="'rocket'" [size]=1></fa>
                </button>
              </li>
            </ul>
        </span>
        <span class="col-xs-8 text-center">

            <front-page></front-page>
        </span>
    </div>

</div>
  `


})

export class AppComponent {
  constructor() { };
}
