import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { GetallComponent } from './components/getall/getall.component';
import { RouterModule } from '@angular/router';                                     // RouterModule |ishlashi uchun
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CreateComponent } from './components/create/create.component';
import { FormsModule } from '@angular/forms';
import { UpdateComponent } from './components/update/update.component';
import { DeleteComponent } from './components/delete/delete.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GetallComponent,
    CreateComponent,
    UpdateComponent,
    DeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule, 
    RouterModule, // routerLink to'g'ri ishlashi uchun(pagedan pagega otayotganda refresh bolmasligi uchun)
    FormsModule,  // NgModel to'gri ishlashi uchun
    HttpClientModule // Service Ichidagi HttpClient To'gri ishlashii uchun
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
