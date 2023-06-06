import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Section } from 'src/app/models/section';
import { NotifyServicesService } from 'src/app/services/notify-services.service';
import { SectionService } from 'src/app/services/section.service';

@Component({
  selector: 'app-section-edit',
  templateUrl: './section-edit.component.html',
  styleUrls: ['./section-edit.component.css']
})
export class SectionEditComponent implements OnInit {

  section:Section = {};
  sectionForm:FormGroup = new FormGroup({
    sectionName:new FormControl('', [Validators.required, Validators.maxLength(50)])
  });
  constructor(
    private sectionSvc:SectionService,
    private notifySvc:NotifyServicesService,
    private actvatedRoute:ActivatedRoute
  ){}
  get f(){
    return this.sectionForm.controls;
  }
  save(){
      if(this.sectionForm.invalid) return;
      Object.assign(this.section, this.sectionForm.value);
      this.sectionSvc.put(this.section)
      .subscribe({
        next:r=>{
          this.notifySvc.openSnackBar("Data Updated Successfully", "DISMISS");
        },
        error: err=>{
          this.notifySvc.openSnackBar("Failed to Update", "DISMISS")
        }
      })
  }
  ngOnInit(): void {
    let id:number = this.actvatedRoute.snapshot.params['id'];
    this.sectionSvc.getById(id)
    .subscribe({
      next:r=>{
        console.log(r);
        this.section=r;
        this.sectionForm.patchValue(this.section)
      }, error:err=>{
        console.log(err.message || err);
        this.notifySvc.openSnackBar("Failed to load Section", "DISMISS");
      }
    })
  }

}