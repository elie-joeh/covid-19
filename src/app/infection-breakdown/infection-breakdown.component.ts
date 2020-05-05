import { Component, OnInit, Input, ErrorHandler } from '@angular/core';
import {InfectionBreakdownService} from '../infection-breakdown.service';

@Component({
  selector: 'app-infection-breakdown',
  templateUrl: './infection-breakdown.component.html',
  styleUrls: ['./infection-breakdown.component.sass']
})
export class InfectionBreakdownComponent implements OnInit {

  constructor(private infectionBreakdownService : InfectionBreakdownService) { }

  selected_province: string;

  ngOnInit(): void {
    this.infectionBreakdownService.selected_province_obs$.subscribe(
      data => this.handleNewProvince(data)
    );
    
  }
  //TODO: check if the data is incorrect and handle it
  handleNewProvince(data) {
    this.selected_province = data;
    console.log('I am here bitchesssss', data);
  }

}
