import { NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, Input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatAnchor, MatButton } from '@angular/material/button';
import { MatCard, MatCardActions, MatCardContent, MatCardTitle } from '@angular/material/card';
import { MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { RouterLink } from '@angular/router';

import { AuthService } from '../../services/auth.service';

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
