import { Component, OnInit } from '@angular/core';
import { DataseedingService } from '../../Services/dataseeding.service';

@Component({
  selector: 'app-dataseeding',
  templateUrl: './dataseeding.component.html',
  styleUrls: ['./dataseeding.component.sass']
})
export class DataseedingComponent implements OnInit {

  constructor(private dataseedingService: DataseedingService) { }

  ngOnInit(): void {

    this.dataseedingService.storeDataInDatabase().subscribe(
      data => console.log(data)
    );
  }

}
