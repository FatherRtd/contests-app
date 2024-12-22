import { Routes } from '@angular/router';
import { LoginComponent } from './core/auth/pages/login/login.component';

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
      }
    ]
  }
];
