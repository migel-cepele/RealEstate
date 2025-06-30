import { AppState } from '../index';
import { createFeatureSelector, createSelector, MemoizedSelector } from '@ngrx/store';
import { HouseState } from './house.state';
import { House } from '../../interfaces/house';

export const selectHousesFeature: MemoizedSelector<AppState, HouseState> = 
    createFeatureSelector<HouseState>('houses');

export const selectHouses: MemoizedSelector<AppState, House[]> =
    createSelector(
        selectHousesFeature,
        ({entities} : HouseState): House[] => 
            Object.values(entities) as House[]
);