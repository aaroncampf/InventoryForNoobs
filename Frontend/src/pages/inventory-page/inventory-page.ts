console.log('inventoryPage called');


import { Component } from '@angular/core';

/**
 * Inventory for NOOBS!
 * FrontPage component for rendering the landing page view
 * @author rex@hackd.design
 */
@Component ({
    selector: 'inventory-page',
    template: `
        <div class="wrapper">
            <h1> Inventory Page </h1>
        </div>
    `
})

export class InventoryPage {
    constructor() {
    }
};