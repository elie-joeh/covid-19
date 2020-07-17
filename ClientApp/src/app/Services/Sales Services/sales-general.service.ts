import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Retail } from 'src/app/Interfaces/Retail';
import { Manufacturing } from 'src/app/Interfaces/Manufacturing';
import { tap, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesGeneralService {

  private sales_url = "api/Retail/";
  private manufacturing_url = "api/Manufacturing/";

  constructor(private http: HttpClient) { }

  getRetails(){
    return this.http.get<Retail[]>(this.sales_url + "GetRetails")
      .pipe(
        tap( _=> console.log('fetched retails by vector')),
        catchError(this.handleFetchError<Retail[]>('getRetails', []))
      );
  }

  getRetailsByVector(vector: string){
    return this.http.get<Retail[]>(this.sales_url + "GetRetailsByVector/" + vector)
        .pipe(
          tap( _=> console.log('fetched retails by vector')),
          catchError(this.handleFetchError<Retail[]>('getRetailsByVector', []))
        );
  }

  getRetailsByVectors(vectors: string){
    return this.http.get<Retail[]>(this.sales_url + "GetRetailsByVectors/" + vectors)
        .pipe(
          tap( _=> console.log('fetched retails by vectors')),
          catchError(this.handleFetchError<Retail[]>('getRetailsByVectors', []))
        );
  }

  getManufacturings(){
    return this.http.get<Manufacturing[]>(this.manufacturing_url + "GetManufacturings")
        .pipe(
          tap( _=> console.log('fetched Manufacturings')),
          catchError(this.handleFetchError<Retail[]>('getManufacturings', []))
        )
  }

  getManufacturingsByVector(vector: string){
    return this.http.get<Manufacturing[]>(this.manufacturing_url + "GetManufacturingByVector/" + vector)
        .pipe(
          tap( _=> console.log('fetched Manufacturings by vector')),
          catchError(this.handleFetchError<Retail[]>('getManufacturingsByVector', []))
        )
  }

  getManufacturingsByVectors(vectors: string){
    return this.http.get<Manufacturing[]>(this.manufacturing_url + "GetManufacturingByVectors/" + vectors)
        .pipe(
          tap( _=> console.log('fetched Manufacturings by vectors')),
          catchError(this.handleFetchError<Retail[]>('getManufacturingsByVectors', []))
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
}
