import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import {InfectionBreakdownService} from '../../Services/infection-breakdown.service'
import {CitiesBreakdownService} from '../../Services/cities-breakdown.service'
import { Infection_info } from 'src/app/Interfaces/infection-info';

@Component({
  selector: 'app-canada-map',
  templateUrl: './canada-map.component.html',
  styleUrls: ['./canada-map.component.sass']
})
export class CanadaMapComponent implements OnInit {

  @Input() myData : any;
  @Output() uploaded = new EventEmitter<string>();
  @Input() chartColumns: any;

  type : any;
  title : any;
  myOptions : any;
  chart : any;
  
  selected_province: any;

  private chart_status: string;

  constructor(private infectionBreakdownService : InfectionBreakdownService,
              private citiesBreakdownService: CitiesBreakdownService) {
  }

  /*
    This method will redraw the chart so that it justs to the window size when changed
  */
  onResize(event){
    this.drawChart();
  }

  onSelect(e) {
    var row_nb = e.selection[0].row;
    var column_nb = e.selection[0].column;
    
    this.selected_province = this.myData[row_nb][0];
    
    this.infectionBreakdownService.selected_province.next(this.selected_province);
    this.citiesBreakdownService.selected_province.next(this.selected_province);
  }

  ngOnInit(): void {
    this.chart_status = 'infection';
    this.drawChart();
  }


  infectionButton() {
    if(this.chart_status != 'infection'){
      this.chart_status = 'infection';
      this.uploaded.emit('infection');
    }
  }

  deadButton() {
    if(this.chart_status != 'dead') {
      this.chart_status  = 'dead';
      this.uploaded.emit('dead');
    }
  }

  drawChart() {
    this.type = "GeoChart"
    this.title = "Canada Map";
    this.myOptions = {
      region : 'CA',
      displayMode : 'regions',
      resolution : 'provinces'
    };
    
    this.myOptions = {
      region : 'CA',
      displayMode : 'regions',
      resolution : 'provinces',
      backgroundColor: '#252525',
      datalessRegionColor: '#4A4A4A',
      colorAxis: {colors: ['#faebd7', '#ffc8a3', '#d9534f']}
    };

  }

  selectHandler(e) {
    console.log('select handlerrrrr');
  }

}
