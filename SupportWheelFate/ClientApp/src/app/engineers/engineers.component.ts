import { Component, OnInit } from '@angular/core';
import { EngineerService } from '../services/engineer.service';

@Component({
  selector: 'app-engineers',
  templateUrl: './engineers.component.html',
  styles: []
})
export class EngineersComponent implements OnInit {

  engineers:any[]=[];
  isLoading:boolean=true;
  constructor(private engineerService:EngineerService) { 
    
  }

  loadEngineers() {
    this.isLoading=true;
    this.engineerService.getAll().subscribe((resp: any) => {
      this.engineers = resp;
      this.isLoading=false;
    });
  }




  ngOnInit() {
    this.loadEngineers();
  }

  deleteEngineer(id: number) {
    this.engineerService.deleteEngineer(id).subscribe(resp => {
      this.loadEngineers();
    });
  }

}
