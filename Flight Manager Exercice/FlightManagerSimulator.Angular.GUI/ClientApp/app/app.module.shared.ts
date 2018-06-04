import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ReportComponent } from './components/report/report.component';
import { FlightListComponent } from './components/referencials/flights/list/flight-list.component';
import { FlightFormComponent } from './components/referencials/flights/form/flight-form.component';
import { AircraftListComponent } from './components/referencials/aircrafts/list/aircraft-list.component';
import { AirportListComponent } from './components/referencials/airports/list/airport-list.component';
import { EditableFormComponent } from './components/shared/editable-form.component';
import { FilterContainerComponent } from './components/shared/filters/filter-container.component';

 /**import { InfiniteScrollModule } from 'ngx-infinite-scroll';*/
/**import { ToastrModule } from 'ngx-toastr';*/



export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ReportComponent,
        FlightListComponent,
        FlightFormComponent,
        AircraftListComponent,
        AirportListComponent,
        EditableFormComponent,
        FilterContainerComponent
    ],
    imports: [
        /**InfiniteScrollModule,*/
        /**ToastrModule.forRoot(),*/
    ]
}
