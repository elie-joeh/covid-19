import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Debt} from '../../Interfaces/Debt';
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DebtGeneralService {

  private debt_general_url = "api/Debt";

  constructor(private http: HttpClient) { }

  getDebtByVector(vector_id: string){
    return this.http.get<Debt[]>(this.debt_general_url + "/GetDebtsByVector/" + vector_id)
        .pipe(
          tap(_ => console.log('fetched emploment info for lfc sex and group')),
          catchError(this.handleFetchError<Debt[]>('getDebtByVector', []))
        );;
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
