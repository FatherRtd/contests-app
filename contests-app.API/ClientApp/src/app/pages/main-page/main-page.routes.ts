import { Routes } from '@angular/router';

import { MainPageComponent } from './main-page.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';

export const mainPageRoutes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
    },
    {
        path: 'home',
        component: MainPageComponent,
        children: [
            {
                path: '',
                component: LandingPageComponent,
            },
        ],
    },
];
