import { Component } from '@angular/core';
import { InventoryData } from '../../providers/inventory-data/inventory-data';
import { InventoryRow } from './inventory-row';

// data service 

@Component({
    selector: 'inventory-table',
    providers: [InventoryData], 
    template: `
        <h1> I am a table </h1>
        
        <div *ngFor="let row of rows">
            Row : {{row.id}}
        </div>

        I am the end of the table
    `
})
export class InventoryTable {

    // Declare Data Vars
    error: any;
    rows: InventoryRow[] = [];
    title = 'Inventory Table Title';

    constructor(private inventoryData: InventoryData){
        console.log('Inventory Table Constructor Fired');
        this.getInventoryData();
        
    }
   /**
    *   Call data from the DB
    */ 
    getInventoryData() {
        this.inventoryData.loadInventoryData()
        .then( rows => this.rows = rows )
        .catch( error => this.error = error )
        console.dir(this.rows);
    }
}