import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import {
  debounceTime, distinctUntilChanged, switchMap
} from 'rxjs/operators';

import { City } from '../../Interfaces/city-info';
import { CitiesBreakdownService } from '../../Services/cities-breakdown.service';

@Component({
  selector: 'app-city-search',
  templateUrl: './city-search.component.html',
  styleUrls: ['./city-search.component.sass']
})
export class CitySearchComponent implements OnInit {
  cities$: Observable<City[]>;
  private searchTerms = new Subject<string>();

  constructor(private citiesBreakdownService: CitiesBreakdownService) { }

  //add the search term into the observable stream
  search(term: string): void{
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.cities$ = this.searchTerms.pipe (
      //wait 300ms after each keystroke before considering the term
      debounceTime(300),

      //ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.citiesBreakdownService.searchCities(term))
    )


  }

}
