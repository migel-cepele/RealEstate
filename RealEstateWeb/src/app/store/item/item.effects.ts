import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { ItemService } from '../../services/item.service';
import { getItems, getItemsSuccess, getItemsFailure, addItem, addItemSuccess, addItemFailure } from './item.actions';
import { catchError, map, mergeMap, of } from 'rxjs';

@Injectable()
export class ItemEffects {
  loadItems$ = createEffect(() =>
    this.actions$.pipe(
      ofType(getItems),
      mergeMap(() =>
        this.itemService.getAll().pipe(
          map(items => getItemsSuccess({ items })),
          catchError(error => of(getItemsFailure({ error })))
        )
      )
    )
  );

  addItem$ = createEffect(() =>
    this.actions$.pipe(
      ofType(addItem),
      mergeMap(action =>
        this.itemService.add(action.item, action.itemImages).pipe(
          map(item => addItemSuccess({ item })),
          catchError(error => of(addItemFailure({ error })))
        )
      )
    )
  );

  constructor(private actions$: Actions, private itemService: ItemService) {}
}
