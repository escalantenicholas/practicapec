import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TrabajadorComponent } from './components/trabajador/trabajador.component';
import { TrabajadorporidComponent } from './components/trabajadorporid/trabajadorporid.component';

const routes: Routes = [
  {path: '', component: TrabajadorComponent},
  {path: ':dni', component: TrabajadorporidComponent},
  {path: '**', redirectTo:'', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
