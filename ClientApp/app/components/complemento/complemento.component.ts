import { Component, OnInit } from '@angular/core';
import { ComplementoService } from '../../Services/complemento.service';
import { IComplemento } from '../../Models/complemento.interface';

@Component({
    selector: 'app-complemento',
    templateUrl: './complemento.component.html'
})
export class ComplementoComponent implements OnInit {

    complementos: IComplemento[] = [];

    constructor(private complementoService: ComplementoService) { }

    private getComplementos() {
        this.complementoService.getComplementos().subscribe(
            data => this.complementos = data,
            error => alert(error),
            () => console.log(this.complementos)
        );
    }

    ngOnInit() {
        this.getComplementos();
    }
}