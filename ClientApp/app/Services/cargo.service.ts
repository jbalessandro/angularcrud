import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { ICargo } from '../Models/cargo.interface';

@Injectable()
export class CargoService {

    constructor(private http: Http) {        
    }

    // get
    getCargos() {
        return this.http.get("/api/cargos")
            .map(data => <ICargo[]>data.json());
    }

    //post
    addCargo(cargo: ICargo) {
        return this.http.post("/api/cargos", cargo);
    }

    //put /api/cargos/1
    updCargo(cargo: ICargo) {
        return this.http.put(`/api/cargos/${cargo.cargoId}`, cargo);
    }

    //delete /api/cargos/1
    delCargo(cargoId: number) {
        return this.http.delete(`/api/cargos/${cargoId}`);
    }
}
