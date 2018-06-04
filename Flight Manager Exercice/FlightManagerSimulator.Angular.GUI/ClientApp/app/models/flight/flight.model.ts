import { Aircraft } from './aircraft.model';
import { Airport } from './airport.model';
import { DayOfWeek } from '../../enums/day-of-week.enum';

/**
 * Front side model for flight. It will be sent or fill through json
 */
export class Flight {
    public id: number;
    public identifier: string;
    public departureAirport: Airport;
    public arrivalAirport: Airport;
    public aircraft: Aircraft;
    public day: DayOfWeek;
    public distance: number;
    public fuelNeeded: number;

    constructor() {
        this.id = 0;
        this.identifier = '';
        this.day = DayOfWeek.None;
        this.distance = 0;
        this.fuelNeeded = 0;

        this.departureAirport = new Airport();
        this.arrivalAirport = new Airport();
        this.aircraft = new Aircraft();
    }
}