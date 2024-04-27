import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';                // HomeComponent |ishlashi uchun
import { GetallComponent } from './components/getall/getall.component';     // GetallComponent |ishlashi uchun
import { CreateComponent } from './components/create/create.component';
import { DeleteComponent } from './components/delete/delete.component';
import { UpdateComponent } from './components/update/update.component';

const routes: Routes = [
  {path:"", component: HomeComponent},
  {path:"getall" , component: GetallComponent},
  {path:"create",component:CreateComponent},
  {path:"update",component:UpdateComponent},
  {path:"delete",component:DeleteComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
