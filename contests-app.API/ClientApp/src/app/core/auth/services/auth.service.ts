import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, iif, Observable, of, shareReplay, switchMap, tap } from 'rxjs';

import { AuthApiService, LoginRequest, RegisterRequest, UserResponse } from './auth.api.service';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    private readonly authApiService = inject(AuthApiService);
    private readonly _checkAuthenticated$: BehaviorSubject<void> = new BehaviorSubject<void>(void 0);

    readonly isAuthenticated$: Observable<boolean> = this._checkAuthenticated$.asObservable().pipe(
        switchMap(() => this.authApiService.isAuthenticated()),
        shareReplay({
            bufferSize: 1,
            refCount: true,
        })
    );

    readonly user$: Observable<UserResponse | null> = this.isAuthenticated$.pipe(
        switchMap((authed: boolean) => iif(() => authed, this.currentUser(), of(null))),
        shareReplay({
            bufferSize: 1,
            refCount: true,
        })
    );

    login(credentials: LoginRequest): Observable<void> {
        return this.authApiService.login(credentials).pipe(tap(() => this._checkAuthenticated$.next()));
    }

    register(credentials: RegisterRequest): Observable<void> {
        return this.authApiService.register(credentials);
    }

    logout(): Observable<void> {
        return this.authApiService.logout().pipe(tap(() => this._checkAuthenticated$.next()));
    }

    checkAuthenticated(): void {
        this._checkAuthenticated$.next();
    }

    currentUser(): Observable<UserResponse | null> {
        return this.authApiService.currentUser();
    }
}
