import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { Item } from '../../interfaces/item';

export interface ItemState extends EntityState<Item> {
  loading: boolean;
  error: any;
}

export const itemAdapter: EntityAdapter<Item> = createEntityAdapter<Item>();

export const initialItemState: ItemState = itemAdapter.getInitialState({
  loading: false,
  error: null
});
