import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { retry } from 'rxjs';
import { Section } from 'src/app/models/section';
import { NotifyService } from 'src/app/services/notify.service';
import { SectionService } from 'src/app/services/section.service';

@Component({
  selector: 'app-section-create',
  templateUrl: './section-create.component.html',
  styleUrls: ['./section-create.component.css']
})
export class SectionCreateComponent {
  sections:Section = {};
  sectionForm:FormGroup = new FormGroup({
    sectionName:new FormControl('', [Validators.required])
  });
  constructor(
    private sectionSvc:SectionService,
    private notifySvc:NotifyService
  ){}
  get f(){
    return this.sectionForm.controls;
  }
  save(){
    if(this.sectionForm.invalid) return;
    Object.assign(this.sections, this.sectionForm.value);
    this.sectionSvc.post(this.sections)
      .subscribe({
        next:r=>{
          this.sections = {};
          this.sectionForm.reset({});
          this.sectionForm.markAsPristine();
          this.sectionForm.markAsUntouched();
          this.notifySvc.notify("Data Saved", "DISMISS");
        },
        error:er=>{
          this.notifySvc.notify("Data Save Failed", "DISMISS");
        }
      })
  }
}
