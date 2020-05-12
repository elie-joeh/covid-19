import { Injectable } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Infection_info } from '../Interfaces/infection-info';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InfectionBreakdownService {
  public selected_province : Subject<any> = new Subject<any>();

  public selected_province_obs$ = this.selected_province.asObservable();

  private infection_breakdown_url = 'api/infection_info';

  constructor(private http: HttpClient) { }


  //an observable from HttpClient always emits a single value and then completes, so never emit again
  getInfectionInfo(): Observable<Infection_info[]>{
    return this.http.get<Infection_info[]>(this.infection_breakdown_url)
        .pipe(
          tap(_ => console.log('fetched infection information')),
          catchError(this.handleFetchError<Infection_info[]>('getInfectionInfo', []))
        )
  }

  getInfecionInfoByProvince(province_name: string): Observable<Infection_info> {
    const url = `${this.infection_breakdown_url}/${province_name}`;
    return this.http.get<Infection_info>(url).pipe(
      tap(_ => console.log(`fetched province infection information, name=${province_name}`)),
      catchError(this.handleFetchError<Infection_info>(`get infection info by prov name=${province_name}`))
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
