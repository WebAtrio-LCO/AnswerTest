import { AircraftReport } from './aircraft-report.model';
import { AirportReport } from './airport-report.model';
import { DayOfWeek } from '../../enums/day-of-week.enum';


export class Report {
    public flightCount: number;
    public totalFuelNeeded: number;
    public totalTraveledDistance: number;
    public averageDistance: number;
    public minimalDistance: number;
    public maximalDistance: number;

    constructor() {
        this.flightCount = 0;
        this.totalFuelNeeded = 0;
        this.totalTraveledDistance = 0;
        this.averageDistance = 0;
        this.minimalDistance = 0;
        this.maximalDistance = 0;
    }
}