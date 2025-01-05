import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { map } from 'rxjs';

import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = () => {
    const router = inject(Router);
    return inject(AuthService).isAuthenticated$.pipe(map((isAuthed) => isAuthed || router.parseUrl('/auth')));
};
