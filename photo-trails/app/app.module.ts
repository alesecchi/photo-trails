import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TrailComponent } from './trails/trail/trail.component'
import { TrailsComponent } from './trails/trails.component'
import { MapComponent } from './map/map.component'

@NgModule({
  imports: [BrowserModule,
    HttpModule],
  declarations: [AppComponent,
    MapComponent,
    TrailComponent,
    TrailsComponent],
  bootstrap: [AppComponent],
})
export class AppModule { }