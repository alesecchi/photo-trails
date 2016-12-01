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
var trail_service_1 = require('./shared/trail.service');
var TrailsComponent = (function () {
    function TrailsComponent(trailService) {
        this.trailService = trailService;
    }
    TrailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.trailService.getTrails().then(function (trails) { return _this.trails = trails; });
    };
    TrailsComponent.prototype.onSelect = function (trail) {
        this.selectedTrail = trail;
    };
    TrailsComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'pt-trails',
            templateUrl: 'trails.component.html',
            providers: [trail_service_1.TrailService]
        }), 
        __metadata('design:paramtypes', [trail_service_1.TrailService])
    ], TrailsComponent);
    return TrailsComponent;
}());
exports.TrailsComponent = TrailsComponent;
//# sourceMappingURL=trails.component.js.map