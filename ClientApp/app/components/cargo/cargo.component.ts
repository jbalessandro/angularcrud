import { Component, OnInit } from '@angular/core';
import { CargoService } from '../../Services/cargo.service';
import { ICargo } from '../../Models/cargo.interface';
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'app-cargo',
    templateUrl: './cargo.component.html'
})
export class CargoComponent implements OnInit {

    cargos: ICargo[] = [];
    cargo: ICargo = <ICargo>{};

    // formulario
    formLabel: string;
    isEditMode: boolean = false;
    isForm: boolean = false;
    btnGravarValue: string = "Incluir";

    form: FormGroup

    constructor(private cargoService: CargoService, private fb: FormBuilder) {

        this.form = fb.group({
            "cargoId": [0],
            "descricao": ["", Validators.required ]
        });

        this.formLabel = "Adicionar Cargo";
    }

    private getCargos() {
        this.cargoService.getCargos().subscribe(
            data => this.cargos = data,
            error => alert(error),
            () => console.log(this.cargos)
        );
    }

    onSubmit() {

        this.cargo.ativo = true;
        this.cargo.cargoId = this.form.controls["cargoId"].value;
        this.cargo.descricao = this.form.controls["descricao"].value;
        if (this.isEditMode) {
            this.cargoService.updCargo(this.cargo).
                subscribe(response => {
                    this.getCargos();
                    this.isForm = false;
                    this.form.reset();
                });
        } else {
            this.cargoService.addCargo(this.cargo)
                .subscribe(response => {
                    this.getCargos();
                    this.isForm = false;
                    this.form.reset();
                });
        }

    };

    edit(cargo: ICargo) {
        this.formLabel = "Editar cargo";
        this.isEditMode = true;
        this.isForm = true;
        this.btnGravarValue = "Gravar";
        this.cargo = cargo;
        
        this.form.get("cargoId")!.setValue(cargo.cargoId);
        this.form.get("descricao")!.setValue(cargo.descricao);
    };

    delete(cargo: ICargo) {
        if (confirm("Deseja excluir este cliente ?")) {
            this.cargoService.delCargo(cargo.cargoId)
                .subscribe(response => {
                    this.getCargos();
                    this.form.reset();
                });
        }
    };

    cancel() {
        this.formLabel = "Adicionar cargo";
        this.isEditMode = false;
        this.isForm = false;
        this.btnGravarValue = "Incluir";
        this.cargo = <ICargo>{};
        this.form.get("descricao")!.setValue("");
    }

    showForm() {
        this.cancel();
        this.isForm = true;
    }

    ngOnInit() {
        this.getCargos();
    }
}