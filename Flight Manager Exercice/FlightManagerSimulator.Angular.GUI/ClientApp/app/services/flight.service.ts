import { Injectable, Injector } from '@angular/core';
import { Observable } from "rxjs/Observable";

import { BaseService } from './base.service';
import { ResultStatus } from '../enums/result-status.enum';
import { Flight } from '../models/flight/flight.model';

/**
 * Flight service
 */
@Injectable()
export class FlightService extends BaseService {

    /**
     * flight  constructor
     * @param injector Angular injector
     */
    constructor(private injector: Injector) {
        super(injector);
    }

    /**
     * Returns the filtered flights results list.
     */
    public getFilteredFlightsResult(content: any, skip: number = 0, take: number = 20): Observable<Array<Flight>> {
        return this.post<Array<Flight>>(`/api/flights/${skip}/${take}`, content);
    }

    /**
     * Get the number of flights.
     */
    public getCount(content: any): Observable<number> {
        return this.post<number>(`/api/flights/count`, content);
    }

    /**
     * Update flight.
     * @param flight Flight to update.
     */
    public updateFlight(flight: Flight): Observable<ResultStatus> {
        return this.put<ResultStatus>(`/api/flights`, flight);
    }

    /**
     * Insert Flight.
     * @param flight Flight to update.
     */
    public insertFlight(flight: Flight): Observable<ResultStatus> {
        return this.post<ResultStatus>(`/api/flights`, flight);
    }
}