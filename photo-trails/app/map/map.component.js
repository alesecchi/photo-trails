"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var trail_model_1 = require('../trails/shared/trail.model');
var MapComponent = (function () {
    function MapComponent() {
    }
    MapComponent.prototype.ngOnInit = function () {
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 4,
            center: { lat: 0.0, lng: 0.0 }
        });
        var markers = [];
        var trackPoints = [];
        var bounds = new google.maps.LatLngBounds();
        for (var _i = 0, _a = this.trail.trackpoints; _i < _a.length; _i++) {
            var trackpoint = _a[_i];
            var position = new google.maps.LatLng(trackpoint.latitude, trackpoint.longitude);
            markers.push(new google.maps.Marker({
                position: position,
                map: map,
                animation: google.maps.Animation.DROP
            }));
            trackPoints.push({ lat: trackpoint.latitude, lng: trackpoint.longitude });
            bounds.extend(position);
        }
        var trailPath = new google.maps.Polyline({
            path: trackPoints,
            geodesic: true,
            strokeColor: '#FF0000',
            strokeOpacity: 1.0,
            strokeWeight: 2
        });
        trailPath.setMap(map);
        map.fitBounds(bounds);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', trail_model_1.Trail)
    ], MapComponent.prototype, "trail", void 0);
    MapComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'pt-map',
            templateUrl: 'map.component.html',
            styleUrls: ['map.component.css']
        }), 
        __metadata('design:paramtypes', [])
    ], MapComponent);
    return MapComponent;
}());
exports.MapComponent = MapComponent;
//# sourceMappingURL=map.component.js.map