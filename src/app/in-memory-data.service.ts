import { Injectable } from '@angular/core';
import { Infection_info } from './infection-info'

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService {

  createDb() {
    const infection_info : Infection_info[] = [
      { province: 'Quebec', infected: 10000, dead: 100 },
      { province: 'Ontario', infected: 8000, dead: 87 },
      { province: 'British Columbia', infected: 5000, dead: 56 },
      { province: 'Prince Edward Island', infected: 1233, dead: 45 },
      { province: 'Manitoba', infected: 344, dead: 34 },
      { province: 'Nova Scotia', infected: 22, dead: 12 },
      { province: 'New Brunswick', infected: 543, dead: 34 },
      { province: 'Newfoundland and Labrador', infected: 654, dead: 43 },
      { province: 'Saskatchewan', infected: 134, dead: 54 },
      { province: 'Nunavut', infected: 65, dead: 23 },
      { province: 'Yukon', infected: 2, dead: 0 },
      { province: 'Northwest Territories', infected: 1, dead: 0 }
    ];
    return {infection_info};
  }

  constructor() { }
}
