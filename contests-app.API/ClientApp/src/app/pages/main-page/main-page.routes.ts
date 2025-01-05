import { Routes } from '@angular/router';

import { MainPageComponent } from './main-page.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { TeamPageComponent } from './pages/team-page/team-page.component';
import { authGuard } from '../../guards/auth.guard';

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
                path: 'team',
                canActivate: [authGuard],
                component: TeamPageComponent,
            },
        ],
    },
];
