import { ActionReducer, createReducer, on } from '@ngrx/store';
import { applicationAdapter, ApplicationState, initialApplicationState } from './application.state';
import { loadApplications, loadApplicationsSuccess, loadApplicationsFailure, addApplication } from './application.actions';

export const applicationReducer: ActionReducer<ApplicationState> = createReducer(
  initialApplicationState,
  on(loadApplications, (state) => ({
    ...state,
    loading: true,
  })),
  on(loadApplicationsSuccess, (state, { applications }) => 
    applicationAdapter.setAll(applications, state)
  ),
  on(loadApplicationsFailure, (state, {error}) => ({
    ...state,
    error
  })),
  on(addApplication, (state, { application }) => 
    applicationAdapter.addOne(application, state)
  )
);