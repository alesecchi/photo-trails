import { Component, Input, OnInit } from '@angular/core';

import { Trail } from '../trails/shared/trail.model';

declare var google: any;

@Component({
    moduleId: module.id,
    selector: 'pt-map',
    templateUrl: 'map.component.html',
    styleUrls: ['map.component.css']
})
export class MapComponent implements OnInit {
    @Input() trail: Trail

    ngOnInit() {
        var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 4,
          center: {lat: 0.0, lng: 0.0}
        });

        let markers = [];
        let trackPoints = []
        let bounds = new google.maps.LatLngBounds();

        for(let trackpoint of this.trail.trackpoints){
            var position = new google.maps.LatLng(trackpoint.latitude, trackpoint.longitude);

            markers.push(
            new google.maps.Marker({
                position: position,
                map: map,
                animation: google.maps.Animation.DROP
            })
            );
            trackPoints.push({ lat:trackpoint.latitude, lng:trackpoint.longitude })

            bounds.extend(position);
        }

        let trailPath = new google.maps.Polyline({
          path: trackPoints,
          geodesic: true,
          strokeColor: '#FF0000',
          strokeOpacity: 1.0,
          strokeWeight: 2
        });

        trailPath.setMap(map);


        map.fitBounds(bounds);
    }
}