import { Component, OnInit, Input } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import {
  debounceTime, distinctUntilChanged, switchMap
} from 'rxjs/operators';

import { City } from '../../Interfaces/city-info';
import { CitiesBreakdownService } from '../../Services/cities-breakdown.service';

@Component({
  selector: 'app-cities-breakdown',
  templateUrl: './cities-breakdown.component.html',
  styleUrls: ['./cities-breakdown.component.sass']
})
export class CitiesBreakdownComponent implements OnInit {

  @Input() allCities: City[];
  
  selected_province: string = 'Quebec';

  cities$: Observable<City[]>;
  searchCities: City[] = [];

  private searchTerms = new Subject<string>();

  constructor(private citiesBreakdownService: CitiesBreakdownService) { }

  ngOnInit(): void {
    this.citiesBreakdownService.selected_province_obs$.subscribe(
      data => this.handleNewProvince(data)
    ); 
    
    this.cities$ = this.searchTerms.pipe (
      //wait 300ms after each keystroke before considering the term
      debounceTime(300),

      //ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.citiesBreakdownService.searchCities(term))
    )

    this.cities$.subscribe(
      data => this.searchCities = data
    )

  }

  //TODO: check if the data is incorrect and handle it
  handleNewProvince(data) {
    this.selected_province = data;
  }

  //add the search term into the observable stream
  search(term: string): void{
    this.searchTerms.next(term);
  }

}