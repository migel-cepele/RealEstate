import { createAction, props } from '@ngrx/store';
import { Item } from '../../interfaces/item';
import { ItemImage } from '../../interfaces/item-image';

export const getItems = createAction('[Item] Get Items');
export const getItemsSuccess = createAction('[Item] Get Items Success', props<{ items: Item[] }>());
export const getItemsFailure = createAction('[Item] Get Items Failure', props<{ error: any }>());

export const addItem = createAction('[Item] Add Item', props<{ item: Item, itemImages: ItemImage[] }>());
export const addItemSuccess = createAction('[Item] Add Item Success', props<{ item: Item }>());
export const addItemFailure = createAction('[Item] Add Item Failure', props<{ error: any }>());
