import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { UserResponse } from './auth.api.service';
import { API } from '../tokens/api';

export interface TeamResponse {
    id: string;
    name: string;
    users: UserResponse[];
    owner: UserResponse;
}

@Injectable({
    providedIn: 'root',
})
export class TeamApiService {
    private readonly api: string = `${inject(API)}/team`;
    private readonly http: HttpClient = inject(HttpClient);

    create(name: string): Observable<void> {
        return this.http.post<void>(`${this.api}/create`, JSON.stringify({ name }));
    }

    getAll(): Observable<TeamResponse[]> {
        return this.http.get<TeamResponse[]>(`${this.api}/all`);
    }

    getById(id: string): Observable<TeamResponse> {
        return this.http.get<TeamResponse>(`${this.api}/byId?id=${id}`);
    }

    getByUser(userId: string): Observable<TeamResponse | null> {
        return this.http.get<TeamResponse>(`${this.api}/byUser?userId=${userId}`);
    }

    getMy(): Observable<TeamResponse | null> {
        return this.http.get<TeamResponse>(`${this.api}/my`);
    }

    addUser(body: { teamId: string; userId: string }): Observable<void> {
        return this.http.patch<void>(`${this.api}/addUser`, body);
    }

    delete(id: string): Observable<void> {
        return this.http.delete<void>(`${this.api}/delete`);
    }
}
