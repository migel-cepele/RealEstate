import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { ClientService } from '../../services/client.service';
import { getClients, getClientsSuccess, getClientsFailure, addClient, addClientSuccess, addClientFailure } from './client.actions';
import { catchError, map, mergeMap, of } from 'rxjs';

@Injectable()
export class ClientEffects {
  loadClients$ = createEffect(() =>
    this.actions$.pipe(
      ofType(getClients),
      mergeMap(() =>
        this.clientService.getAll().pipe(
          map(clients => getClientsSuccess({ clients })),
          catchError(error => of(getClientsFailure({ error })))
        )
      )
    )
  );

  addClient$ = createEffect(() =>
    this.actions$.pipe(
      ofType(addClient),
      mergeMap(action =>
        this.clientService.add(action.client).pipe(
          map(client => addClientSuccess({ client })),
          catchError(error => of(addClientFailure({ error })))
        )
      )
    )
  );

  constructor(private actions$: Actions, private clientService: ClientService) {}
}
