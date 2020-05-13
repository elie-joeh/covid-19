import { Component, OnInit } from '@angular/core';
import { InfectionBreakdownService } from 'src/app/Services/infection-breakdown.service';
import { CitiesBreakdownService } from 'src/app/Services/cities-breakdown.service';
import { ActivatedRoute } from '@angular/router';
import { Infection_info } from 'src/app/Interfaces/infection-info';
import { City } from 'src/app/Interfaces/city-info';

/*
This component is the wrapper component, which will call all the other components and display them
depending on the defined view.
This component also fetch all the necessary data to be displayed in the view. The data is passed
to the children components using te Input decorator.
*/

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent implements OnInit {

  canada_map_data: any;
  cities_breakdown_data: City[];
  infection_breakdown_data: Infection_info[];
  restrictions_breakdown_data: any;

  constructor(private infectionBreakdownService : InfectionBreakdownService,
    private citiesBreakdownService: CitiesBreakdownService,
    private actr: ActivatedRoute) {
  } 


  ngOnInit(): void {

    let temp_data = [];
    for(let province of this.actr.snapshot.data['provinceInfectionData']) {
      temp_data.push([province.province, province.infected, province.dead])
    }
    this.canada_map_data = temp_data;

    temp_data = [];
    for(let province_data of this.actr.snapshot.data['provinceInfectionData']) {
      const infection_info = <Infection_info> {
        province: province_data.province,
        infected: province_data.infected,
        dead: province_data.dead
      }
      temp_data.push(infection_info);
    }
    this.infection_breakdown_data = temp_data;


    temp_data = [];
    for(let city of this.actr.snapshot.data['citiesInfectionData']) {
      const city_info = <City> {
        name: city.name,
        infected: city.infected,
        dead: city.infected
      }
      temp_data.push(city_info);
    }
    this.cities_breakdown_data = temp_data;
  }

}
