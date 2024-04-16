import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';              // User |ishlashi uchun

@Injectable({
  providedIn: 'root'
})
export class CRUDService {

  baseUrl:string="https://localhost:7016/api/Car/GetAll";

  constructor(private http : HttpClient) { }
  /*                         ^^^^^^^^^^ -> HttpClient togri ishlashi uchun app.module.ts da
                                              HttpClientModule import qilinishi kerak*/

  getAll():Observable<User[]>{
  //                  ^^^^ -> User model
    return this.http.get<User[]>(this.baseUrl);
  }
}
