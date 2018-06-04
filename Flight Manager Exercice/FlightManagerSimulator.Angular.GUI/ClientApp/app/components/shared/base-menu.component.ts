/**
 * TODO : Find a bette way to navigate through folders
 */
import { MenuItem } from '../../models/menu-item.model';

/**
 * Base menu component providing the whole menu management system.
 */
export abstract class BaseMenuComponent {
    private internalMenuItems: Array<MenuItem>;

    /**
     * Gets the menu items.
     */
    public get menuItems(): Array<MenuItem> {
        return this.internalMenuItems;
    }

    /**
     * Creates and initialize the BaseMenuComponent.
     */
    constructor() {
        this.internalMenuItems = new Array<MenuItem>();
    }

    /**
     * Adds a new menu to root menu.
     * @param title Menu title
     * @param icon Menu icon
     * @param target Menu target url
     */
    protected addMenuItem(title: string, icon: string, target: string): MenuItem {
        var item = new MenuItem(title, icon, target);

        this.internalMenuItems.push(item);

        return item;
    }

    /**
     * Add a new sub menu to another menu.
     * @param menu Parent menu
     * @param title Menu title
     * @param icon Menu icon
     * @param target Menu target url
     */
    protected addSubMenuTo(menu: MenuItem, title: string, icon: string, target: string): void {
        var item = new MenuItem(title, icon, target);

        menu.subMenuItems.push(item);
    }

    protected clearMenu(): void {
        this.internalMenuItems = new Array<MenuItem>()
    }
}