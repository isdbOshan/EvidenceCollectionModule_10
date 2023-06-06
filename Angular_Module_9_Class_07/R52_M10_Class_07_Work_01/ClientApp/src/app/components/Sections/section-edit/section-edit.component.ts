import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Section } from 'src/app/models/section';
import { SectionService } from 'src/app/Services/section.service';

@Component({
  selector: 'app-section-edit',
  templateUrl: './section-edit.component.html',
  styleUrls: ['./section-edit.component.css']
})
export class SectionEditComponent {
  section:Section = {};
  sectionform:FormGroup = new FormGroup({
    sectionName:new FormControl('', [Validators.required, Validators.maxLength(50)])
  });
  constructor(
    private sectionsrv:SectionService,
    private actvatedRoute:ActivatedRoute
  ){}
  get f(){
    return this.sectionform.controls;
  }
  save(){
      if(this.sectionform.invalid) return;
      Object.assign(this.section, this.sectionform.value);
      this.sectionsrv.put(this.section)
      .subscribe({
        next:r=>{
         
        },
        error: err=>{
         
        }
      })
  }
  ngOnInit(): void {
    let id:number = this.actvatedRoute.snapshot.params['id'];
    console.log(id);
    this.sectionsrv.getById(id)
    .subscribe({
      next:r=>{
        console.log(r);
        this.section=r;
        this.sectionform.patchValue(this.section)
      }, error:err=>{
        console.log(err.message || err);
       
      }
    })
  }
}
