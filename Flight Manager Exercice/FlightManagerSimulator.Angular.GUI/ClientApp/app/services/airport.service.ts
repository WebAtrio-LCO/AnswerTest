import { Injectable, Injector } from '@angular/core';
import { Observable } from "rxjs/Observable";

import { BaseService } from './base.service';
import { ResultStatus } from '../enums/result-status.enum';
import { Airport } from '../models/flight/airport.model';

/**
 * airport service
 */
@Injectable()
export class AirportService extends BaseService {

    /**
     * airport  constructor
     * @param injector Angular injector
     */
    constructor(private injector: Injector) {
        super(injector);
    }

    /**
 * Returns the filtered airport results list.
 */
    public getAllAirport(): Observable<Array<Airport>> {
        return this.get<Array<Airport>>(`/api/airports/all`);
    }
}