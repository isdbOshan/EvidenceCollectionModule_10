import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Section } from 'src/app/models/section';
import { SectionService } from 'src/app/Services/section.service';

@Component({
  selector: 'app-section-create',
  templateUrl: './section-create.component.html',
  styleUrls: ['./section-create.component.css']
})
export class SectionCreateComponent {
  department:Section = {};
  sectionform:FormGroup = new FormGroup({
    sectionName:new FormControl('', [Validators.required, Validators.maxLength(50)])
  });
  constructor(
    private sectionsrv:SectionService
  ){}
  get f(){
    return this.sectionform.controls;
  }
  save(){
    if(this.sectionform.invalid) return;
    Object.assign(this.department, this.sectionform.value);
    //console.log(this.department);
    this.sectionsrv.post(this.department)
    .subscribe({
      next:r=>{
        console.log(r);
        this.department={};
        this.sectionform.reset({});
        this.sectionform.markAsPristine();
        this.sectionform.markAsUntouched();
      },
      error:err=>{
        console.log(err);
      }
    })
  }
}
