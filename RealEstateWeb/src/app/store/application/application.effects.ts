import { inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { of, from } from 'rxjs';
import * as ApplicationActions from './application.actions';
import { ApplicationService } from '../../services/application.service';

export const loadApplications$ = createEffect((actions$: Actions = inject(Actions), 
    applicationService = inject(ApplicationService)) => {
    return actions$.pipe(
        ofType(ApplicationActions.loadApplications),
        mergeMap(() => 
            from(applicationService.getAll()).pipe(
                map(applications => ApplicationActions.loadApplicationsSuccess({ applications })),
                catchError(error => of(ApplicationActions.loadApplicationsFailure({ error })))
            )
        )
    );
}, { functional: true });

export const addApplication$ = createEffect((actions$: Actions = inject(Actions), 
    applicationService = inject(ApplicationService)) => {
    return actions$.pipe(
        ofType(ApplicationActions.addApplication),
        mergeMap(action => 
            from(applicationService.add(action.application)).pipe(
                map(application => ApplicationActions.addApplicationSuccess()),
                catchError(error => of(ApplicationActions.addApplicationFailure({ error })))
            )
        )
    );
}, { functional: true });
