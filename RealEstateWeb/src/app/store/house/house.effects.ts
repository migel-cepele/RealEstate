import { inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as HouseActions from './house.actions';
import { HousingService } from '../../services/house.service';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { of, from } from 'rxjs';


export const loadHouses$ = createEffect((actions$: Actions = inject(Actions), 
    houseService = inject(HousingService)) =>{
    return actions$.pipe(
        ofType(HouseActions.loadHouses),
        mergeMap(() => 
            from(houseService.getAllHousingLocations()).pipe(
                map(houses => HouseActions.loadHousesSuccess({ houses })),
                catchError(error => of(HouseActions.loadHousesFailure({ error })))
            )
        )
    )
},
{ functional: true });
  
