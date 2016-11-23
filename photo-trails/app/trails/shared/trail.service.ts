import { Injectable } from '@angular/core'
import { Http, Response } from '@angular/http'
import 'rxjs/add/operator/toPromise';

import { TRAILS } from './mock-trails'
import { Trail } from './trail.model'

@Injectable()
export class TrailService {
    private trailsUrl = 'http://localhost:59270/PhotoTrailsService.svc/Trail'

    constructor(private http: Http) { }

    getTrails(): Promise<Trail[]> {
        return this.http.get(this.trailsUrl)
            .toPromise()
            .then(response => response.json() as Trail[] || { });
    }

}