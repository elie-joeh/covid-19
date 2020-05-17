import { Injectable } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { City } from '../Interfaces/city-info';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CitiesBreakdownService {
  public selected_province : Subject<any> = new Subject<any>();

  public selected_province_obs$ = this.selected_province.asObservable();

  private cities_breakdown_url = 'api/cities_info';


  //an observable from HttpClient always emits a single value and then completes, so never emit again
  getCitiesInfo(): Observable<City[]>{
    return this.http.get<City[]>(this.cities_breakdown_url)
        .pipe(
          tap(_ => console.log('fetched infection information')),
          catchError(this.handleFetchError<City[]>('getCitiesInfo', []))
        )
  }


  //GET cities whose name contains search term
  searchCities(term: string): Observable<City[]> {
    //nothing to search in this case
    if( !term.trim() ) {
      return of([]);
    }

    return this.http.get<City[]>(`${this.cities_breakdown_url}/?name=${term}`).pipe(
      tap(x => x.length ?
        console.log(`found cities mathcing "${term}"`) :
        console.log(`no cities matching "${term}"`)),
      catchError(this.handleFetchError<City[]>('search Cities', []))
    )
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

  constructor(private http: HttpClient) { }
}
