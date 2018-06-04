import { Component, Input, Output, EventEmitter } from '@angular/core';

/**
 * Generic form component.
 */
@Component({
    selector: 'editable-form',
    template: require('./editable-form.component.html')
})
export class EditableFormComponent {
    @Input() sendButton: string = 'Save';
    @Output() onSent = new EventEmitter();

    /**
     * Creates form component.
     */
    constructor() { }

    /**
     * Send back form.
     */
    private sent(): void {
        this.onSent.emit();
    }
}
