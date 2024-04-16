import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';                // HomeComponent |ishlashi uchun
import { GetallComponent } from './components/getall/getall.component';     // GetallComponent |ishlashi uchun

const routes: Routes = [
  {path:"", component: HomeComponent},
  {path:"getall" , component: GetallComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
