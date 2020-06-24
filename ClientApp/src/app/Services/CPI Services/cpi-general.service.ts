import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CPI } from '../../Interfaces/CPI'
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CpiGeneralService {

  private cpi_general_url = 'api/CPI';

  constructor(private http: HttpClient) { }

  //service that will get all cpi data related to a specific geography
  getCPIByGeo(geography_name : string) {
    return this.http.get<CPI[]>(this.cpi_general_url + "/GetCPIByGeo/" + geography_name)
        .pipe(
          tap(_ => console.log('fetched cpi info for geo')),
          catchError(this.handleFetchError<CPI[]>('getCPIGeo', []))
        );
  }

  //service that will get all cpi data related to a specific ppdg
  getCPIByPPDG(ppdg: string) {
    let url = this.cpi_general_url + "/getCPIByPpdg/" + ppdg;
    return this.http.get<CPI[]>(url)
      .pipe(
        tap(_ => console.log('fetched the cpi data info for ppdg')),
        catchError(this.handleFetchError<CPI[]>('getCPIByPPDG', []))
      );
  }

  //service that will get all cpi data related to multiple geos and 1 ppdg
  getCPIByGeosByPPDG(geos: string[], ppdg: string) {
    let url = this.cpi_general_url + "/GetCPIByGeosByPPDG/" + ppdg + "/";
    for(let geo of geos) {
      url += geo + ",";
    }
    url = url.substring(0, url.length - 1);
    return this.http.get<CPI[]>(url)
      .pipe(
        tap(_ => console.log('fetched cpi info for geos and ppdg')),
        catchError(this.handleFetchError<CPI[]>('getCPIByGeosByPPG', []))
      );
  }


   /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
private handleFetchError<T>(operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
    //TODO: send the error to remote logging infrastructure
    console.error(error);
    //TODO: better job of transformin error for user consumption
    console.log(`${operation} failed: ${error.message}`);
    //let the app running by returning an empty result
    return of(result as T);
  }
}


}
