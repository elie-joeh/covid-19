import { Component, OnInit } from '@angular/core';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { ProvinceSelectionService } from 'src/app/Services/province-selection.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CanadaMapComponent } from '../canada-map/canada-map.component';
import { CpiGeneralService } from 'src/app/Services/CPI Services/cpi-general.service';

@Component({
  selector: 'app-economic-breakdown',
  templateUrl: './economic-breakdown.component.html',
  styleUrls: ['./economic-breakdown.component.sass']
})
export class EconomicBreakdownComponent implements OnInit {
  //Data info
  economic_metric: string = 'CPI';
  economic_range: string = 'index';
  selected_provinces: string[] = [];
  all_data: any;

  //global variables
  theme = 'dark';
  title = 'Covid-19 Impact On ' + this.economic_metric;

  //cpi ngx chart components
  cpi_legend: boolean = true;
  cpi_showLabels: boolean = true;
  cpi_animations: boolean = true;
  cpi_xAxis: boolean = true;
  cpi_yAxis: boolean = true;
  cpi_showYAxisLabel: boolean = true;
  cpi_showXAxisLabel: boolean = true;
  cpi_autoScale: boolean = true;
  cpi_xAxisLabel: string = 'Month';
  cpi_yAxisLabel: string = 'Index';
  cpi_timeline: boolean = true;
  cpi_multi: any[];
  cpi_view: any[] = [700, 300];
  cpi_colorScheme = {
    domain: ['#CFC0BB', '#7aa3e5', '#5AA454', '#E44D25', '#a8385d', '#aae3f5']
  };

  cpi_showGridLines: boolean = true;
  cpi_gradient: boolean = true;
  cpi_data_index: any;
  cpi_data_percentage: any;
  cpi_data_year: any;
  cpi_data: any;
  

  constructor(private provinceSelectionService: ProvinceSelectionService,
              private actr: ActivatedRoute,
              private cpiService: CpiGeneralService) { }

  ngOnInit(): void {
      //by default, start with only showing the CA data
      this.selected_provinces = ['CA'];

      //get all data for all provinces, then later on change what should be displayed, to minimize http calls
      let data = this.cpiService.getCPIByPPDG('All-items').subscribe(
        data => {
          this.all_data = data;
          this.handleCPIData(data);
        }
      );
      
      //subscriber that will catch the selected new provinces
      this.provinceSelectionService.selected_province_obs$.subscribe(
        data => this.handleNewProvince(data)
      ); 
  }

  private handleCPIData(data): void {
    let geos = [];

    for(let cpi of data){
      let geoName = cpi.geographyName;
      let flag = 0;
      for(let geo of geos){
        if(geo.name == geoName){
          flag = 1;
          geo.series.push({"name": cpi.reference_date.substring(0, 7), "value": cpi.value});
          break;
        }
      }
        
      if (flag == 0) {
        let geo_unit = {"name": cpi.geographyName, "series": [{"name": cpi.reference_date.substring(0, 7), "value": cpi.value}]};
        geos.push(geo_unit);
      } 
    }

    this.cpi_data_index = geos;
    
    this.populateCPIData(this.cpi_data_index);

  }

  private populateCPIData(data): void {
    let geos = [];

    for(let cpi of data){
      let geoName = cpi.name;
      if (this.selected_provinces.includes(geoName)){
        geos.push(cpi);
      }      
    }
    this.cpi_data = geos;
  }

  /**
   * This method will firstly check if percentage data has been calculated. If not, it will calculate
   * the data and store it in a global variable. Then, in either case, it will modify the data variable
   * to reflect the changes to the user
   */
  monthChange(): void {
    this.economic_range = 'month';
    this.cpi_yAxisLabel = '1-Month % Change';

    if(this.cpi_data_percentage == null) {
      this.cpi_data_percentage = [];
      for(let cpi of this.cpi_data_index) {
        let geoName = cpi.name;
        let index_values = cpi.series;
        let percentages = [];
        for(var i=1; i<index_values.length; i++) {
          var percentage_value = ((index_values[i].value - index_values[i-1].value) / index_values[i].value) * 100;
          var date = index_values[i].name;
          
          percentages.push({"name": date, "value": percentage_value});
        }

        this.cpi_data_percentage.push({"name": geoName, "series": percentages});
      }
    }

    this.populateCPIData(this.cpi_data_percentage);
    
  }


  indexChange(): void {
    this.economic_range = 'index';
    this.cpi_yAxisLabel = 'Index';
    this.populateCPIData(this.cpi_data_index);
  }

  yearChange(): void {
    this.cpi_yAxisLabel = '1-Year % Change';

    if(this.cpi_data_year == null){
      this.cpi_data_year = [];
      for(let cpi of this.cpi_data_index) {
        let geoName = cpi.name;
        let index_values = cpi.series;
        let percentages = [];
        for(var i=index_values.length-1; i>=12; i--) {
          var percentage_value = ((index_values[i-12].value - index_values[i].value) / index_values[i-12].value) * 100;
          var date = index_values[i].name;
          
          percentages.push({"name": date, "value": percentage_value});
        }

        this.cpi_data_year.push({"name": geoName, "series": percentages.reverse()});
      }
    }

    this.populateCPIData(this.cpi_data_year);
  }

  cpiButton(): void {
    this.economic_metric = 'CPI';
    this.updateTitle();
  }

  //TODO: maybe remove this method
  updateTitle(): void{
    this.title = 'Covid Economic Impact On ' + this.economic_metric;
  }

  /*
  In this method, we add or remove the selected province from the array, and then we populate again
  the array of data that will be displayed to the user.
  */
  //TODO: check if the data is incorrect and handle it
  private handleNewProvince(data) {
    data = this.changeNotation(data);

    if(this.selected_provinces.includes(data)){
      const index = this.selected_provinces.indexOf(data, 0);
      if (index > -1){
        this.selected_provinces.splice(index, 1);
      }

    } else {
      this.selected_provinces.push(data);
    }

    if(this.economic_range == "month") {
      this.populateCPIData(this.cpi_data_percentage);
    } else {
      this.populateCPIData(this.cpi_data_index);
    }
    
  }

  //To remove once fetching province data form database in done
  private changeNotation(data){
    if(data=='Quebec'){
      return 'QC';
    } else if(data == 'Ontario'){
      return 'ON';
    } else if(data == 'Alberta'){
      return 'AB';
    } else if(data == 'British Columbia'){
      return 'BC';
    } else if(data == 'Saskatchewan'){
      return 'SK';
    } else if(data == 'Manitoba'){
      return 'MB';
    } else {
      return '';
    }
  }

}
