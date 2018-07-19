import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

//Pages
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EngineersComponent } from './engineers/engineers.component';
import { EngineerComponent } from './engineers/engineer/engineer.component';
import { LoadingComponent } from './components/ui/loading/loading.component';
//Services
import { EngineerService } from './services/engineer.service';
import { ScheduleService } from './services/schedule.service';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EngineersComponent,
    EngineerComponent,
    LoadingComponent
  ],
  imports: [
    FormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'engineers', component: EngineersComponent },
      { path: 'engineer', component: EngineerComponent },
      
    ])
  ],
  providers: [EngineerService,ScheduleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
