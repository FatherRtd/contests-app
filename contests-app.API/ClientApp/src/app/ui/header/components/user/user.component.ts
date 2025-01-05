import { NgIf, NgOptimizedImage } from '@angular/common';
import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { MatIcon } from '@angular/material/icon';

import { UserResponse } from '../../../../services/auth.api.service';

@Component({
    selector: 'app-user',
    standalone: true,
    imports: [NgOptimizedImage, MatIcon, NgIf],
    templateUrl: './user.component.html',
    styleUrl: './user.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserComponent {
    @Input() user: UserResponse | null = null;
}
