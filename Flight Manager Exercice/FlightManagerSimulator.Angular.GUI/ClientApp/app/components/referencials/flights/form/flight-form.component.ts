import { Component, OnInit } from '@angular/core';

/**
 * TODO : find a way to change ../../../../
 */
import { Flight } from '../../../../models/flight/flight.model';
import { Airport } from '../../../../models/flight/airport.model';
import { Aircraft } from '../../../../models/flight/aircraft.model';
import { ResultStatus } from '../../../../enums/result-status.enum';

import { FlightService } from '../../../../services/flight.service';
import { AirportService } from '../../../../services/airport.service';
import { AircraftService } from '../../../../services/aircraft.service';

/**import { ToastrService } from 'ngx-toastr';*/


/**
 * Home component.
 */
@Component({
    selector: 'flight-form',
    templateUrl: './flight-form.component.html'
})
export class FlightFormComponent implements OnInit  {

    public flight: Flight;
    public airports: Array<Airport>;
    public aircrafts: Array<Aircraft>;

    constructor(/**private toastr: ToastrService,*/ private flightService: FlightService, private airportService: AirportService, private aircraftService: AircraftService) {
        this.flight = new Flight();
        this.airports = new Array<Airport>();
        this.aircrafts = Array<Aircraft>();
    }

    ngOnInit() {
        this.airportService.getAllAirport().subscribe(airports =>
            this.airports.concat(airports)
        );
    }


    /**
     * Save The current Flight
     */
    public SaveFlight(): void {
        if (this.flight.id > 0) {
            this.flightService.updateFlight(this.flight).subscribe(response => {
                /**if (response == ResultStatus.Success) {
                    this.toastr.success('The flight have been successfully updated');
                }
                else {
                    this.toastr.error('An error occured during update. Please Retry');
                }*/
            });
        }
        else {
            this.flightService.insertFlight(this.flight).subscribe(response => {
                /**if (response == ResultStatus.Success) {
                    this.toastr.success('The flight have been successfully added');
                }
                else {
                    this.toastr.error('An error occured during add. Please Retry');
                }*/
            });
        }
    }


    /**
     * Check if 
     * @param model
     * @param type
     */
    public isModelValid(model: any): boolean {
        var returnValue = (model.valid || model.pristine);
        return returnValue;
    }
}
