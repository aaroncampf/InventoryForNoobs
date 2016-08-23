import { Component } from '@angular/core';

/**
 * Inventory for NOOBS!
 * FrontPage component for rendering the landing page view
 * @author rex@hackd.design
 */
@Component ({
    selector: 'nav-bar',
    template: `
    <h2> N A V </h2>
       <div class="nav">
                <a routerLink="/noobs">Home</a>
                <br>
                <a routerLink="/inventory">Inventory</a>
        </div>
    `
})

export class NavBar {
    constructor() {

    }
};