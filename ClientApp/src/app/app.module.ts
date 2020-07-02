import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CanadaMapComponent } from './Components/canada-map/canada-map.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { InfectionBreakdownComponent } from './Components/infection-breakdown/infection-breakdown.component';
import { RestrictionsBreakdownComponent } from './Components/restrictions-breakdown/restrictions-breakdown.component'
import { HttpClientModule } from '@angular/common/http';
import { CitiesBreakdownComponent } from './Components/cities-breakdown/cities-breakdown.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { EconomicBreakdownComponent } from './Components/economic-breakdown/economic-breakdown.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DataseedingComponent } from './Components/dataseeding/dataseeding.component';
import { EmploymentBreakdownComponent } from './Components/employment-breakdown/employment-breakdown.component';

@NgModule({
  declarations: [
    AppComponent,
    CanadaMapComponent,
    InfectionBreakdownComponent,
    RestrictionsBreakdownComponent,
    CitiesBreakdownComponent,
    DashboardComponent,
    EconomicBreakdownComponent,
    DataseedingComponent,
    EmploymentBreakdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GoogleChartsModule,
    HttpClientModule,
    NgxChartsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
