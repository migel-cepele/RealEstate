import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';


bootstrapApplication(AppComponent, appConfig) //appConfig is the configuration object for the application in the file app.config.ts
  .catch((err) => console.error(err));
