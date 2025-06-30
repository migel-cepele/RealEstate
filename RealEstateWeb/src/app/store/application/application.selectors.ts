import { AppState } from '../index';
import { createFeatureSelector, createSelector, MemoizedSelector } from '@ngrx/store';
import { ApplicationState } from './application.state';
import { UserApplication } from '../../interfaces/userApplication';


export const selectApplicationsFeature: MemoizedSelector<AppState, ApplicationState> = 
    createFeatureSelector<ApplicationState>('applications');

export const selectApplications: MemoizedSelector<AppState, UserApplication[]> =
    createSelector(
        selectApplicationsFeature,
        ({entities}: ApplicationState): UserApplication[] => 
            Object.values(entities) as UserApplication[]
    );