import { NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, Input } from '@angular/core';
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
import { RouterLink } from '@angular/router';

import { AuthService } from '../../../core/auth/services/auth.service';

export type LoginFormControls = {
    login: FormControl<string>;
    password: FormControl<string>;
};

@Component({
    selector: 'app-login',
    standalone: true,
    imports: [
        MatCard,
        MatCardTitle,
        MatCardContent,
        ReactiveFormsModule,
        MatFormField,
        MatInput,
        MatButton,
        NgIf,
        MatAnchor,
        MatCardActions,
        RouterLink,
        MatCardHeader,
        MatCardAvatar,
        MatIcon,
        MatIconAnchor,
    ],
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent {
    @Input() error: string | null = null;

    readonly form: FormGroup<LoginFormControls> = new FormGroup<LoginFormControls>({
        login: new FormControl('', { nonNullable: true }),
        password: new FormControl('', { nonNullable: true }),
    });

    readonly auth = inject(AuthService);

    onSubmit(): void {
        if (this.form.valid) {
            this.auth.login(this.form.getRawValue()).subscribe();
        }
    }
}
