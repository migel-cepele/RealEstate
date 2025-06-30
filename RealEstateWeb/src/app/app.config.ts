import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideProtractorTestingSupport } from '@angular/platform-browser';
import {provideEffects} from '@ngrx/effects';

import { routeConfig } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { houseReducer } from './store/house/house.reducers';
import {loadHouses$} from './store/house/house.effects';
import { addApplication$, loadApplications$ } from './store/application/application.effects';
import { applicationReducer } from './store/application/application.reducers';

export const appConfig: ApplicationConfig = {
  providers: [
    provideProtractorTestingSupport(),
    provideRouter(routeConfig),
    provideClientHydration(withEventReplay()),
    provideStore( { houses: houseReducer, applications: applicationReducer}), //the reducer is needed to create the store
    provideEffects({ loadHouses$, loadApplications$, addApplication$ }),
    provideStoreDevtools({
      maxAge: 25, // Retains last 25 states
      logOnly: isDevMode(), // Restrict extension to log-only mode
      autoPause: true, // Pauses recording actions and state changes when extension window is not open
      trace: false, // if its true, it will include stack traces for dispatched actions, so we can see it in trace tab jumping directly in that part of code
      traceLimit: 75 // max stack trace frames to be stored
    })
  ]
};
