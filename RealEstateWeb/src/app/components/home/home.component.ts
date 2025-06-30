import { Component, inject, AfterContentInit } from '@angular/core';
import { HousingLocationComponent } from '../housing-location/housing-location.component';
import { House } from '../../interfaces/house';
import { NgFor } from '@angular/common';
import { HousingService } from '../../services/house.service';
import { addHouse } from '../../store/house/house.actions';
import { HouseFacade } from '../../store/house/house.facade';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  standalone: true,
  imports: [HousingLocationComponent, NgFor],
  styleUrl: './home.component.scss'
})

export class HomeComponent implements AfterContentInit {
  private readonly houseFacade: HouseFacade = inject(HouseFacade);

  housingLocationList: House[] = [];
  filteredLocationList: House[] = [];

  constructor(private housingService: HousingService) {

    /*this.housingService.getAllHousingLocations().then(locations => {
      this.housingLocationList = locations;
      this.filteredLocationList = locations;
    });*/
    this.houseFacade.getHouses();

    this.houseFacade.houses$.subscribe(locations => {
      this.housingLocationList = locations;
      this.filteredLocationList = locations;
    });
    
  }

  ngAfterContentInit() {
    this.addMessage();
  }

  addMessage(): void {
    const house: House = {
      id: Date.now(), // unique id based on timestamp
      name: 'Sample House',
      city: 'Sample City',
      state: 'Sample State',
      photo: 'https://via.placeholder.com/150',
      availableUnits: 2,
      wifi: true,
      laundry: false
    };
    this.houseFacade.addHouse(house);
  }

  filterResults(cityText: string, nameText: string) {
    if (!cityText && !nameText) {
      this.filteredLocationList = this.housingLocationList;
      return;
    }
    const lowerCity = cityText ? cityText.toLowerCase() : '';
    const lowerName = nameText ? nameText.toLowerCase() : '';
    this.filteredLocationList = this.housingLocationList.filter(location => {
      const matchesCity = lowerCity ? location.city.toLowerCase().includes(lowerCity) : true;
      const matchesName = lowerName ? location.name.toLowerCase().includes(lowerName) : true;
      return matchesCity && matchesName;
    });
  }
}
