import { Component, OnInit, Input, ErrorHandler } from '@angular/core';
import { Infection_info } from '../../Interfaces/infection-info';

@Component({
  selector: 'app-infection-breakdown',
  templateUrl: './infection-breakdown.component.html',
  styleUrls: ['./infection-breakdown.component.sass']
})
export class InfectionBreakdownComponent implements OnInit {

  constructor() { }

  @Input() all_infection_info : Infection_info[];

  ngOnInit(): void {
    this.sortByInfection();
  }

  sortByInfection(){
    let temp_data = [];
    for(let infection_data of this.all_infection_info) {
      temp_data.push([infection_data.infected, infection_data]);
    }

    temp_data.sort(function(a, b) {
      return b[0]-a[0];  
    })

    let sorted_data = [];
    for(let data of temp_data) {
      sorted_data.push(data[1]);
    }

    this.all_infection_info = sorted_data;
  }

}
