import { Component } from '@angular/core';

import { Trail } from './shared/trail.model';

const TRAILS: Trail[] = [
  { id: 1, name: 'Cenghen', description: 'Cascata Cenghen', duration: 5400}
];

@Component({
  moduleId: module.id,
  selector: 'pt-trails',
  templateUrl: 'trails.component.html'
})
export class TrailsComponent  {
  trails = TRAILS;
}