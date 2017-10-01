import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { CargoService } from './Services/cargo.service';
import { ComplementoService } from './Services/complemento.service';
import { ReactiveFormsModule } from "@angular/forms";


@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared,
        ReactiveFormsModule
    ],
    providers: [
        CargoService,
        ComplementoService,
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
