console.log("app component fired");
import { Component } from '@angular/core';
import{ NavBar} from './components/nav-bar/nav-bar';

// import {FaDirective} from 'angular2-fontawesome/directives';
// import { FaComponent } from 'angular2-fontawesome/components';


@Component({
    directives: [NavBar],
    selector: 'my-app',
    template: `
<div class="container">
    <div class="row">
        <span class="col text-center">
            <h1>A Noob's Inventory</h1>        
            <hr> 
        </span>
    </div>
    <div class="row">
        <span class="col-xs-4 text-center">
            A project that is in development by
            <span class="noobNames text-center">
                <h4> <span class="text-nowrap">The Dark Lord </span></h4>
                <h4><span class="text-nowrap">of the </span></h4>
                <h4><span class="text-nowrap">Dot Net Framework </span></h4>
                <a href="mailto:aaroncampf@gmail.com"> email </a>
            </span>
            <br>
            <span class="noobNames text-center">
                <h4> Rex </h4> 
                the 
                <h4>Dev ill</h4> 
                    <a href="mailto:rex@hackd.design"> email </a>
                <hr>
            </span>
            <nav-bar></nav-bar>
        </span>
        <span class="col-xs-8 text-center">
            <router-outlet></router-outlet>
        </span>
    </div>
</div>
`
})

export class AppComponent {
    constructor() { };
}
