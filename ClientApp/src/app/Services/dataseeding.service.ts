import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataseedingService {

  private dataseeding_url = 'api/Update';

  constructor(private http: HttpClient) { }

  storeDataInDatabase(): Observable<any> {
    return this.http.get<any>(this.dataseeding_url + "/GetGDPTillDate/1000")
        .pipe(
          tap(_ => console.log('stored the data in the databse'))
        );
  }
}
