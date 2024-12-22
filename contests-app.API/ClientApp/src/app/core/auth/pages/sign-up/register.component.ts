import { NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatAnchor, MatButton } from '@angular/material/button';
import { MatCard, MatCardActions, MatCardContent, MatCardTitle } from '@angular/material/card';
import { MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { RouterLink } from '@angular/router';

export type RegisterFormControls = {
    username: FormControl<string>;
    name: FormControl<string>;
    surname: FormControl<string>;
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
    ],
    templateUrl: './register.component.html',
    styleUrl: './register.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class RegisterComponent {
    @Input() error: string | null = null;

    @Output() submitEM = new EventEmitter();

    form: FormGroup<RegisterFormControls> = new FormGroup<RegisterFormControls>({
        username: new FormControl('', { nonNullable: true }),
        name: new FormControl('', { nonNullable: true }),
        surname: new FormControl('', { nonNullable: true }),
        password: new FormControl('', { nonNullable: true }),
        confirmPassword: new FormControl('', { nonNullable: true }),
    });

    submit() {
        if (this.form.valid) {
            this.submitEM.emit(this.form.value);
        }
    }
}
