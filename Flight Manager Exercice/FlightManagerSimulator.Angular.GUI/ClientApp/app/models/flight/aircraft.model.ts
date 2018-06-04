export class Aircraft {
    public id: number;
    public name: string;
    public maxspeed: number;
    public InFlyFuelConsumption: number;
    public InTakeOffConsumption: number;
    public PassengerCapacity: number;
    public count: number;

    constructor() {
        this.id = 0;
        this.name = '';
        this.maxspeed = 0;
        this.InFlyFuelConsumption = 0;
        this.InTakeOffConsumption = 0;
        this.PassengerCapacity = 0;
        this.count = 0;
    }
}