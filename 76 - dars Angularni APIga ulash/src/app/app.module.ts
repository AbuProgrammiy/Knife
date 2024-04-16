import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { GetallComponent } from './components/getall/getall.component';
import { RouterModule } from '@angular/router';                                     // RouterModule |ishlashi uchun
import { HttpClientModule } from '@angular/common/http';                            // HttpClientModule |ishlashi uchun

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GetallComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule, /* routerLink to'g'ri ishlashi uchun(pagedan pagega
                      otayotganda refresh bolmasligi uchun)*/

    HttpClientModule /*Servise ichidagi HttpClient togri ishlashi uchun import qilindi */
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
