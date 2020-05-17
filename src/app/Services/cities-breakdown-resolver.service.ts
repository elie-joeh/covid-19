import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable, empty } from 'rxjs';
import { CitiesBreakdownService } from './cities-breakdown.service';
import { City } from '../Interfaces/city-info';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CitiesBreakdownResolverService implements Resolve<Observable<City[]>> {

  constructor(private citiesBreakdown: CitiesBreakdownService) { }

  resolve(route: import("@angular/router").ActivatedRouteSnapshot, state: import("@angular/router").RouterStateSnapshot): Observable<City[]> {
    console.log('cities resolver is fetching the infection information');
    return this.citiesBreakdown.getCitiesInfo().pipe(
      catchError((error) => {
        console.log("Error in fetching cities breakdown info");
        return empty();
      })
    )
  }
}
