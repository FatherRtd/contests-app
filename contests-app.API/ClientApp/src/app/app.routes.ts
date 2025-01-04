import { Routes } from '@angular/router';

import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/sign-up/register.component';
import { MainPageComponent } from './pages/main-page/main-page.component';

export const routes: Routes = [
    {
        path: '',
        component: MainPageComponent,
    },
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
];
