import { Component, Input } from '@angular/core';

import { Trail } from '../shared/trail.model';

@Component({
    moduleId: module.id,
    selector: 'pt-trail',
    templateUrl: 'trail.component.html',
    styleUrls: ['trail.component.css']
})
export class TrailComponent {
    @Input() trail: Trail
}