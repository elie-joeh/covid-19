import { Component, OnInit } from '@angular/core';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { ProvinceSelectionService } from 'src/app/Services/province-selection.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-economic-breakdown',
  templateUrl: './economic-breakdown.component.html',
  styleUrls: ['./economic-breakdown.component.sass']
})
export class EconomicBreakdownComponent implements OnInit {
  //Data info
  economic_metric: string = 'CPI';
  economic_range: string = 'month';
  selected_province: string = 'Quebec';

  //global variables
  theme = 'dark';
  title = 'Covid-19 Impact On ' + this.economic_metric + ' in ' + this.selected_province;

  //cpi ngx chart components
  cpi_legend: boolean = true;
  cpi_showLabels: boolean = true;
  cpi_animations: boolean = true;
  cpi_xAxis: boolean = true;
  cpi_yAxis: boolean = true;
  cpi_showYAxisLabel: boolean = true;
  cpi_showXAxisLabel: boolean = true;
  cpi_xAxisLabel: string = 'Month';
  cpi_yAxisLabel: string = '1-month % change';
  cpi_timeline: boolean = true;
  cpi_multi: any[];
  cpi_view: any[] = [700, 300];
  cpi_colorScheme = {
    domain: ['#7aa3e5', '#5AA454', '#E44D25', '#CFC0BB', '#a8385d', '#aae3f5']
  };

  cpi_showGridLines: boolean = true;
  cpi_gradient: boolean = true;

  constructor(private provinceSelectionService: ProvinceSelectionService,
              private actr: ActivatedRoute) { }

  ngOnInit(): void {
      this.provinceSelectionService.selected_province_obs$.subscribe(
        data => this.handleNewProvince(data)
      );
  
  }

  monthChange(): void {
    this.economic_range = 'month';
    this.cpi_yAxisLabel = '1-month % change';
  }

  yearChange(): void {
    this.economic_range = 'year';
    this.cpi_yAxisLabel = '12-month % change';
  }

  indexChange(): void {
    this.economic_range = 'index';
    this.cpi_yAxisLabel = 'Index';
  }

  cpiButton(): void {
    this.economic_metric = 'CPI';
    this.updateTitle();
  }

  employmentButton(): void{
    this.economic_metric = 'Employment';
    this.updateTitle();
  }

  retailButton(): void{
    this.economic_metric = 'Retail';
    this.updateTitle();
  }

  updateTitle(): void{
    this.title = 'Covid Economic Impact On ' + this.economic_metric + ' in ' + this.selected_province;
  }

  //TODO: check if the data is incorrect and handle it
  handleNewProvince(data) {
    this.selected_province = data;
    this.title = 'Covid Economic Impact On ' + this.economic_metric + ' in ' + data;
  }

  cpi_data = [
    {
      "name": "Quebec",
      "series": [
        {
          "name": "Jan 2019",
          "value": 0.1
        },
        {
          "name": "Fev 2019",
          "value": 0.7
        },
        {
          "name": "Mar 2019",
          "value": 0.7
        },
        {
          "name": "Apr 2019",
          "value": 0.4
        },
        {
          "name": "May 2019",
          "value": 0.4
        },
        {
          "name": "Jun 2019",
          "value": -0.2
        },
        {
          "name": "Jul 2019",
          "value": 0.5
        },
        {
          "name": "Aug 2019",
          "value": -0.1
        },
        {
          "name": "Sep 2019",
          "value": -0.4
        },
        {
          "name": "Oct 2019",
          "value": 0.3
        },
        {
          "name": "Nov 2019",
          "value": -0.1
        },
        {
          "name": "Dec 2019",
          "value": 0
        },
        {
          "name": "Jan 2020",
          "value": 0.3
        },
        {
          "name": "Feb 2020",
          "value": 0.4
        },
        {
          "name": "Mar 2020",
          "value": -0.6
        },
        {
          "name": "Apr 2020",
          "value": -0.7
        }
      ]
    },
    {
      "name": "Ontario",
      "series": [
        {
          "name": "Jan 2019",
          "value": 0.2
        },
        {
          "name": "Fev 2019",
          "value": 0.3
        },
        {
          "name": "Mar 2019",
          "value": 0.4
        },
        {
          "name": "Apr 2019",
          "value": 0.1
        },
        {
          "name": "May 2019",
          "value": 0.5
        },
        {
          "name": "Jun 2019",
          "value": -0.3
        },
        {
          "name": "Jul 2019",
          "value": 0.4
        },
        {
          "name": "Aug 2019",
          "value": -0.1
        },
        {
          "name": "Sep 2019",
          "value": -0.6
        },
        {
          "name": "Oct 2019",
          "value": 0.2
        },
        {
          "name": "Nov 2019",
          "value": -0.2
        },
        {
          "name": "Dec 2019",
          "value": 0
        },
        {
          "name": "Jan 2020",
          "value": 0.3
        },
        {
          "name": "Feb 2020",
          "value": 0.5
        },
        {
          "name": "Mar 2020",
          "value": -0.6
        },
        {
          "name": "Apr 2020",
          "value": -0.8
        }
      ]
    },

  
  
  
  
  ];

}
