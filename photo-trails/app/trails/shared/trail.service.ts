import { Injectable } from '@angular/core'

import { TRAILS } from './mock-trails'
import { Trail } from './trail.model'

@Injectable()
export class TrailService {
    getTrails(): Promise<Trail[]> {
        return Promise.resolve(TRAILS);
    }
}