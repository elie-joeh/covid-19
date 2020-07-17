import { Component, OnInit } from '@angular/core';
import { SalesGeneralService } from 'src/app/Services/Sales Services/sales-general.service';
import { ProvinceSelectionService } from 'src/app/Services/province-selection.service';


@Component({
  selector: 'app-sales-breakdown',
  templateUrl: './sales-breakdown.component.html',
  styleUrls: ['./sales-breakdown.component.sass']
})
export class SalesBreakdownComponent implements OnInit {
  //vectorids for retail sales
  nu_vid = "v52367364";
  nt_vid = "v52367334";
  yk_vid = "v52367304";
  bc_vid = "v52367245";
  ab_vid = "v52367215";
  sk_vid = "v52367185";
  mt_vid = "v52367155";
  on_vid = "v52367573";
  qc_vid = "v52367514";
  nb_vid = "v52367484";
  ns_vid = "v52367454";
  pe_vid = "v52367424";
  nl_vid = "v52367394";
  ca_vid = "v52367097";

  //vector ids for manufacturing sales
  manu_sales_vid = "v800450";
  manu_inventory_sales_vid = "v803265";

  //general
  title = "Impact of Covid-19 on Retail Sales";
  theme = 'dark';
  selected_provinces: string[];

  //line chart configuration
  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  autoScale: boolean = true;
  xAxisLabel: string = 'Month';
  yAxisLabel: string = 'Retail Sales';
  timeline: boolean = true;
  multi: any[];
  view: any[] = [700, 300];
  colorScheme = {
    domain: ['#5AA454', '#7aa3e5', '#E44D25', '#CFC0BB', '#a8385d', '#aae3f5']
  };
  showGridLines: boolean = true;
  gradient: boolean = true;

  //manufacturing data
  manufacturing_sales = [];
  manufacturing_show = false;
  manufacturing_sales_month = [];
  manufacturing_sales_year = [];
 
  //retail data
  retail_by_province = [];
  retail_by_province_month = [];
  retail_by_province_year = [];
  retail_value = true;
  retail_month = false;
  retail_year = false;
  retail_show = true;
  
  //graph data
  line_chart_data = [];

  constructor(private salesService: SalesGeneralService,
              private provinceSelectionService: ProvinceSelectionService) { }

  ngOnInit(): void {
    this.selected_provinces = ['CA'];
    var vector_ids = this.ca_vid + "," + this.nl_vid + "," + this.pe_vid + "," + this.ns_vid + "," + this.nb_vid + "," + this.qc_vid + "," + this.on_vid + "," + this.mt_vid + "," + this.sk_vid + "," + this.ab_vid + "," + this.bc_vid + "," + this.yk_vid + "," + this.nt_vid + "," + this.nu_vid;
    this.salesService.getRetailsByVectors(vector_ids).subscribe(
      data => {
        this.retail_by_province = this.handleRetailData(data);
        this.populateRetailData(this.retail_by_province);
      }
    );

    //subscriber that will catch the selected new provinces
    this.provinceSelectionService.selected_province_obs$.subscribe(
      data => this.handleNewProvince(data)
    ); 
  }

  private populateRetailData(data) {
    var result = [];
    for(let retail of data) {
      let geoName = retail.name;
      if(this.selected_provinces.includes(geoName)){
        result.push(retail);
      } 
    }

    this.line_chart_data = result;
  }

  private handleRetailData(data) {
    let retail_by_geo = [];

    for(let retail of data) {
      let geoName = retail.geography_name;
      let flag = 0;
      for(let geo of retail_by_geo){
        if(geo.name == geoName){
          flag = 1;
          geo.series.push({"name": retail.reference_date.substring(0, 7), "value": retail.value});
          break;
        }
      }
        
      if (flag == 0) {
        let geo_unit = {"name": retail.geography_name, "series": [{"name": retail.reference_date.substring(0, 7), "value": retail.value}]};
        retail_by_geo.push(geo_unit);
      }
    }

    return retail_by_geo;
  }

  private handleNewProvince(data) {
    data = this.changeNotation(data);

    if(this.selected_provinces.includes(data)){
      const index = this.selected_provinces.indexOf(data, 0);
      if (index > -1){
        this.selected_provinces.splice(index, 1);
      }

      if(this.selected_provinces.length == 0) {
        this.selected_provinces.push('CA');
      }
    } else {
      var ca = this.selected_provinces.indexOf('CA', 0);
      if(ca > -1){
        this.selected_provinces.splice(ca, 1);
      }
      this.selected_provinces.push(data);
    }

    if(this.retail_value){
      this.populateRetailData(this.retail_by_province);
    } else if(this.retail_month){
      this.populateRetailData(this.retail_by_province_month);
    } else if(this.retail_year){
      this.populateRetailData(this.retail_by_province_year);
    }
    
  }

  private handleManuData(data) {
    var sales = [];
    sales.push({"name" : "CA", "series" : []});

    for(let sale of data) {
      sales[0].series.push({"name" : sale.reference_date.substring(0, 7), "value": sale.value});
    }

    this.line_chart_data = sales;
    this.manufacturing_sales = sales;
  }

  retailButton(){
    this.yAxisLabel = "Retail sales";
    this.manufacturing_show = false;
    this.retail_show = true;

    if(this.retail_value){
      this.populateRetailData(this.retail_by_province);
    } else if(this.retail_month){
      this.populateRetailData(this.retail_by_province_month);
    } else if(this.retail_year){
      this.populateRetailData(this.retail_by_province_year);
    }
  }

  manufacturingButton() {
    this.yAxisLabel = "Manufacturing Sales";
    this.manufacturing_show = true;
    this.retail_show = false;
    if(this.manufacturing_sales.length < 1){
      this.salesService.getManufacturingsByVectors(this.manu_sales_vid).subscribe(
        data => {
          this.handleManuData(data);
        }
      )
    } else {
      this.line_chart_data = this.manufacturing_sales;
    }
    
  }

  valueRetailChange() {
    this.yAxisLabel = 'Retail Sales';
    this.retail_month = false;
    this.retail_value = true;
    this.retail_year = false;
    this.populateRetailData(this.retail_by_province);
  }

  oneMonthRetailChange() {
    this.yAxisLabel = "Retail Sales 1-month Change";
    this.retail_month = true;
    this.retail_value = false;
    this.retail_year = false;
    var result = [];

    if(this.retail_by_province_month.length < 1){
      for(let retail of this.retail_by_province) {
        var geo_name = retail.name;
        var series = retail.series;
        var new_series = [];
        for(var i=0; i<series.length - 1; i++) {
          var retail1 = series[i].value;
          var retail2 = series[i+1].value;
          var percentage = (((retail2 - retail1) / retail1) * 100).toFixed(2);
          
          new_series.push({"name": series[i+1].name.substring(0, 7), "value": percentage});
        }
        result.push({"name": geo_name, "series": new_series});
      }
      this.retail_by_province_month = result;
    }

    this.populateRetailData(this.retail_by_province_month);
  }

  oneYearRetailChange() {
    this.yAxisLabel = "Retail Sales 1-year Change";
    this.retail_month = false;
    this.retail_value = false;
    this.retail_year = true;
    var result = [];

    if(this.retail_by_province_year.length < 1) {
      for(let retail of this.retail_by_province) {
        var geo_name = retail.name;
        var series = retail.series;
        var new_series = [];
        for(var i=series.length - 1; i>=12; i--){
          var retail1 = series[i].value;
          var retail2 = series[i-12].value;
          var percentage = (((retail1 - retail2) / retail2) * 100).toFixed(2);

          new_series.push({"name": series[i].name.substring(0, 7), "value": percentage})
        }
        result.push({"name": geo_name, "series": new_series.reverse()});
      }
      this.retail_by_province_year = result;
    } 
    this.populateRetailData(this.retail_by_province_year);
  }

  valueManufacturingChange(){
    this.line_chart_data = this.manufacturing_sales;
  }

  oneMonthManufacturingChange(){
    if(this.manufacturing_sales_month.length < 1) {
      var month_change = [];
      var series = this.manufacturing_sales[0].series;
      var len = series.length;

      for(let i=0; i<len-1; i++) {
        var sale1 = series[i].value;
        var sale2 = series[i+1].value;
        var percentage = (((sale2 - sale1) / sale1) * 100).toFixed(2);

        month_change.push({"name": series[i+1].name, "value": percentage});
      }

      this.manufacturing_sales_month.push({"name": "CA", "series": month_change});
      this.line_chart_data = this.manufacturing_sales_month;
    } else {
      this.line_chart_data = this.manufacturing_sales_month;
    }
  }

  oneYearManufacturingChange(){
    if(this.manufacturing_sales_year.length < 1){
      var year_change = [];
      var series = this.manufacturing_sales[0].series;
      var len = series.length;
      
      for(let i=len-1; i>=12; i--){
        var sale1 = series[i].value;
        var sale2 = series[i-12].value;
        var percentage = (((sale1 - sale2)/ sale1) * 100).toFixed(2);

        year_change.push({"name": series[i].name, "value": percentage});
      }

      this.manufacturing_sales_year.push({"name": "CA", "series": year_change.reverse()});
      console.log(this.manufacturing_sales_year);
      this.line_chart_data = this.manufacturing_sales_year;
    } else {
      this.line_chart_data = this.manufacturing_sales_year;
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
