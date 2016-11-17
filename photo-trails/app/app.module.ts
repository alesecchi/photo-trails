import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent }   from './app.component';
import { TrailComponent } from './trails/trail/trail.component'
import { TrailsComponent } from './trails/trails.component'

@NgModule({
  imports:      [ BrowserModule ],
  declarations: [ AppComponent,
                  TrailComponent,
                  TrailsComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }