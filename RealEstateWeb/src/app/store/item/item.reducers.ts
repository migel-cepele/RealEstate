import { ActionReducer, createReducer, on } from '@ngrx/store';
import { ItemState, itemAdapter, initialItemState } from './item.state';
import { getItems, getItemsSuccess, getItemsFailure, addItem, addItemSuccess, addItemFailure } from './item.actions';

export const itemReducer: ActionReducer<ItemState> = createReducer(
  initialItemState,
  on(getItems, (state) => ({ ...state, loading: true, error: null })),
  on(getItemsSuccess, (state, { items }) => itemAdapter.setAll(items, { ...state, loading: false })),
  on(getItemsFailure, (state, { error }) => ({ ...state, loading: false, error })),
  on(addItem, (state) => ({ ...state, loading: true, error: null })),
  on(addItemSuccess, (state, { item }) => itemAdapter.addOne(item, { ...state, loading: false })),
  on(addItemFailure, (state, { error }) => ({ ...state, loading: false, error }))
);
