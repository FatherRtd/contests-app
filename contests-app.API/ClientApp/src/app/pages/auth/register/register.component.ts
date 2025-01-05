import { NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, DestroyRef, inject, Input } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatAnchor, MatButton, MatIconAnchor } from '@angular/material/button';
import {
    MatCard,
    MatCardActions,
    MatCardAvatar,
    MatCardContent,
    MatCardHeader,
    MatCardTitle,
} from '@angular/material/card';
import { MatFormField } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatInput } from '@angular/material/input';
import { Router, RouterLink } from '@angular/router';

import { AuthService } from '../../../services/auth.service';

export type RegisterFormControls = {
    login: FormControl<string>;
    name: FormControl<string>;
    surName: FormControl<string>;
    password: FormControl<string>;
    confirmPassword: FormControl<string>;
};

@Component({
    selector: 'app-sign-up',
    standalone: true,
    imports: [
        MatButton,
        MatCard,
        MatCardContent,
        MatCardTitle,
        MatFormField,
        MatInput,
        NgIf,
        ReactiveFormsModule,
        MatCardActions,
        RouterLink,
        MatAnchor,
        MatCardAvatar,
        MatCardHeader,
        MatIcon,
        MatIconAnchor,
    ],
    templateUrl: './register.component.html',
    styleUrl: './register.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RegisterComponent {
    @Input() error: string | null = null;

    readonly form: FormGroup<RegisterFormControls> = new FormGroup<RegisterFormControls>({
        login: new FormControl('', { nonNullable: true }),
        name: new FormControl('', { nonNullable: true }),
        surName: new FormControl('', { nonNullable: true }),
        password: new FormControl('', { nonNullable: true }),
        confirmPassword: new FormControl('', { nonNullable: true }),
    });

    readonly auth = inject(AuthService);
    readonly dr = inject(DestroyRef);
    readonly router = inject(Router);

    onSubmit(): void {
        if (this.form.valid) {
            this.auth
                .register(this.form.getRawValue())
                .pipe(takeUntilDestroyed(this.dr))
                .subscribe(() => this.router.navigate(['/auth']));
        }
    }
}
