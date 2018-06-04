import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { BaseMenuComponent } from '../shared/base-menu.component';

/**
 * Represents the navigation menu component.
 */
@Component({
    selector: 'nav-menu',
    template: require('./navmenu.component.html'),
    styles: [require('./navmenu.component.css')]
})
export class NavMenuComponent extends BaseMenuComponent implements OnInit {

    /**
     * Creates the NavMenuComponent.
     */
    constructor(
        private readonly router: Router) {
        super();
    }

    /**
     * Initialize the NavMenuComponent menu entries.
     */
    public ngOnInit(): void {
        this.buildMenu();
    }


    /**
     * Builds the navigation menu.
     */
    private buildMenu(): void {

        this.addMenuItem('Home', 'fa fa-user-circle', '/home');
        var ReferentialMenu = this.addMenuItem('Referencials', 'fa fa-plane', '#');
        this.addSubMenuTo(ReferentialMenu, 'Flight - Listing', 'fa fa-plane', '/flights');
        this.addSubMenuTo(ReferentialMenu, 'Flight - Creation', 'fa fa-plane', '/flight-form');
        this.addSubMenuTo(ReferentialMenu, 'Airport - Listing', 'fa fa-plane', '/airports');
        this.addSubMenuTo(ReferentialMenu, 'Aircraft-Listing', 'fa fa-plane', '/aircrafts');
        this.addMenuItem('Reports', 'fa fa-bar-chart', '/report');
    }
}
