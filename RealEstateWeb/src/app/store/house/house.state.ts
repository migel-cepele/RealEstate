import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { House } from '../../interfaces/house';

export interface HouseState extends EntityState<House> {
  houses: [];
}

export const selectId = ({ id }: House) => id; // tells the adapter 
// how to create a unique identifier for my entity object value

export const sortComparer = (a: House, b: House): number => {
  return a.name.localeCompare(b.name);
}

export const houseAdapter: EntityAdapter<House> = createEntityAdapter<House>({
  selectId,
  sortComparer
});

export const initialHouseState: HouseState = houseAdapter.getInitialState({
  houses: []
});