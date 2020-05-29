import { Injectable } from '@angular/core';
import { Province } from '../Interfaces/Province';
import { City } from '../Interfaces/City';

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService {

  createDb() {
    const infection_info : Province[] = [
      { name: 'Quebec', infected: 10000, dead: 100 },
      { name: 'Ontario', infected: 8000, dead: 87 },
      { name: 'Alberta',infected: 6000, dead: 64},
      { name: 'British Columbia', infected: 5000, dead: 56 },
      { name: 'Prince Edward Island', infected: 1233, dead: 45 },
      { name: 'Manitoba', infected: 344, dead: 34 },
      { name: 'Nova Scotia', infected: 22, dead: 12 },
      { name: 'New Brunswick', infected: 543, dead: 34 },
      { name: 'Newfoundland and Labrador', infected: 654, dead: 43 },
      { name: 'Saskatchewan', infected: 134, dead: 54 },
      { name: 'Nunavut', infected: 65, dead: 23 },
      { name: 'Yukon', infected: 2, dead: 0 },
      { name: 'Northwest Territories', infected: 1, dead: 0 }
    ];


    const cities_info: City[] = [
      { name: 'Quebec City', infected: 10000, dead: 100 },
      { name: 'Montreal', infected: 8000, dead: 87 },
      { name: 'Gatineau', infected: 5000, dead: 56 },
      { name: 'Sherbrooke', infected: 1233, dead: 45 },
      { name: 'Levis', infected: 344, dead: 34 },
      { name: 'Laval', infected: 22, dead: 12 },
      { name: 'Longueuil', infected: 543, dead: 34 },
      { name: 'Saguenay', infected: 654, dead: 43 },
      { name: 'Saint-Jean-Sur-Richelieu', infected: 134, dead: 54 },
      { name: 'La Turque', infected: 65, dead: 23 },
      { name: 'Magog', infected: 2, dead: 0 },
      { name: 'Dorval', infected: 1, dead: 0 }
    ];

    return {infection_info, cities_info};
  }

  constructor() { }
}
