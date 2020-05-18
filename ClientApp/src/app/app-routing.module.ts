import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanadaMapComponent } from './Components/canada-map/canada-map.component';
import { HttpClientModule }    from '@angular/common/http';
import { CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms'
import { AppComponent } from './app.component';
import { InfectionBreakdownResolverService } from './Services/infection-breakdown-resolver.service';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { CitiesBreakdownResolverService } from './Services/cities-breakdown-resolver.service';


const routes: Routes = [
  {
    path: 'canada',
    component: DashboardComponent,
    resolve: {
      provinceInfectionData: InfectionBreakdownResolverService,
      citiesInfectionData: CitiesBreakdownResolverService
    }
  },
  {
    path: '',
    redirectTo: '/canada',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),
    CommonModule,
    FormsModule,
    HttpClientModule],
  exports: [RouterModule],
  providers: [InfectionBreakdownResolverService]
})
export class AppRoutingModule { }