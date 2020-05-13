import { Injectable } from '@angular/core';
import {Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router';
import { Observable, empty } from 'rxjs';
import {InfectionBreakdownService} from './infection-breakdown.service';
import { Infection_info } from '../Interfaces/infection-info';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InfectionBreakdownResolverService implements Resolve<Observable<Infection_info[]>> {
  constructor(private infectionBreakdown: InfectionBreakdownService) { }

  resolve(route: ActivatedRouteSnapshot, rstate: RouterStateSnapshot): Observable<Infection_info[]> {
    console.log('infection resolver is fetching the infection information');
      return this.infectionBreakdown.getInfectionInfo().pipe(
        catchError((error) => {
          console.log("ERRRRROR");
          return empty();
        })
      );
  }
}
