import { Component, OnInit } from '@angular/core';            // Component, OnInit |ishlashi uchun
import { CRUDService } from '../../services/crud.service';    // CRUDService |ishlashi uchun
import { Person } from '../../models/person';                 // Person |ishlashi uchun

@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrl: './getall.component.scss'
})
export class GetallComponent implements OnInit { 
  /*                                    ^^^^^^ -> OnInit component chaqirilganda getAll funksiyani
                                                   avtomatik chaqirish uchun implement qilindi*/
  persons!: Person[];

  constructor (private crudService:CRUDService){}

  ngOnInit(): void {
// ^^^^^^^ -> OnInitni implement qilinishi kerak bolgan funksiyasi
      this.getAll()
  }

  getAll(){
    this.crudService.getAll().subscribe({/*
                              ^^^^^^^^^ -> async await bilan birxil*/
        next:(data)=>{
          this.persons=data;
          console.log(data);
          // ^-^^^-^ -> ma'lumot kelsa consolega yozadi
        },
        error:(err)=>{
          console.log(err);
          // ^-^^^-^ -> xatolik yuzbersa consolega yozadi
        }
    })
  }
}
