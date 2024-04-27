import { Component } from '@angular/core';
import { CRUDService } from '../../services/crud.service';
import { PersonDTO } from '../../models/person-dto';          // PersonDTO |ishlashi uchun

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss'
})
export class CreateComponent {

  personDTO:PersonDTO={
    Name:"",
    Age:0
  }

  constructor(private crudService:CRUDService){}

  create(){
    this.crudService.create(this.personDTO).subscribe({/*
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
