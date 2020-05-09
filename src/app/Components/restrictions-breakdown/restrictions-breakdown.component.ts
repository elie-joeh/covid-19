import { Component, OnInit } from '@angular/core';
import {InfectionBreakdownService} from '../../Services/infection-breakdown.service'

@Component({
  selector: 'app-restrictions-breakdown',
  templateUrl: './restrictions-breakdown.component.html',
  styleUrls: ['./restrictions-breakdown.component.sass']
})
export class RestrictionsBreakdownComponent implements OnInit {

  constructor(private infectionBreakdownService: InfectionBreakdownService) { }

  private selected_province : string;

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
