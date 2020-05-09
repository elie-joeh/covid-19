import { Component, OnInit } from '@angular/core';
import { CitiesBreakdownService } from '../../Services/cities-breakdown.service';

@Component({
  selector: 'app-cities-breakdown',
  templateUrl: './cities-breakdown.component.html',
  styleUrls: ['./cities-breakdown.component.sass']
})
export class CitiesBreakdownComponent implements OnInit {

  selected_province: string = 'Quebec';

  constructor(private citiesBreakdownService: CitiesBreakdownService) { }

  ngOnInit(): void {
    this.citiesBreakdownService.selected_province_obs$.subscribe(
      data => this.handleNewProvince(data)
    );
  }

  //TODO: check if the data is incorrect and handle it
  handleNewProvince(data) {
    this.selected_province = data;
  }

}
