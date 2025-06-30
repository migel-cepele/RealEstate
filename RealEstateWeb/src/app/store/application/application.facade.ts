import { inject, Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../index';
import { UserApplication } from '../../interfaces/userApplication';
import { addApplication, loadApplications } from './application.actions';
import { selectApplications } from './application.selectors';

@Injectable({
  providedIn: 'root'
})
export class ApplicationFacade {
  private readonly store: Store<AppState> = inject(Store<AppState>);

  readonly applications$: Observable<UserApplication[]> = 
    this.store.select(selectApplications);

  addApplication(application: UserApplication): void {
    this.store.dispatch(addApplication({ application }));
  }

  getApplications(): void {
    this.store.dispatch(loadApplications());
  }
}