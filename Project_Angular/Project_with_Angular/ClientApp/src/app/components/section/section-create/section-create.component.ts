import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Section } from 'src/app/models/section';
import { NotifyServicesService } from 'src/app/services/notify-services.service';
import { SectionService } from 'src/app/services/section.service';

@Component({
  selector: 'app-section-create',
  templateUrl: './section-create.component.html',
  styleUrls: ['./section-create.component.css']
})
export class SectionCreateComponent {
  section:Section = {};
  sectionForm:FormGroup = new FormGroup({
    sectionName:new FormControl('', [Validators.required, Validators.maxLength(50)])
  });
  constructor(
    private sectionSvc:SectionService,
    private notifySvc:NotifyServicesService
  ){}
  get f(){
    return this.sectionForm.controls;
  }
  save(){
    if(this.sectionForm.invalid) return;
    Object.assign(this.section, this.sectionForm.value);
    this.sectionSvc.post(this.section)
    .subscribe({
      next:r=>{
        console.log(r);
        this.notifySvc.openSnackBar("Data saved successfully", 'DISMISS');
        this.section={};
        this.sectionForm.reset({});
        this.sectionForm.markAsPristine();
        this.sectionForm.markAsUntouched();
      },
      error:err=>{
        console.log(err);
        this.notifySvc.openSnackBar("Failed to save data", 'DISMISS');
      }
    })
  }
}