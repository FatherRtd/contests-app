import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
    selector: 'app-teams-page',
    standalone: true,
    imports: [],
    templateUrl: './teams-page.component.html',
    styleUrl: './teams-page.component.scss',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TeamsPageComponent {}
