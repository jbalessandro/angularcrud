import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { IComplemento } from '../Models/complemento.interface';

@Injectable()
export class ComplementoService {

    constructor(private http: Http) { }

    // get
    getComplementos() {
        return this.http.get("/api/complementos").map(data => <IComplemento[]>data.json());
    }

    //post
    //put
    //delete
}