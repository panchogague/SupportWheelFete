import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { EngineerService } from '../../services/engineer.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-engineer',
  templateUrl: './engineer.component.html',
  styles: []
})
export class EngineerComponent implements OnInit {

  engineer = {
    name: null
  };
  constructor(private engineerService: EngineerService,private router:Router) { }

  ngOnInit() {
  }

  saveEngineer(f: NgForm) {
    if (f.invalid) {
      return;
    }

    this.engineerService.saveEngineer(this.engineer).subscribe(resp => {
     
      this.router.navigate(['/engineers']);
    });    

  }

}
