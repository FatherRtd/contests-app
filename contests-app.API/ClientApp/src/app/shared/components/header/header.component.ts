import { AsyncPipe, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, DestroyRef, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { MatFabAnchor } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatMenu, MatMenuItem, MatMenuTrigger } from '@angular/material/menu';
import { RouterLink } from '@angular/router';
import { Observable } from 'rxjs';

import { UserComponent } from './components/user/user.component';
import { UserResponse } from '../../../core/auth/services/auth.api.service';
import { AuthService } from '../../../core/auth/services/auth.service';

@Component({
    selector: 'app-header',
    standalone: true,
    imports: [MatIcon, RouterLink, MatFabAnchor, NgIf, AsyncPipe, UserComponent, MatMenuTrigger, MatMenu, MatMenuItem],
    templateUrl: './header.component.html',
    styleUrl: './header.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HeaderComponent {
    private readonly authService: AuthService = inject(AuthService);
    readonly user$: Observable<UserResponse | null> = this.authService.user$;
    readonly dr = inject(DestroyRef);

    onLogout(): void {
        this.authService.logout().pipe(takeUntilDestroyed(this.dr)).subscribe();
    }
}
