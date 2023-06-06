import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SectionModel } from 'src/app/models/data/section-model';
import { SectionService } from 'src/app/services/data/section.service';

@Component({
  selector: 'app-section-create',
  templateUrl: './section-create.component.html',
  styleUrls: ['./section-create.component.css']
})
export class SectionCreateComponent {

  section: SectionModel={};
  sectionForm: FormGroup= new FormGroup({
    sectionName: new FormControl('', [Validators.required, Validators.maxLength(50)] )
  });
  constructor(
    private sectionSvc:SectionService

  ){}
  get f(){
    return this.sectionForm.controls;
  }
  save(){
    if(this.sectionForm.invalid) return;
    Object.assign(this.section, this.sectionForm.value);
    //console.log(this.department);
    this.sectionSvc.post(this.section)
    .subscribe({
      next:r=>{
        //console.log(r);

        this.section={};
        this.sectionForm.reset({});
        this.sectionForm.markAsPristine();
        this.sectionForm.markAsUntouched();
      },
      error:err=>{
        console.log(err);

      }
    })
  }
}
