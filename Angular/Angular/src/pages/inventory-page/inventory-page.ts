console.log('inventoryPage called');
import { Component } from '@angular/core';
import { InventoryTable } from '../../components/inventory-table/inventory-table';
/**
 * Inventory for NOOBS!
 * FrontPage component for rendering the landing page view
 * @author rex@hackd.design
 */
@Component ({
    directives: [InventoryTable],
    selector: 'inventory-page',
    template: `
            <h1> The Inventory </h1>
            <inventory-table></inventory-table>
    `
})

export class InventoryPage {
    constructor() { }
};