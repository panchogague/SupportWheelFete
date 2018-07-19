import { Injectable } from '@angular/core';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { URL_SERVICE } from '../../configs/config';
import  "rxjs/add/operator/map";
@Injectable()
export class EngineerService {

  constructor(private http: HttpClient) { }
   URL = URL_SERVICE + "engineer";
  getAll() {
    return this.http.get(this.URL).map( res => res);
  }

  deleteEngineer(id) {
    
    return this.http.delete(this.URL + "/" + id).map(resp => console.log('removed'));
  }

  saveEngineer(engineer) {
 
    return this.http.post(this.URL,engineer).map(resp => console.log('saved'));
  }

}
