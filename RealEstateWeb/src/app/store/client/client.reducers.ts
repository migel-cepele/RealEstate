import { ActionReducer, createReducer, on } from '@ngrx/store';
import { ClientState, clientAdapter, initialClientState } from './client.state';
import { getClients, getClientsSuccess, getClientsFailure, addClient, addClientSuccess, addClientFailure } from './client.actions';

export const clientReducer: ActionReducer<ClientState> = createReducer(
  initialClientState,
  on(getClients, (state) => ({ ...state, loading: true, error: null })),
  on(getClientsSuccess, (state, { clients }) => clientAdapter.setAll(clients, { ...state, loading: false })),
  on(getClientsFailure, (state, { error }) => ({ ...state, loading: false, error })),
  on(addClient, (state) => ({ ...state, loading: true, error: null })),
  on(addClientSuccess, (state, { client }) => clientAdapter.addOne(client, { ...state, loading: false })),
  on(addClientFailure, (state, { error }) => ({ ...state, loading: false, error }))
);
