import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';

import { API } from '../../tokens/api';

export interface LoginRequest {
    login: string;
    password: string;
}

export interface RegisterRequest {
    name: string;
    surName: string;
    login: string;
    password: string;
}

export interface Team {
    id: string;
    name: string;
}

export interface UserResponse {
    id: string;
    name: string;
    surName: string;
    login: string;
    isAdmin: boolean;
    isMentor: boolean;
    ownedTeam: null | Team;
    team: null | Team;
    avatar: null | string;
}

export interface UpdateUserRequest {
    id: string;
    name: string;
    surName: string;
    isAdmin: boolean;
    isMentor: boolean;
}

@Injectable({
    providedIn: 'root',
})
export class AuthApiService {
    private readonly api: string = `${inject(API)}/user`;
    private readonly http: HttpClient = inject(HttpClient);

    isAuthenticated(): Observable<boolean> {
        return this.http.get<boolean>(`${this.api}/isAuthenticated`);
    }

    login(body: LoginRequest): Observable<void> {
        return this.http.post<void>(`${this.api}/login`, body);
    }

    register(body: RegisterRequest): Observable<void> {
        return this.http.post<void>(`${this.api}/register`, body);
    }

    logout(): Observable<void> {
        return this.http.get<void>(`${this.api}/logout`);
    }

    currentUser(): Observable<UserResponse | null> {
        return this.http.get<UserResponse>(`${this.api}/currentUser`).pipe(catchError(() => of(null)));
    }

    updateUser(body: UpdateUserRequest): Observable<void> {
        return this.http.put<void>(`${this.api}/updateUser`, body);
    }
}
