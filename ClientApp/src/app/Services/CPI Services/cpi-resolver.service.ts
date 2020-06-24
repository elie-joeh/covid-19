import { Injectable } from '@angular/core';
import { CpiGeneralService } from './cpi-general.service';
import { Observable, empty } from 'rxjs';
import {Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router';
import {CPI} from '../../Interfaces/CPI';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CpiResolverService implements Resolve<Observable<CPI[]>>{

  constructor(private cpiService: CpiGeneralService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<CPI[]> {
    let param = route.data['resolveData1'];
    console.log('cpi resolver is fetching the cpi information ' + param);
    return this.cpiService.getCPIByGeosByPPDG(['CA'], "All-items").pipe(
      catchError((error) => {
        console.log('error in cpi resolver');
        return empty();
      })
    )


  }

  
}
