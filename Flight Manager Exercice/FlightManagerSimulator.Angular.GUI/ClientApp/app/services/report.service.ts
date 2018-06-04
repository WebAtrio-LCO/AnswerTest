import { Injectable, Injector } from '@angular/core';
import { Observable } from "rxjs/Observable";

import { BaseService } from './base.service';
import { ResultStatus } from '../enums/result-status.enum';
import { Flight } from '../models/flight/flight.model';
import { Report } from '../models/report/report.model';

/**
 * Device service
 */
@Injectable()
export class ReportService extends BaseService {

    /**
     * Device constructor
     * @param injector Angular injector
     */
    constructor(private injector: Injector) {
        super(injector);
    }

    /**
     * Returns the filtered devices results list.
     */
    public getReport(): Observable<Report> {
        return this.get<Report>(`/api/report`);
    }
}