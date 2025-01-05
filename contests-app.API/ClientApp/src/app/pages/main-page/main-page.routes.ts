import { Routes } from '@angular/router';

import { MainPageComponent } from './main-page.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { TeamsPageComponent } from './pages/teams-page/teams-page.component';
import { authGuard } from '../../core/auth/guards/auth.guard';

export const mainPageRoutes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
    },
    {
        path: '',
        component: MainPageComponent,
        children: [
            {
                path: 'home',
                component: LandingPageComponent,
            },
            {
                path: 'teams',
                canActivate: [authGuard],
                component: TeamsPageComponent,
            },
        ],
    },
];
