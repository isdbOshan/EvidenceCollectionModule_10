import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Manager } from 'src/app/models/manager';
import { Product } from 'src/app/models/product';
import { Section } from 'src/app/models/section';
import { ManagerService } from 'src/app/Services/manager.service';
import { NotifyService } from 'src/app/Services/notify.service';
import { SectionService } from 'src/app/Services/section.service';

@Component({
  selector: 'app-manager-create',
  templateUrl: './manager-create.component.html',
  styleUrls: ['./manager-create.component.css']
})
export class ManagerCreateComponent implements OnInit {
  manager:Manager ={};
  managerForm:FormGroup = new FormGroup({
    managerName: new FormControl('', Validators.required),
    picture: new FormControl('', Validators.required),
    sectionId: new FormControl(undefined),
    productId: new FormControl(undefined, Validators.required)
  });
  //for dropdowns
  sections:Section[] =[];
  products:Product[] =[];
  //for picture
  pic:File=null!;
  constructor(
    private managerSvc:ManagerService,
    private sectionSvc:SectionService,
    private notifySvc: NotifyService
  ){}
  get f(){
    return this.managerForm.controls;
  }
  save(){

  }
  sectionCahnged(event:any){
    console.log(event.value);
    let id=event.value;
    this.products=[];
    this.sectionSvc.getSectionProduct(id)
    .subscribe({
      next:r=>{
        this.products=r;
      },
      error:err=>{
        this.notifySvc.notify("Failed to load products", "DISMISS");
      }
    })
  }
  ngOnInit(): void {
    this.sectionSvc.get()
    .subscribe({
      next: r=>{
        this.sections=r;
        
      },
      error:err=>{
        this.notifySvc.notify("Failed to load sections", "DISMISS");
      }
    })
  }
}
