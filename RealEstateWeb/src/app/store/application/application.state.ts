import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { UserApplication } from '../../interfaces/userApplication';

export interface ApplicationState extends EntityState<UserApplication> {
  applications: [];
}

export const selectId = ({ id }: UserApplication) => id; // tells the adapter how to create a unique identifier for my entity object value

export const sortComparer = (a: UserApplication, b: UserApplication): number => {
  return a.firstName.localeCompare(b.firstName);
}

export const applicationAdapter: EntityAdapter<UserApplication> = createEntityAdapter<UserApplication>({
  selectId,
  sortComparer
});

export const initialApplicationState: ApplicationState = applicationAdapter.getInitialState({
  applications: []
});