import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ClientState, clientAdapter } from './client.state';

export const selectClientState = createFeatureSelector<ClientState>('clients');

const { selectAll, selectEntities } = clientAdapter.getSelectors();

export const selectAllClients = createSelector(selectClientState, selectAll);
export const selectClientEntities = createSelector(selectClientState, selectEntities);
export const selectClientsLoading = createSelector(selectClientState, state => state.loading);
export const selectClientsError = createSelector(selectClientState, state => state.error);
