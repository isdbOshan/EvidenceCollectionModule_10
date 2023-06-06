import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Section } from 'src/app/models/section';
import { NotifyService } from 'src/app/services/notify.service';
import { SectionService } from 'src/app/services/section.service';

@Component({
  selector: 'app-section-edit',
  templateUrl: './section-edit.component.html',
  styleUrls: ['./section-edit.component.css']
})
export class SectionEditComponent implements OnInit {

  sections:Section = {};
  sectionForm:FormGroup = new FormGroup({
    sectionName:new FormControl('', [Validators.required])
  });
  constructor(
    private sectionSvc:SectionService,
    private notifySvc:NotifyService,
    private activatedRoute:ActivatedRoute
  ){}
  get f(){
    return this.sectionForm.controls;
  }
  save(){
    if(this.sectionForm.invalid) return;
    Object.assign(this.sections, this.sectionForm.value);
    this.sectionSvc.put(this.sections)
      .subscribe({
        next:r=>{
          this.notifySvc.notify("Data Updated", "DISMISS");
        },
        error:er=>{
          this.notifySvc.notify("Data Update Failed", "DISMISS");
        }
      })
  }
  ngOnInit(): void {
    let id:number = this.activatedRoute.snapshot.params['id'];
    this.sectionSvc.getById(id)
      .subscribe({
        next:r=>{
          this.sections = r;
          this.sectionForm.patchValue(this.sections);
        },
        error:er=>{
          this.notifySvc.notify("Failed to load section", "DISMISS");
        }
      })
  }

}
