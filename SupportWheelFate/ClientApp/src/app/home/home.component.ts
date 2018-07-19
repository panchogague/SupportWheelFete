import { Component } from '@angular/core';
import { EngineerService } from '../services/engineer.service';
import { ScheduleService } from '../services/schedule.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent {

  isLoading: boolean = true;
  engineers:any[]=[];
  schedule:any;
  constructor(private engineerService:EngineerService, private scheduleService:ScheduleService){

  }

  ngOnInit() {
    this.isLoading = true;
    this.scheduleService.getSchedule().subscribe(res => {
      this.schedule = res;
      this.engineerService.getAll().subscribe((res: any) => { this.engineers = res; this.isLoading = false });
    });




  }  


}
