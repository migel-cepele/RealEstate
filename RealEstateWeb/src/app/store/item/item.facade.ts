import { inject, Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { getItems, addItem } from './item.actions';
import { selectAllItems, selectItemsLoading, selectItemsError } from './item.selectors';
import { Item } from '../../interfaces/item';
import { ItemImage } from '../../interfaces/item-image';
import { AppState } from '..';

@Injectable({ providedIn: 'root' })
export class ItemFacade {

  private readonly store: Store<AppState> = inject(Store<AppState>);

  items$ = this.store.select(selectAllItems);
  loading$ = this.store.select(selectItemsLoading);
  error$ = this.store.select(selectItemsError);

  getItems() {
    this.store.dispatch(getItems());
  }

  addItem(item: Item, itemImages: ItemImage[]): void {
    this.store.dispatch(addItem({ item, itemImages }));
  }
}
