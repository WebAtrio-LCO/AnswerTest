import { Component, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'filter-container',
    template: require('./filter-container.component.html')
})
/**
 * Component to centralized calling to apply or reset filter.
 * Next step should br to create generic control (input text/radio/checkbox) to write and manage html once
 */
export class FilterContainerComponent {
    @Output() onApply = new EventEmitter();
    @Output() onReset = new EventEmitter();

    constructor() { }

    /**
     * Emits an apply event to apply the selected filters
     */
    public apply(): void {
        this.onApply.emit();
    }

    /**
     * Emits a reset event to reset the filters
     */
    public reset(): void {
        this.onReset.emit();
    }
}