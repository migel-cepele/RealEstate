import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { Client } from '../../interfaces/client';

export interface ClientState extends EntityState<Client> {
  loading: boolean;
  error: any;
}

export const clientAdapter: EntityAdapter<Client> = createEntityAdapter<Client>();

export const initialClientState: ClientState = clientAdapter.getInitialState({
  loading: false,
  error: null
});
