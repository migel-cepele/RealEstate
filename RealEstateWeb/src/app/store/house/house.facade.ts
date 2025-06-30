import { inject, Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { House } from '../../interfaces/house';
import { addHouse, loadHouses } from './house.actions';
import { selectHouses } from './house.selectors';
import { AppState } from '../index';

@Injectable({
  providedIn: 'root'
})
export class HouseFacade {
  private readonly store: Store<AppState> = inject(Store<AppState>);

  readonly houses$: Observable<House[]> = 
    this.store.select(selectHouses);

  addHouse(house: House): void {
    this.store.dispatch(addHouse({ house }));
  }

  getHouses(): void {
    this.store.dispatch(loadHouses());
  }
}