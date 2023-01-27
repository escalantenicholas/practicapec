import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Trabajador } from '../models/Trabajador';

@Injectable({
  providedIn: 'root'
})
export class TrabajadorService {

  private myAppUrl: string;
  private myApiUrl: string;

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.endpoint;
    this.myApiUrl = 'Trabajador';
   }

   getTrabajadores(): Observable<Trabajador[]> {
    return this.http.get<Trabajador[]>(`${this.myAppUrl}${this.myApiUrl}`);
   }

   getTrabajadorById(tariffGuid:string): Observable<Trabajador> {
    return this.http.get<Trabajador>(`${this.myAppUrl}${this.myApiUrl}/${tariffGuid}`);
   }
}
