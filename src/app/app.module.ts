import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CanadaMapComponent } from './Components/canada-map/canada-map.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { InfectionBreakdownComponent } from './Components/infection-breakdown/infection-breakdown.component';
import { RestrictionsBreakdownComponent } from './Components/restrictions-breakdown/restrictions-breakdown.component'
import { HttpClientModule }    from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService }  from './Services/in-memory-data.service';
import { CitiesBreakdownComponent } from './Components/cities-breakdown/cities-breakdown.component';
import { CitySearchComponent } from './Components/city-search/city-search.component';

@NgModule({
  declarations: [
    AppComponent,
    CanadaMapComponent,
    InfectionBreakdownComponent,
    RestrictionsBreakdownComponent,
    CitiesBreakdownComponent,
    CitySearchComponent
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
