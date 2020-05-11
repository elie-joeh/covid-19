import { Injectable } from '@angular/core';
import {Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router';
import { Observable, empty } from 'rxjs';
import {InfectionBreakdownService} from './infection-breakdown.service';
import { Infection_info } from '../Interfaces/infection-info';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AppResolverService implements Resolve<Observable<Infection_info[]>>{
  constructor(private infectionBreakdownService: InfectionBreakdownService) { }

  resolve(route: ActivatedRouteSnapshot, rstate: RouterStateSnapshot): Observable<Infection_info[]> {
      console.log('Resolver is fetching the infection information');
      return this.infectionBreakdownService.getInfectionInfo().pipe(
        catchError((error) => {
          console.log("ERRRRROR");
          return empty();
        })
      );
  }

}
