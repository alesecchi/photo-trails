import { Component, OnInit } from '@angular/core';

import { Trail } from './shared/trail.model';
import { TrailService } from './shared/trail.service';

@Component({
  moduleId: module.id,
  selector: 'pt-trails',
  templateUrl: 'trails.component.html',
  providers: [TrailService]
})
export class TrailsComponent implements OnInit  {
  trails: Trail[];
  selectedTrail: Trail;

  constructor(private trailService: TrailService) { }

  ngOnInit(): void {
    this.trailService.getTrails().then(trails => this.trails = trails);
  }

  onSelect(trail: Trail): void {
    this.selectedTrail = trail;
  }
}