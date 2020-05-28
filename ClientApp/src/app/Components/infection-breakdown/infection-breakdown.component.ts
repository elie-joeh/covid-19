import { Component, OnInit, Input, ErrorHandler } from '@angular/core';
import { Province } from '../../Interfaces/Province';

@Component({
  selector: 'app-infection-breakdown',
  templateUrl: './infection-breakdown.component.html',
  styleUrls: ['./infection-breakdown.component.sass']
})
export class InfectionBreakdownComponent implements OnInit {

  constructor() { }

  @Input() all_infection_info : Province[];
  isTable: boolean;
  isInfected: boolean;

  //data for infected google chart
  infectedColumns: any;
  type: any;
  infectedTitle: any;
  infectedOptions: any;
  infectedData: any;

  //data for dead google chart
  deadColumns: any;
  deadTitle: any;
  deadOptions: any;
  deadData: any;

  ngOnInit(): void {
    this.sortByInfectionAsc();
    this.isTable = false;
    this.isInfected = true;
    this.drawInfectedChart();
  }
  
  tableClick(): void {
    this.isTable = true;
    this.isInfected = false;
  }

  infectedClick(): void {
    this.isTable = false;
    this.isInfected = true;
  }

  deadClick(): void {
    this.isInfected = false;
    this.isTable = false;
  }

  sortByInfectionDesc(){
    let temp_data = [];
    for(let infection_data of this.all_infection_info) {
      temp_data.push([infection_data.infected, infection_data]);
    }

    temp_data.sort(function(a, b) {
      return a[0]-b[0];  
    })

    let sorted_data = [];
    for(let data of temp_data) {
      sorted_data.push(data[1]);
    }

    this.all_infection_info = sorted_data;
  }
  

  sortByInfectionAsc(){
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

  drawInfectedChart() {
    this.type = "ColumnChart"
    this.infectedTitle = "Infection Breakdown";
    this.infectedOptions = {
      legend: {position: 'bottom'},
      bar: {groupWidth: '50%'},
      bars: 'horizontal',
      chartArea: {left: 25, top: 15, width: '90%', height: '80%'},
      backgroundColor: '#808080',
      orientation: 'vertical'
    };
    this.infectedColumns = ['Province', 'Infected'];

    this.infectedData = [];

    for (var province of this.all_infection_info) {
      var province_name = "";
      switch(province.name){
        case "Quebec": {
          province_name = "QC";
          break;
        }
        case "Ontario": {
          province_name = "ON";
          break;
        }
        case "British Columbia": {
          province_name = "BC";
          break;
        }
        case "Alberta": {
          province_name = "AB";
          break;
        }
        case "Manitoba": {
          province_name = "MB";
          break;
        }
        case "Saskatchewan": {
          province_name = "SK";
          break;
        }
        case "Nova Scotia": {
          province_name = "NS";
          break;
        }
        case "New Brunswick": {
          province_name = "NB";
          break;
        }
        case "Newfoundland and Labrador": {
          province_name = "NL";
          break;
        }
        case "Prince Edward Island": {
          province_name = "PE";
          break;
        }
        case "Yukon": {
          province_name = "YT";
          break;
        }
        case "Northwest Territories": {
          province_name = "NT";
          break;
        }
        case "Nunavut": {
          province_name = "NU";
          break;
        }
      };
      this.infectedData.push([province_name, province.infected]);
    }
    
  }

}