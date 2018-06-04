import { DayOfWeek } from "../Enums/day-of-week.enum";

export class MenuItem {
    public identifier: string;
    public departureairport: number;
    public destinationairport: number;
    public aircraft: number;
    public day: DayOfWeek;


    constructor() {
        this.identifier = '';
        this.departureairport = 0;
        this.destinationairport = 0;
        this.aircraft = 0;
        this.day = DayOfWeek.None;
    }
}