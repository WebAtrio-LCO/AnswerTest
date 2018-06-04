export class MenuItem {
    public subMenuItems: Array<MenuItem>;

    constructor(
        public title: string,
        public icon: string,
        public target: string
    ) {
        this.subMenuItems = new Array<MenuItem>();
    }
}