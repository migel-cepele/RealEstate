import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ItemState, itemAdapter } from './item.state';

export const selectItemState = createFeatureSelector<ItemState>('items');

const { selectAll, selectEntities } = itemAdapter.getSelectors();

export const selectAllItems = createSelector(selectItemState, selectAll);
export const selectItemEntities = createSelector(selectItemState, selectEntities);
export const selectItemsLoading = createSelector(selectItemState, state => state.loading);
export const selectItemsError = createSelector(selectItemState, state => state.error);
