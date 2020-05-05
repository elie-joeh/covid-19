import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InfectionBreakdownService {

  constructor() { }

  public selected_province : Subject<any> = new Subject<any>();

  public selected_province_obs$ = this.selected_province.asObservable();

  
}
