import { Component, OnInit, ViewChild } from '@angular/core';
import {InfectionBreakdownService} from '../infection-breakdown.service'

@Component({
  selector: 'app-canada-map',
  templateUrl: './canada-map.component.html',
  styleUrls: ['./canada-map.component.sass']
})
export class CanadaMapComponent implements OnInit {

  type : any;
  title : any;
  chartColumns : any;
  myData : any;
  myOptions : any;
  chart : any;

  selected_province: any;

  constructor(private infectionBreakdownService : InfectionBreakdownService) {
  }

  /*
    This method will redraw the chart so that it justs to the window size when changed
  */
  onResize(event){
    this.drawChart()
  }

  onSelect(e) {
    var row_nb = e.selection[0].row;
    var column_nb = e.selection[0].column;
    
    this.selected_province = this.myData[row_nb][0];
    
    this.infectionBreakdownService.selected_province.next(this.selected_province);
    console.log(this.selected_province)
  }

  ngOnInit(): void { 
    this.drawChart();
  }

  drawChart() {
    this.type = "GeoChart"
    this.title = "Canada Map";
    this.myOptions = {
      region : 'CA',
      displayMode : 'regions',
      resolution : 'provinces'
    };

    this.chartColumns = ['Province', 'Infected', 'Dead'];
    this.myData = [
      ['Quebec', 8136000, 12323],
      ['Ontario', 8538000, 12323],
      ['British Columbia', 2244000, 12323],
      ['Alberta', 3470000, 12323],
      ['Prince Edward Island', 19500000, 12323],
      ['Manitoba', 299292, 12323],
      ['Nova Scotia', 3388383, 12323],
      ['New Brunswick',3344343, 12323],
      ['Newfoundland and Labrador',34343, 12323],
      ['Saskatchewan', 325545, 12323],
      ['Nunavut', 343434, 12323],
      ['Yukon', 234678, 12323],
      ['Northwest Territories', 3243242, 12323]
    ];

    this.myOptions = {
      region : 'CA',
      displayMode : 'regions',
      resolution : 'provinces'
    };
  }

  selectHandler(e) {
    console.log('select handlerrrrr');
  }

}
