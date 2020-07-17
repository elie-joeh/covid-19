import { Component, OnInit } from '@angular/core';
import { InfectionBreakdownService } from 'src/app/Services/infection-breakdown.service';
import { ActivatedRoute } from '@angular/router';
import { Province } from 'src/app/Interfaces/Province';

/*
This component is the wrapper component, which will call all the other components and display them
depending on the defined view.
This component also fetch all the necessary data to be displayed in the view. The data is passed
to the children components using te Input decorator.
*/

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent implements OnInit {

  //to remove
  public resolveData: 'QC';

  //Data for CanadaMap Component
  canada_map_data: any;
  chart_columns: any;
  province_infected: any;
  province_dead: any;

  //Data for Infection Breakdown Component
  infection_breakdown_data: Province[];

  //Data for Restrictions breakdown component
  restrictions_breakdown_data: any;

  constructor(private actr: ActivatedRoute) {
  } 


  ngOnInit(): void {
    //Retreive data for Canada Map Component, and set the input to the component to be the infection number
    let temp_province_infected_data = [];
    let temp_province_dead_data = [];
    for(let province of this.actr.snapshot.data['provinceInfectionData']) {
      temp_province_infected_data.push([province.name, province.infected]);
      temp_province_dead_data.push([province.name, province.dead]);
    }
    this.canada_map_data = temp_province_infected_data;
    this.province_infected = temp_province_infected_data;
    this.province_dead = temp_province_dead_data;
    this.chart_columns = ['Province', 'Infected'];

    //Retrieve data for Infection Breakdown Component
    let temp_data = [];
    for(let province_data of this.actr.snapshot.data['provinceInfectionData']) {
      const infection_info = <Province> {
        name: province_data.name,
        infected: province_data.infected,
        dead: province_data.dead
      }
      temp_data.push(infection_info);
    }
    this.infection_breakdown_data = temp_data;

  }


  getProvInfectionBreakdown(e:string) {
    //TODO: change the else to an error shown next to the map
    if(e == null || e.trim() == ""){
      return;
    }else if (e.trim() == 'dead'){
      this.chart_columns = ['Province', 'Dead']
      this.canada_map_data = this.province_dead;
    }else if(e.trim() == 'infection') {
      this.chart_columns = ['Province', 'Infected'];
      this.canada_map_data = this.province_infected;
    }else {
      console.log('error in showing dead or infection data on canada map');
    }
  }


}