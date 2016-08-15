console.log("app component fired");
import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `
 <div class="container">
    <div class="row">
        <span class="col">
            <h1>A Noobs Inventory</h1>        
        </span> 
    </div>
    <div class="row">
        <span class="col-xs-4">
            <hr> 
            A project that is in development by
            <h4> The Dark Lord of the Dot Net</h4>
            &&
            <br>
            <h4> Rex the i'll Dev <a href="mailto:rex@hackd.design"> email </a> </h4>
            updated: 9-14-2016
            <h1>N A V</h1>
        </span>
        <span class="col-xs-8">
            <front-page></front-page>
        </span>
    </div>

</div>
  `
  
  
})

export class AppComponent { 
  constructor(){};
}
