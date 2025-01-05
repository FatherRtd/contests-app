import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

import { AuthService } from '../services/auth.service';

export const unauthorizedInterceptor: HttpInterceptorFn = (req, next) => {
    const router = inject(Router);
    const authService = inject(AuthService);

    return next(req).pipe(
        catchError((err: unknown) => {
            if (err instanceof HttpErrorResponse) {
                if (err.status === 401) {
                    authService.checkAuthenticated();
                    router.navigate(['/auth']);
                }
                const error = (err && err.error && err.error.message) || err.statusText;
                return throwError(error);
            }

            return throwError(err);
        })
    );
};
