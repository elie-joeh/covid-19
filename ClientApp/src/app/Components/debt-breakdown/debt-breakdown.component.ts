import { Component, OnInit, Input } from '@angular/core';
import { DebtGeneralService } from 'src/app/Services/Debt Services/debt-general.service';
import { GdpGeneralService } from 'src/app/Services/GDP Services/gdp-general.service';

@Component({
  selector: 'app-debt-breakdown',
  templateUrl: './debt-breakdown.component.html',
  styleUrls: ['./debt-breakdown.component.sass']
})
export class DebtBreakdownComponent implements OnInit {

  //data
  private readonly base_date = new Date("2019-10-01");
  private debt_all_data: any;
  private debt_data: any;
  private gross_debt_data: any;
  private debt_1month_data: any;
  private debt_12month_data: any;
  private gdp_all_data: any;
  private gdp_data: any;
  private gdp_1month_data: any;
  private gdp_12month_data: any;

  debt_show = true;
  gdp_show = false;
  ratio_show = false;
  
  line_chart_data: any;

  //global variables
  theme = 'dark';
  title = 'Covid-19 Impact On Debt';

  //cpi ngx chart components
  debt_legend: boolean = true;
  debt_showLabels: boolean = true;
  debt_animations: boolean = true;
  debt_xAxis: boolean = true;
  debt_yAxis: boolean = true;
  debt_showYAxisLabel: boolean = true;
  debt_showXAxisLabel: boolean = true;
  debt_autoScale: boolean = true;
  debt_xAxisLabel: string = 'Month';
  debt_yAxisLabel: string = 'Net Debt';
  debt_timeline: boolean = true;
  debt_multi: any[];
  debt_view: any[] = [700, 300];
  debt_colorScheme = {
    domain: ['#E44D25', '#7aa3e5', '#5AA454', '#CFC0BB', '#a8385d', '#aae3f5']
  };
  debt_showGridLines: boolean = true;
  debt_gradient: boolean = true;

  //tootip information (information about data)
  readonly debt_meta_info = "\u2022 Dollar chained 2012 \n\u2022 Values in thousands of dollars";
  readonly gdp_meta_info = "\u2022 Dollar chained 2012 \n\u2022 Seasonally adjusted at annual rates \n\u2022 Values in millions of dollars";
 
  constructor(private debtService: DebtGeneralService,
              private gdpService: GdpGeneralService) { }

  ngOnInit(): void {
    this.debtService.getAllNetDebt().subscribe(
      data => {
        this.handleDebtData(data);
      }
    )

  }

  private handleDebtData(data){
    this.debt_all_data = data;
    let debt_by_geo = [];
    debt_by_geo.push({"name": "CA", "series": []});

    for(let debt of data) {
      let date = new Date(debt.reference_date);
      if(date > this.base_date && debt.value != null){
        let unit = {"name": debt.reference_date.substring(0, 7), "value": debt.value};
        debt_by_geo[0].series.push(unit);
      }
    }

    this.debt_data = debt_by_geo;
    this.line_chart_data = debt_by_geo;
  }

  private handleGDPData(data) {
    this.gdp_all_data = data;
    let gdp_by_geo = [];
    gdp_by_geo.push({"name": "CA", "series": []});

    for(let gdp of data){
      let data = new Date(gdp.reference_date);
      if(data > this.base_date) {
        let unit = {"name": gdp.reference_date.substring(0, 7), "value": gdp.value};
        gdp_by_geo[0].series.push(unit);
      }
    }

    this.gdp_data = gdp_by_geo;
    this.line_chart_data = gdp_by_geo;
  }

  private handleRatioData() {
    var ratio_values = [];
    ratio_values.push({"name": "CA", "series": []});
    
    ratio_values[0].series = this.calculateRatio().reverse();
 
    this.line_chart_data = ratio_values;
  }

  private calculateRatio(){
    var ratio_values = [];

    var debt_index = this.debt_all_data.length - 1;
    var gdp_index = this.gdp_all_data.length - 1;

    var debt_latest_date = this.debt_all_data[debt_index].reference_date;
    var gdp_latest_date = this.gdp_all_data[gdp_index].reference_date;

    if(debt_latest_date != gdp_latest_date) {
      if(debt_latest_date < gdp_latest_date) {
        while(debt_latest_date != gdp_latest_date) {
          gdp_latest_date = this.gdp_all_data[--gdp_index].reference_date;
        }
      } else {
        while(debt_latest_date != gdp_latest_date) {
          debt_latest_date = this.debt_all_data[--debt_index].reference_date;
        }
      }
    }
    
    var stop_date = new Date(debt_latest_date);

    while(stop_date > this.base_date) {
      var gdp = this.gdp_all_data[gdp_index].value;
      var debt = this.debt_all_data[debt_index].value;

      if(gdp == null || debt == null) {
        --gdp_index;
        --debt_index;
        stop_date = new Date(this.debt_all_data[debt_index].reference_date);
        continue;
      }

      var percentage = ((debt / gdp) * 100).toFixed(2);
      let unit = {"name": this.debt_all_data[debt_index].reference_date.substring(0, 7), "value": percentage};
      ratio_values.push(unit);
      --gdp_index;
      --debt_index;
      stop_date = new Date(this.debt_all_data[debt_index].reference_date);
    }

    return ratio_values;
  }

  debtButton(): void {
    this.debt_show = true;
    this.gdp_show = false;
    this.ratio_show = false;
    this.debt_yAxisLabel = "Net Debt";
    this.title = "Covid-19 Impact On Debt";
    this.line_chart_data = this.debt_data;
  }

  gdpButton(): void {
    this.debt_show = false;
    this.gdp_show = true;
    this.ratio_show = false;
    this.title = "Covid-19 Impact On GDP";

    this.debt_yAxisLabel = "Real GDP";
    if(this.gdp_all_data == null || this.gdp_data == null){
      this.gdpService.getGDPAllIndustry().subscribe(
        data => {
          this.handleGDPData(data);
        }
      );
    } else {
      this.line_chart_data = this.gdp_data;
    }
    
  }

  gdpDebtButton(): void {
    this.debt_show = false;
    this.gdp_show = false;
    this.ratio_show = true;
    this.title = "Covid-19 Impact on Net-Debt/GDP Ratio";

    this.debt_yAxisLabel = "Net-Debt to GDP Ratio";
    if(this.gdp_all_data == null || this.gdp_data == null) {
      this.gdpService.getGDPAllIndustry().subscribe(
        data => {
          this.handleGDPData(data);
          this.handleRatioData();
        }
      );
    } else {
      this.handleRatioData();
    }
  }

  valueBttn(): void {
    if(this.debt_show) {
      this.debt_yAxisLabel = "Net Debt";
      this.line_chart_data = this.debt_data;
    } else if(this.gdp_show) {
      this.debt_yAxisLabel = "Real GDP";
      this.line_chart_data = this.gdp_data;
    }
  }

  monthChangeBttn(): void {
    if(this.debt_show) {
      this.debt_yAxisLabel = "Net Debt 1-month Change";
      
      var index = this.debt_all_data.length - 1;
      var stop_date = new Date(this.debt_all_data[index].reference_date);
      var debt = [];
      debt.push({"name": "CA", "series": []});

      while(stop_date > this.base_date){
        var debt1 = this.debt_all_data[index].value;
        var debt2 = this.debt_all_data[index - 1].value;
        if(debt1 == null || debt2 == null) {
          --index;
          stop_date = new Date(this.debt_all_data[index].reference_date);
          continue;
        }
        var percentage = (((debt1 - debt2) / debt2) * 100).toFixed(2);

        let unit = {"name": this.debt_all_data[index].reference_date.substring(0, 7), "value": percentage};
        debt[0].series.push(unit);
        --index;
        stop_date = new Date(this.debt_all_data[index].reference_date);
      }
      debt[0].series = debt[0].series.reverse();
      this.debt_1month_data,this.line_chart_data = debt;
      
    } else if(this.gdp_show) {
      this.debt_yAxisLabel = "Real GDP 1-month Change";
      var length = this.gdp_all_data.length;
      var gdp = [];
      gdp.push({"name": "CA", "series": []});

      for(let i=length-1; i>length-6; i--){
        var gdp1 = this.gdp_all_data[i].value;
        var gdp2 = this.gdp_all_data[i-1].value;
        var percentage = (((gdp1 - gdp2) / gdp2) *100).toFixed(2);

        let unit = {"name": this.gdp_all_data[i].reference_date.substring(0, 7), "value": percentage};
        gdp[0].series.push(unit);
      }
      gdp[0].series = gdp[0].series.reverse();
      this.gdp_1month_data, this.line_chart_data = gdp;
    } 
  }

  yearChangeBttn(): void {
    if(this.debt_show){
      this.debt_yAxisLabel = "Net Debt 12-month Change";
      
      var index = this.debt_all_data.length - 1;
      var stop_date = new Date(this.debt_all_data[index].reference_date);
      var debt = [];
      debt.push({"name": "CA", "series": []});

      while(stop_date > this.base_date){
        var debt1 = this.debt_all_data[index].value;
        var debt2 = this.debt_all_data[index - 12].value;
        if(debt1 == null || debt2 == null) {
          --index;
          stop_date = new Date(this.debt_all_data[index].reference_date);
          continue;
        }
        var percentage = (((debt1 - debt2) / debt2) * 100).toFixed(2);

        let unit = {"name": this.debt_all_data[index].reference_date.substring(0, 7), "value": percentage};
        debt[0].series.push(unit);
        --index;
        stop_date = new Date(this.debt_all_data[index].reference_date);
      }
      debt[0].series = debt[0].series.reverse();
      this.debt_12month_data, this.line_chart_data = debt;
      
    } else if(this.gdp_show){
      this.debt_yAxisLabel = "Real GDP 12-month Change";

      var length = this.gdp_all_data.length;
      var gdp = [];
      gdp.push({"name": "CA", "series": []});

      for(let i = length-1; i>length-6; i--){
        var gdp1 = this.gdp_all_data[i].value;
        var gdp2 = this.gdp_all_data[i-12].value;
        console.log(this.gdp_all_data[i]);
        console.log(this.gdp_all_data[i-12]);
        console.log("===============");
        var percentage = (((gdp1 - gdp2) / gdp2) * 100).toFixed(2);
        
        let unit = {"name": this.gdp_all_data[i].reference_date.substring(0, 7), "value": percentage};
        gdp[0].series.push(unit);
      }
      gdp[0].series = gdp[0].series.reverse();
      this.gdp_12month_data, this.line_chart_data = gdp;
    }
  }

}
