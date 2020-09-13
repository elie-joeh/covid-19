import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import {InfectionBreakdownService} from '../../Services/infection-breakdown.service'
import { Province } from 'src/app/Interfaces/Province';
import { ProvinceSelectionService } from 'src/app/Services/province-selection.service';

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

  constructor(private provinceSelectionService: ProvinceSelectionService) {
  }

  /*
    This method will redraw the chart so that it justs to the window size when changed
  */
  onResize(event){
    this.drawChart();
  }

  onSelect(e) {
    //if the selection length is 0, this means we are deselecting the previous selection, so we don't update select_province
    if(e.selection.length != 0){
      var row_nb = e.selection[0].row;
      var column_nb = e.selection[0].column;
      
      this.selected_province = this.myData[row_nb][0];
    }    
    this.provinceSelectionService.selected_province.next(this.selected_province);
  }

  ngOnInit(): void {
    this.chart_status = 'infection';
    this.title = "Interactive Map";
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
    
    this.myOptions = {
      region : 'CA',
      displayMode : 'regions',
      resolution : 'provinces',
      backgroundColor: '#404040',
      datalessRegionColor: '#4A4A4A',
      colorAxis: {colors: ['#faebd7', '#ffc8a3', '#d9534f']},
      legend: {textStyle: {bold: true}},
      keepAspectRatio: true
    };

  }

  selectHandler(e) {
    console.log('select handlerrrrr');
  }

}