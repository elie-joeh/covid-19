import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CanadaMapComponent } from './Components/canada-map/canada-map.component';
import { AppResolverService } from './Services/app-resolver.service';
import { HttpClientModule }    from '@angular/common/http';
import { CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms'

const routes: Routes = [
  {
    path: 'canada',
    component: CanadaMapComponent,
    resolve: {
      mapData: AppResolverService
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
  providers: [AppResolverService]
})
export class AppRoutingModule { }
