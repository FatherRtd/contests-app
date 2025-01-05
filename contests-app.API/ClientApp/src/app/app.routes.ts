import { Routes } from '@angular/router';

import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';

export const routes: Routes = [
    {
        path: 'auth',
        children: [
            {
                path: '',
                redirectTo: 'login',
                pathMatch: 'prefix',
            },
            {
                path: 'login',
                component: LoginComponent,
            },
            {
                path: 'register',
                component: RegisterComponent,
            },
        ],
    },
    {
        path: '',
        loadChildren: () => import('./pages/main-page/main-page.routes').then((m) => m.mainPageRoutes),
    },
];
