import { Component, OnInit } from '@angular/core';
import { Trabajador } from 'src/app/models/Trabajador';
import { TrabajadorService } from 'src/app/services/trabajador.service';
import { NgbPaginationModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { DecimalPipe, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-trabajador',
  templateUrl: './trabajador.component.html',
  styleUrls: ['./trabajador.component.css'],
})
export class TrabajadorComponent implements OnInit {

  listTrabajadores : Trabajador[] = []
  listTrabajadores_ : Trabajador[] = []

  page = 1;
	pageSize = 4;
	collectionSize = 0;

  constructor(private _trabajadorService: TrabajadorService)
  { this.refreshTrabajadores()}

  ngOnInit(): void {
    this.getListTrabajadores()

  }

  getListTrabajadores(){
    this._trabajadorService.getTrabajadores().subscribe((data) => {
      this.listTrabajadores = data;
      this.collectionSize = this.listTrabajadores.length;
      this.refreshTrabajadores()
    })
  }

  refreshTrabajadores() {
		this.listTrabajadores_ = this.listTrabajadores.map((item, i) => ({ id: i + 1, ...item })).slice(
			(this.page - 1) * this.pageSize,
			(this.page - 1) * this.pageSize + this.pageSize,
		);
	}

}
