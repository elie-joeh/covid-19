import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InfectionBreakdownService } from './Services/infection-breakdown.service'
import { CitiesBreakdownService } from './Services/cities-breakdown.service'
import { Infection_info } from 'src/app/Interfaces/infection-info';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {

  title = 'app';

}
