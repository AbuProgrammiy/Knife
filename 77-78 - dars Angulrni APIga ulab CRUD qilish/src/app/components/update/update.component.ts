import { Component } from '@angular/core';
import { CRUDService } from '../../services/crud.service';
import { PersonDTO } from '../../models/person-dto';        // PersonDTO |ishlashi uchun

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrl: './update.component.scss'
})
export class UpdateComponent {

  id!:number

  personDTO:PersonDTO={
    Name:"",
    Age:0
  };

  constructor(private crudService:CRUDService){}

  update(){
    this.crudService.update(this.id,this.personDTO).subscribe({/*
                              ^^^^^^^^^ -> async await bilan birxil*/
      next:(data)=>{
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
