import { Component, OnInit } from '@angular/core';

import { Flight } from '../../../../models/flight/flight.model';
import { Airport } from '../../../../models/flight/airport.model';
import { Aircraft } from '../../../../models/flight/aircraft.model';
import { ResultStatus } from '../../../../enums/result-status.enum';

import { FlightService } from '../../../../services/flight.service';

@Component({
    selector: 'flight-list',
    templateUrl: './flight-list.component.html'
})
export class FlightListComponent implements OnInit {

    public flightList: Array<Flight>;

    constructor(private flightService: FlightService) {
        this.flightList = new Array<Flight>()
    }

    ngOnInit() {
        this.flightService.getFilteredFlightsResult(null, 0, 20).subscribe(flights =>
            this.flightList.concat(flights)
        );
    }
}
