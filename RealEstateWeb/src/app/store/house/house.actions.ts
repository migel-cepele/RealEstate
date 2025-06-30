import { createAction, props } from '@ngrx/store';
import { House } from '../../interfaces/house';

export const housesKey = '[House]';

export const loadHouses = createAction(
  `${housesKey} Load Houses`
);

export const loadHousesSuccess = createAction(
  `${housesKey} Load Houses Success`,
  props<{ houses: House[] }>()
);

export const loadHousesFailure = createAction(
  `${housesKey} Load Houses Failure`,
    props<{ error: any }>()
);

export const addHouse = createAction(
  `${housesKey} Add House`,
  props<{ house: House }>()
);