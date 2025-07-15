import { inject, Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { getClients, addClient } from './client.actions';
import { selectAllClients, selectClientsLoading, selectClientsError } from './client.selectors';
import { Client } from '../../interfaces/client';
import { AppState } from '..';

@Injectable({ providedIn: 'root' })
export class ClientFacade {

  private readonly store: Store<AppState> = inject(Store<AppState>);

  clients$ = this.store.select(selectAllClients);
  loading$ = this.store.select(selectClientsLoading);
  error$ = this.store.select(selectClientsError);

  getClients() {
    this.store.dispatch(getClients());
  }

  addClient(client: Client) {
    this.store.dispatch(addClient({ client }));
  }
}
