import { Injectable, Injector } from '@angular/core';
import { Observable } from "rxjs/Observable";

import { BaseService } from './base.service';
import { ResultStatus } from '../enums/result-status.enum';
import { Aircraft } from '../models/flight/aircraft.model';

/**
 * airport service
 */
@Injectable()
export class AircraftService extends BaseService {

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
    public getFilteredFlightsResult(day: number): Observable<Array<Aircraft>> {
        return this.get<Array<Aircraft>>(`/api/aircrafts/all/{day}`);
    }
}