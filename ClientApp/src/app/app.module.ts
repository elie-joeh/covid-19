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

@NgModule({
  declarations: [
    AppComponent,
    CanadaMapComponent,
    InfectionBreakdownComponent,
    RestrictionsBreakdownComponent,
    CitiesBreakdownComponent,
    DashboardComponent,
    EconomicBreakdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GoogleChartsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
