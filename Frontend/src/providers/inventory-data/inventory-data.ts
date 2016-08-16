import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
/**
 * Data provider for populating data tables with content
 * @author {rob@hackd.design}
 */
@Injectable()
export class InventoryData {
  data: any;

  constructor(private http: Http) {
    this.data = null;
  }

  loadInventoryData() {
    console.log('data called');
    if (this.data) {
      // already loaded data
      return Promise.resolve(this.data);

    }
    // don't have the data yet
    return new Promise(resolve => {
      this.http.get('http://inventoryfornoobs.azurewebsites.net/api/MasterInventoryItems')
        .map(res => res.json())
        .subscribe(data => {
          // we've got back the raw data
          console.dir(data);
          this.data = data;
          resolve(this.data);
        });
    });
  }
}

