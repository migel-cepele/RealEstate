import { createAction, props } from '@ngrx/store';
import { Client } from '../../interfaces/client';

export const getClients = createAction('[Client] Get Clients');
export const getClientsSuccess = createAction('[Client] Get Clients Success', props<{ clients: Client[] }>());
export const getClientsFailure = createAction('[Client] Get Clients Failure', props<{ error: any }>());

export const addClient = createAction('[Client] Add Client', props<{ client: Client }>());
export const addClientSuccess = createAction('[Client] Add Client Success', props<{ client: Client }>());
export const addClientFailure = createAction('[Client] Add Client Failure', props<{ error: any }>());
