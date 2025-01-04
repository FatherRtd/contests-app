import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { ApplicationConfig } from '@angular/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { cookieInterceptor } from './core/auth/interceptors/cookie.interceptor';
import { unauthorizedInterceptor } from './core/auth/interceptors/unauthorized.interceptor';
import { API } from './core/tokens/api';

export const appConfig: ApplicationConfig = {
    providers: [
        provideRouter(routes),
        provideAnimationsAsync(),
        provideHttpClient(withInterceptors([cookieInterceptor, unauthorizedInterceptor])),
        {
            provide: API,
            useValue: '/api',
        },
    ],
};
