import { Component, OnInit } from '@angular/core';
import { ProvinceSelectionService } from 'src/app/Services/province-selection.service';
import { EmploymentService } from 'src/app/Services/Employment Services/employment.service';

@Component({
  selector: 'app-employment-breakdown',
  templateUrl: './employment-breakdown.component.html',
  styleUrls: ['./employment-breakdown.component.sass']
})
export class EmploymentBreakdownComponent implements OnInit {
  //global variables
  theme = 'dark';
  title = 'Covid-19 Impact On Employment';

  //Data info
  readonly employment_meta_info = "\u2022 Seasonally adjusted \n\u2022 Values in thousands";
  rate_button: boolean = true;
  sex_button: boolean = false;
  age_button: boolean = false;
  line_graph: boolean = true;
  bar_graph: boolean = false;
  all_ages: boolean = true;
  sex: number = 0;
  group: number = 0;
  lfc: number = 6;
  selected_provinces: string[] = [];
  selected_province: string;
  employment_lfc: any;
  employment_by_province: any;
  employment_user_data: any;
  
  employment_by_male: any;
  employment_by_female: any;
  employment_sex_province: any;
  employment_age_province: any;


  //cpi ngx chart components
  employment_legend: boolean = true;
  employment_showLabels: boolean = true;
  employment_animations: boolean = true;
  employment_xAxis: boolean = true;
  employment_yAxis: boolean = true;
  employment_showYAxisLabel: boolean = true;
  employment_showXAxisLabel: boolean = true;
  employment_autoScale: boolean = true;
  employment_xAxisLabel: string = 'Month';
  employment_yAxisLabel: string = 'Unemployment Rate';
  employment_timeline: boolean = true;
  employment_multi: any[];
  employment_view: any[] = [700, 300];
  employment_colorScheme = {
    domain: ['#7aa3e5', '#5AA454', '#E44D25', '#CFC0BB', '#a8385d', '#aae3f5']
  };
  employment_showGridLines: boolean = true;
  employment_gradient: boolean = true;

  constructor(private provinceSelectionService: ProvinceSelectionService,
              private employmentService: EmploymentService) { }

  ngOnInit(): void {
    //by default, start with only showing the CA data
    this.selected_provinces = ['CA'];
    this.selected_province = 'CA';
    this.rate_button = true;

    let data = this.employmentService.getEmploymentBySexGroup(this.sex, this.group).subscribe(
      data => {
        this.employment_lfc = data;
        var new_data = this.groupByProvince(data);
        this.employment_by_province = new_data;
        this.populateEmploymentData(new_data);
      }
    )

    //subscriber that will catch the selected new provinces
    this.provinceSelectionService.selected_province_obs$.subscribe(
      data => this.handleNewProvince(data)
    ); 
  }

  private populateEmploymentData(data) {
    let temp = [];

    for(let empl of data){
      let geoName = empl.name;

      if (this.selected_provinces.includes(geoName)){
        temp.push(empl);
      }      
    }

    this.employment_user_data = temp;
  }


  private groupByProvince(data) {
    let geos = [];

    for(let empl of data) {
      let geoName = empl.geoName;
      let lfc = empl.lfc;
      let flag = 0;
      for(let geo of geos){
        if(geo.name == geoName && lfc==this.lfc){
          flag = 1;
          geo.series.push({"name": empl.referenceDate.substring(0, 7), "value": empl.value});
          break;
        }
      }
        
      if (flag == 0) {
        if (lfc == this.lfc) {
          let geo_unit = {"name": empl.geoName, "series": [{"name": empl.referenceDate.substring(0, 7), "value": empl.value}]};
          geos.push(geo_unit);
        }
      }
    }

    return geos;
  }

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

    if(this.sex_button && !this.bar_graph){
      if(data == this.selected_province) {
        this.selected_province = 'CA';
        this.populateSexData(this.employment_sex_province);
      } else {
        this.selected_province = data;
        this.populateSexData(this.employment_sex_province, data);
      }
    }

    if(this.age_button && !this.bar_graph){
      if(this.all_ages){
        if(data == this.selected_province) {
          this.selected_province = 'CA';
          this.populateAgeData(this.employment_age_province);
        } else {
          this.selected_province = data;
          this.populateAgeData(this.employment_age_province, data);
        }
      } else {
        this.populateSpecificAgeData();
      }
      
    }

    if(this.rate_button) {
      this.populateEmploymentData(this.employment_by_province);
    } else if(this.bar_graph) {
      this.populatecurrentSexData(this.employment_sex_province);
    }
  }


  rateButton(): void {
    this.lfc = 6;
    this.employment_yAxisLabel = "Unemployment Rate";
    var new_data = this.groupByProvince(this.employment_lfc);
    this.populateEmploymentData(new_data);
  }

  numberButton(): void {
    this.lfc = 5;
    this.employment_yAxisLabel = "Unemployment Numbers";
    var new_data = this.groupByProvince(this.employment_lfc);
    this.populateEmploymentData(new_data);
  }

  trendButton(): void {
    this.line_graph = true;
    this.bar_graph = false;
    this.populateSexData(this.employment_sex_province);
  }

  currentButton(): void {
    this.line_graph = false;
    this.bar_graph = true;
    this.populatecurrentSexData(this.employment_sex_province);
  }

  allAgesButton(): void {
    this.all_ages = true;
    this.group = 134;
    this.populateAgeData(this.employment_age_province);
  }

  youthButton(): void {
    this.all_ages = false;
    this.group = 1;
    this.populateSpecificAgeData();
  }

  adultButton(): void {
    this.all_ages = false;
    this.group = 3;
    this.populateSpecificAgeData();
  }

  oldButton(): void {
    this.all_ages = false;
    this.group = 4;
    this.populateSpecificAgeData();
  }

  rateDataButton(): void{
    this.sex_button = false;
    this.age_button = false;
    this.rate_button = true;
    this.line_graph = true;
    this.bar_graph = false;
    this.employment_yAxisLabel = "Unemployment Rate";
    this.populateEmploymentData(this.employment_by_province);
  }

  sexDataButton(): void {
    this.sex_button = true;
    this.rate_button = false;
    this.age_button = false;
    this.line_graph = true;
    this.line_graph = true;
    this.bar_graph = false;
    this.lfc = 6;
    this.sex = 12;
    this.group = 0;

    this.employmentService.getEmploymentBySexesGroup(this.sex, this.group).subscribe(
      data => {
        this.groupBySex(data);
      }
    );
  }

  ageDataButton(): void {
    this.age_button = true;
    this.sex_button = false;
    this.rate_button = false;
    this.all_ages = true;
    this.line_graph = true;
    this.bar_graph = false;

    this.lfc = 6;
    this.sex = 0;
    this.group = 134;

    this.employmentService.getEmploymentByLfcSexGroups(this.lfc, this.sex, this.group).subscribe(
      data => {
        this.groupByAge(data);
      }
    )
  }

  private populatecurrentSexData(data, date="2020-05"): void {
    this.employment_yAxisLabel = "Unemployment Rate by " + date;
    this.employment_xAxisLabel = "Geography";
    let current_sex_data = [];
    for(let empl of data){
      let temp = [];
      let geoName = empl.name;

      
        let series = empl.series;

        for(let serie of series) {
          if(serie.name == date){
            if(serie.sex == 1){ //male
              temp.push({"name": "M", "value": serie.value});
            } else if(serie.sex == 2){
              temp.push({"name": "F", "value": serie.value});
            }
          }
        }
        current_sex_data.push({"name": geoName, "series":temp});    
    }

    this.employment_user_data = current_sex_data;
  }

  private groupByAge(data) {
    let geos = [];
    for(let empl of data) {
      let geoName = empl.geoName;
      let flag = 0;
      for(let geo of geos){
        if(geo.name == geoName) {
          flag = 1;
          geo.series.push({"name": empl.referenceDate.substring(0, 7), "value": empl.value, "age": empl.ageGroup})
        }
      }

      if (flag == 0) {
        let geo_unit = {"name": empl.geoName, "series": [{"name": empl.referenceDate.substring(0, 7), "value": empl.value, "age": empl.ageGroup}]};
        geos.push(geo_unit);
      }
    }
    this.employment_age_province = geos;

    this.populateAgeData(geos);
  }


  private groupBySex(data) {
    let geos = [];

    for(let empl of data) {
      let geoName = empl.geoName;
      let lfc = empl.lfc;
      let flag = 0;
      for(let geo of geos){
        if(geo.name == geoName && lfc==this.lfc){
          flag = 1;
          geo.series.push({"name": empl.referenceDate.substring(0, 7), "value": empl.value, "sex": empl.sex});
          break;
        }
      }
        
      if (flag == 0) {
        if (lfc == this.lfc) {
          let geo_unit = {"name": empl.geoName, "series": [{"name": empl.referenceDate.substring(0, 7), "value": empl.value, "sex": empl.sex}]};
          geos.push(geo_unit);
        }
      }
    }

    this.employment_sex_province = geos;

    this.populateSexData(geos);
  }

  private populateSexData(data, geo="CA") {
    let temp = [];
    this.employment_yAxisLabel = "Unemployment Rate in " + geo;
    this.employment_xAxisLabel  = "Month";

    for(let empl of data){
      let geoName = empl.name;

      if (geo != geoName){
        continue;
      }
      
      var series = empl.series;
      var male_values = [];
      var female_values = [];
      for(let serie of series) {
        var sex = serie.sex;
        if(sex == 1) {
          male_values.push({"name": serie.name, "value": serie.value})
        }else if(sex == 2) {
          female_values.push({"name": serie.name, "value": serie.value})
        }
      }
      temp.push({"name": "M", "series": male_values});
      temp.push({"name": "F", "series": female_values});
      break;
    }

    this.employment_user_data = temp;
  }

  private populateAgeData(data, geo='CA') {
    let temp = [];
    this.employment_yAxisLabel = "Unemployment Rate in " + geo;
    this.employment_xAxisLabel  = "Month";

    for(let empl of data){
      let geoName = empl.name;

      if (geo != geoName){
        continue;
      }
      
      var series = empl.series;
      var youth_values = [];
      var adult_values = [];
      var old_values = [];
      for(let serie of series) {
        var age = serie.age;
        if(age == 1) {
          youth_values.push({"name": serie.name, "value": serie.value})
        }else if(age == 3) {
          adult_values.push({"name": serie.name, "value": serie.value})
        }else if(age == 4) {
          old_values.push({"name": serie.name, "value": serie.value})
        }
      }
      temp.push({"name": "15-24", "series": youth_values});
      temp.push({"name": "25-54", "series": adult_values});
      temp.push({"name": "55+", "series": old_values});
      break;
    }

    this.employment_user_data = temp;
  }

  private populateSpecificAgeData() {
    this.employment_yAxisLabel = "Unemployment Rate";
    let temp = [];

    for(let empl of this.employment_age_province) {
      let geoName = empl.name;
      if(this.selected_provinces.includes(geoName)) {
        let series = empl.series;
        let values = [];
        for(let serie of series) {
          if(serie.age == this.group) {
            values.push({"name": serie.name, "value": serie.value});
          }
        }
        temp.push({"name": geoName, "series": values});
      }
    }
    console.log(temp);

    this.employment_user_data = temp;
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
