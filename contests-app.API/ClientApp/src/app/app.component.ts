import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { AuthService } from './core/auth/services/auth.service';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [CommonModule, RouterOutlet],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent {
    constructor(private readonly auth: AuthService) {
        this.auth.isAuthenticated$.subscribe();
        this.auth.isAuthenticated$.subscribe();
        this.auth.isAuthenticated$.subscribe();
        this.auth.isAuthenticated$.subscribe();
        this.auth.user$.subscribe();
        this.auth.user$.subscribe();
        this.auth.user$.subscribe();
        this.auth.user$.subscribe();
        this.auth.user$.subscribe();
    }
}
