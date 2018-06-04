import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppRoutingModule } from './app.routing';

import { AppComponent } from './components/app/app.component';

import { sharedConfig } from './app.module.shared';


@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        ServerModule,
        AppRoutingModule
    ]
})
export class AppModule {
}
