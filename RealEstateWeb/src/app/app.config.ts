import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideProtractorTestingSupport } from '@angular/platform-browser';
import {provideEffects} from '@ngrx/effects';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { routeConfig } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import  Aura  from '@primeng/themes/aura';
import { providePrimeNG } from 'primeng/config';
import { FilterMatchMode } from 'primeng/api';

//ngrx imports
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
    }),
    //primeng providers for UI
    provideAnimationsAsync(),
    providePrimeNG({
      ripple: true, // Enable ripple effect
      theme: {
        preset: Aura
      },
       zIndex: {
        modal: 1100,    // dialog, sidebar
        overlay: 1000,  // dropdown, overlaypanel
        menu: 1000,     // overlay menus
        tooltip: 1100   // tooltip
      },
      filterMatchModeOptions: {
        text: [FilterMatchMode.STARTS_WITH, FilterMatchMode.CONTAINS, FilterMatchMode.NOT_CONTAINS, FilterMatchMode.ENDS_WITH, FilterMatchMode.EQUALS, FilterMatchMode.NOT_EQUALS],
        numeric: [FilterMatchMode.EQUALS, FilterMatchMode.NOT_EQUALS, FilterMatchMode.LESS_THAN, FilterMatchMode.LESS_THAN_OR_EQUAL_TO, FilterMatchMode.GREATER_THAN, FilterMatchMode.GREATER_THAN_OR_EQUAL_TO],
        date: [FilterMatchMode.DATE_IS, FilterMatchMode.DATE_IS_NOT, FilterMatchMode.DATE_BEFORE, FilterMatchMode.DATE_AFTER]
    }
    })
  ]
};
