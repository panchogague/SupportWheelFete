import { Injectable } from '@angular/core';
import { HttpClient } from '../../../node_modules/@angular/common/http';
import { URL_SERVICE } from '../../configs/config';

@Injectable()
export class ScheduleService {

  constructor(private http: HttpClient) { }

  getSchedule(){
    return this.http.get(URL_SERVICE + "Schedule").map(res => res);
  }
}
