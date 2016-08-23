import { Component } from '@angular/core';
import { InventoryData } from '../../providers/inventory-data/inventory-data';
import { InventoryRow } from './inventory-row';

// data service 

@Component({
    selector: 'inventory-table',
    providers: [InventoryData], 
    template: `
<div class="container">
        <div class="row">
            <span class="col-xs-12"><h1 class="text-left">The Master List :)</h1>
            <br>
            <hr>
            </span>
        </div>
        <div class="inv row">
            <span class="header col-xs-2 col-sm-1">ID</span>
            <span class="header col-xs-2 col-sm-1">Name</span>
            <span class="header col-xs-2 col-sm-1">QTY</span>
            <span class="header col-xs-2 col-sm-1">Location</span>
            <span class="header col-xs-2 col-sm-1">Value</span>
            <span class="header col-xs-2 col-sm-2">Options</span>
            <span class="header blank col-xs-2 col-sm-5">X</span>
            <div class="inv table" *ngFor="let row of rows">
                <span (click)="callData()" class="rowWrapper">
                    <span class="cell col-xs-1 col-sm-1">{{row._id}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row._Name}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row._Qty}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row._Location}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row._Value}}</span>
                    <span class="cell col-xs-1 col-sm-2">EDIT</span>
                    <span class="blank col-xs-1 col-sm-5">X</span>
                </span>
            </div>
        </div>
</div>
    `
})
export class InventoryTable {

    // Declare Data Vars
    error: any;
    rows: InventoryRow[] = [];
    title = 'Inventory Table Title';

    constructor(public inventoryData: InventoryData ){
        console.log('Inventory Table Constructor Fired');
   // Check for CORS // this.getInventoryData();
        //  Call data from the DB
        this.callData();
        
    }
    callData(){
        this.inventoryData.loadInventoryData()
        .then( rows => this.rows = rows )
        .catch( error => this.error = error )
        console.log("This rows below");
        console.dir(this.rows);
    }
};
