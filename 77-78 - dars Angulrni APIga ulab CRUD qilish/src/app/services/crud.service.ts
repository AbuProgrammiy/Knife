import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../models/person';          // Persson |ishlashi uchun
import { PersonDTO } from '../models/person-dto';   // PersonDTO |ishlashi uchun

@Injectable({
  providedIn: 'root'
})
export class CRUDService {

  baseUrl:string="https://localhost:7076/api/";

  constructor(private httpClient : HttpClient) { }
  /*                         ^^^^^^^^^^ -> HttpClient togri ishlashi uchun app.module.ts da
                                              HttpClientModule import qilinishi kerak*/

  getAll():Observable<Person[]>{
  //                  ^^^^ -> Person model
    return this.httpClient.get<Person[]>(this.baseUrl+"Person/GetAll");
  }

  getById(id:number):Observable<Person>{
    return this.httpClient.get<Person>(this.baseUrl+`Person/GetById?id=${id}`)
  }

  create(data:PersonDTO):Observable<string>{
    return this.httpClient.post<string>(this.baseUrl+"Person/Create",data);
  }

  update(id:number,data:PersonDTO):Observable<string>{
    return this.httpClient.put<string>(this.baseUrl+`Person/Update?id=${id}`,data)
  }

  delete(id:number):Observable<string>{
    return this.httpClient.delete<string>(this.baseUrl+`Person/Delete?id=${id}`)
  }
}
