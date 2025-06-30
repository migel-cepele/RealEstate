import { ActionReducer, createReducer, on } from '@ngrx/store';
import { HouseState, houseAdapter, initialHouseState } from './house.state';
import { loadHouses, loadHousesSuccess, loadHousesFailure, addHouse } from './house.actions';

export const houseReducer: ActionReducer<HouseState> = createReducer(
  initialHouseState,
on(loadHouses, (state) => ({
    ...state,
    loading: true,
    error: null
})),
on(loadHousesSuccess, (state, { houses }) =>
    houseAdapter.setAll(houses, { ...state, loading: false })
),
on(loadHousesFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
})),
  on(addHouse, (state, { house }) => houseAdapter.addOne(house, state))
);