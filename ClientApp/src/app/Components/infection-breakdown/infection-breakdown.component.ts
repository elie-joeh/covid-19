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


  chartColumns: any;
  type: any;
  title: any;
  myOptions: any;
  chart: any;
  chartData: any;

  ngOnInit(): void {
    this.sortByInfectionAsc();
    this.isTable = false;
    this.drawChart();
  }
  
  drawChart() {
    this.type = "ColumnChart"
    this.title = "Infection Breakdown";
    this.myOptions = {
      legend: {position: 'bottom'},
      width:  300,
      height: 400,
      backgroundColor: '#808080',
      orientation: 'vertical'
    };
    this.chartColumns = ['Province', 'Infected', 'dead'];

    this.chartData = [];

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
      this.chartData.push([province_name, province.infected, province.dead]);
    }
    
  }
  
  tableClick(): void {
    this.isTable = true;
  }

  chartClick(): void {
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

}