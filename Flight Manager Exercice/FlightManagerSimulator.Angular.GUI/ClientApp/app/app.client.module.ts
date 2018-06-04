import { NgModule, LOCALE_ID, NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Routes, RouterModule } from '@angular/router';

import { AppRoutingModule } from './app.routing';
import { AppComponent } from './components/app/app.component'
import { sharedConfig } from './app.module.shared';

import { AircraftService } from './services/aircraft.service'
import { AirportService } from './services/airport.service'
import { FlightService } from './services/flight.service'
import { ReportService } from './services/report.service'


@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpModule,
        ReactiveFormsModule,
        AppRoutingModule
    ],
    entryComponents: sharedConfig.entryComponents,
    providers: [
        AircraftService,
        AirportService,
        FlightService,
        ReportService
    ]
})
export class AppModule {
}
