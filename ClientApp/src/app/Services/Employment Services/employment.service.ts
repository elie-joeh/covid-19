import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employment } from '../../Interfaces/Employment';
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmploymentService {

  private employment_general_url = 'api/Employment';

  constructor(private http: HttpClient) { }

  getEmploymentByLfcSexGroup(lfc: number, sex: number, group: number){
    return this.http.get<Employment[]>(this.employment_general_url + "/GetEmploymentsByLfcSexGroup/" + lfc +"/"+sex+"/"+group)
      .pipe(
        tap(_ => console.log('fetched emploment info for lfc sex and group')),
        catchError(this.handleFetchError<Employment[]>('getEmploymentByLfcSexGroup', []))
      );
  }

  getEmploymentBySexGroup(sex: number, group: number) {
    return this.http.get<Employment[]>(this.employment_general_url+"/GetEmploymentsBySexGroup/"+sex+"/"+group)
        .pipe(
          tap(_ => console.log('fetched emploment info for lfc sex and group')),
          catchError(this.handleFetchError<Employment[]>('getEmploymentByLfcSexGroup', []))
        );
  }

  getEmploymentBySexesGroup(sex: number, group: number) {
    return this.http.get<Employment[]>(this.employment_general_url+"/GetEmploymentsBySexesGroup/"+sex+"/"+group)
        .pipe(
          tap(_ => console.log('fetched emploment info for lfc sexes and group')),
          catchError(this.handleFetchError<Employment[]>('getEmploymentBySexesGroup', []))
        );
  }

  getEmploymentByLfcSexGroups(lfc: number, sex: number, groups: number) {
    return this.http.get<Employment[]>(this.employment_general_url + "/GetEmploymentsByLfcSexGroups/"+lfc+"/"+sex+"/"+groups)
        .pipe(
          tap(_ => console.log('fetched emploment info for lfc sexes and group')),
          catchError(this.handleFetchError<Employment[]>('getEmploymentBySexesGroup', []))
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
