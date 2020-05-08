import { Component, OnInit, Input, ErrorHandler } from '@angular/core';
import { InfectionBreakdownService } from '../infection-breakdown.service';
import { Infection_info } from '../infection-info';

@Component({
  selector: 'app-infection-breakdown',
  templateUrl: './infection-breakdown.component.html',
  styleUrls: ['./infection-breakdown.component.sass']
})
export class InfectionBreakdownComponent implements OnInit {


  constructor(private infectionBreakdownService : InfectionBreakdownService) { }

  selected_province: string = 'Quebec';

  all_infection_info : Infection_info[];

  ngOnInit(): void {
    this.infectionBreakdownService.selected_province_obs$.subscribe(
      data => this.handleNewProvince(data)
    );
    this.getInfectionBreakdown()
  }

  getInfectionBreakdown() {
    console.log(`getting infection information of all provinces`)
    this.infectionBreakdownService.getInfectionInfo()
      .subscribe(infection_info => this.all_infection_info = infection_info)
  }

  getInfectionByProvince(selected_province: string){
    console.log(`getting infection information by province ${selected_province}`)
    //TODO subscribe to the observable that you are receiving
    //this.infectionBreakdownService.getInfecionInfoByProvince(selected_province)
    
  }


  //TODO: check if the data is incorrect and handle it
  handleNewProvince(data) {
    this.selected_province = data;
    this.getInfectionBreakdown();
  }

}
