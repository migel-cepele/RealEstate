import { createAction, props } from '@ngrx/store';
import { UserApplication } from '../../interfaces/userApplication';

export const applicationsKey = '[Application]';

export const loadApplications = createAction(
  `${applicationsKey} Load Applications`
);
export const loadApplicationsSuccess = createAction(
  `${applicationsKey} Load Applications Success`,
  props<{ applications: UserApplication[] }>()
);
export const loadApplicationsFailure = createAction(
  `${applicationsKey} Load Applications Failure`,
  props<{ error: any }>()
);
export const addApplication = createAction(
  `${applicationsKey} Add Application`,
  props<{ application: UserApplication }>()
);

export const addApplicationSuccess = createAction(
  `${applicationsKey} Add Application Success`
);

export const addApplicationFailure = createAction(
  `${applicationsKey} Add Application Failure`,
  props<{ error: any }>()
);