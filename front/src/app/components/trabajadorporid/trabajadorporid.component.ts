
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Trabajador } from 'src/app/models/Trabajador';
import { TrabajadorService } from 'src/app/services/trabajador.service';

@Component({
  selector: 'app-trabajadorporid',
  templateUrl: './trabajadorporid.component.html',
  styleUrls: ['./trabajadorporid.component.css']
})
export class TrabajadorporidComponent implements OnInit {

  formTrabajador: FormGroup;

  public dni: string = "";
  public trabajador : Trabajador = new Trabajador;


  constructor(private fb: FormBuilder,
              private _trabajadorService: TrabajadorService,
              private _activatedRoute: ActivatedRoute,) {
    this.formTrabajador = this.fb.group({
      dni: [{value: '', disabled: true}, Validators.required],
      tipoTrabajador: [{value: '', disabled: true}, Validators.required],
      salario: [{value: 0, disabled: true}, Validators.required],

    });
   }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe((params) => {
      this.dni = params['dni'];
      this.getTrabajadorById(this.dni);
    })
  }

  getTrabajadorById(dni: string)
  {
    this._trabajadorService.getTrabajadorById(dni).subscribe((data) => {
      this.trabajador = data;
      this.formTrabajador.controls['dni'].setValue(this.trabajador.dni);
      this.formTrabajador.controls['tipoTrabajador'].setValue(this.trabajador.tipoTrabajador);
      this.formTrabajador.controls['salario'].setValue(this.trabajador.salario);
    })
  }



}
