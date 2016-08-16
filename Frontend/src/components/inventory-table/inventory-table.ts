import { Component } from '@angular/core';
//import { InventoryData } from '../../providers/inventory-data/inventory-data';
import { InventoryRow } from './inventory-row';


// data service 

@Component({

    selector: 'inventory-table',
  //  providers: [InventoryData], 
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
                <span (click)="openDialog('large')" class="rowWrapper">
                    <span class="cell col-xs-1 col-sm-1">{{row.id}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row.name}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row.qty}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row.location}}</span>
                    <span class="cell col-xs-1 col-sm-1">{{row.value}}</span>
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

    constructor(){
        console.log('Inventory Table Constructor Fired');
   // Check for CORS // this.getInventoryData();
        
    for (let i = 0; i < 30; i++) {
        this.rows.push({ 
        id: i,
        name: "Rex Deh Cahg " + i,
        qty:42 - i,
        location:"Looking Glass Way " + i,
        value:3 + i * 2 % 30,
        meta:null,
        transaction:[]
    });
    }
//{"_id":27,"_Name":"Rex Deh Cahg","_Qty":42,"_Location":"Looking Glass Way","_Value":3.14,"_Meta":null,"_Transactions":[]}

    }
   /**
    *   CORS issue 
    
    *   Call data from the DB
    getInventoryData() {
        this.inventoryData.loadInventoryData()
        .then( rows => this.rows = rows )
        .catch( error => this.error = error )
        console.dir(this.rows);
    }
    */ 

}