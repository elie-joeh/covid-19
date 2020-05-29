import { Injectable } from '@angular/core';
import {Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router';
import { Observable, empty } from 'rxjs';
import {InfectionBreakdownService} from './infection-breakdown.service';
import { Province } from '../Interfaces/Province';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InfectionBreakdownResolverService implements Resolve<Observable<Province[]>> {
  constructor(private infectionBreakdown: InfectionBreakdownService) { }

  resolve(route: ActivatedRouteSnapshot, rstate: RouterStateSnapshot): Observable<Province[]> {
    console.log('infection resolver is fetching the infection information');
      return this.infectionBreakdown.getInfectionInfo().pipe(
        catchError((error) => {
          console.log("ERRRRROR");
          return empty();
        })
      );
  }
}
