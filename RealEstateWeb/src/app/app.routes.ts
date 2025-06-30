import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { DetailsComponent } from './components/details/details.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { HouseComponent } from './components/house/house.component';
import { ApplicationComponent } from './components/application/application.component';

export const routeConfig: Routes = [
    {
        path: '',
        component: HomeComponent,
        title: 'Home',
    },
    {
        path: 'house',
        component: HouseComponent,
        title: 'House',
    },
    {
        path: 'about',
        component: AboutComponent,
        title: 'About',
    },
    {
        path: 'contact',
        component: ContactComponent,
        title: 'Contact',
    },
    {
        path: 'details/:id',
        component: DetailsComponent,
        title: 'Details',
    },
    {
        path: 'application',
        component: ApplicationComponent,
        title: 'Application',
    }
];
