import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CanadaMapComponent } from './canada-map/canada-map.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { InfectionBreakdownComponent } from './infection-breakdown/infection-breakdown.component';
import { RestrictionsBreakdownComponent } from './restrictions-breakdown/restrictions-breakdown.component'
import { HttpClientModule }    from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService }  from './in-memory-data.service';
import { CitiesBreakdownComponent } from './cities-breakdown/cities-breakdown.component';

@NgModule({
  declarations: [
    AppComponent,
    CanadaMapComponent,
    InfectionBreakdownComponent,
    RestrictionsBreakdownComponent,
    CitiesBreakdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GoogleChartsModule,
    HttpClientModule,
    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, { dataEncapsulation: false }
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
