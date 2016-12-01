import { Injectable } from '@angular/core'
import { Http, Response } from '@angular/http'
import { Observable }     from 'rxjs/Observable';
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
            .then(response => response.json() as Trail[] || { })
            .catch(this.handleError);
    }

    private handleError (error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

}