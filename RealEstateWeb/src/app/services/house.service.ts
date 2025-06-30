import { Injectable } from '@angular/core';
import { House } from '../interfaces/house';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  constructor() { }

  url = 'http://localhost:5028/api/house'

  async getAllHousingLocations(): Promise<House[]> {
    const data = await fetch(this.url);
    return (await data.json()) ?? [];
  }

  async getHousingLocationById(id: number): Promise<House> {
    const data = await fetch(`${this.url}/${id}`);
    return await data.json(); // return the object directly
  }

  submitApplication(firstName: string, lastName: string, email: string): void {
    console.log(`Application submitted for ${firstName} ${lastName}. Contact: ${email}`);
    // Here you would typically send the application data to a server
  }

  async addHouse(house: any): Promise<void> {
    // Prepare the payload for backend: convert base64 to byte[] if needed
    const payload = {
      ...house,
      photoLocal: house.photoLocal
        ? house.photoLocal.split(',')[1] // remove data:image/...;base64,
        : null
    };
    await fetch(this.url, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(payload)
    });
  }
}
