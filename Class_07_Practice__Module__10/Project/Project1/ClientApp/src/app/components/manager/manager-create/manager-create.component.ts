import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Manager } from 'src/app/models/manager';
import { Product } from 'src/app/models/product';
import { ManagerService } from 'src/app/services/manager.service';
import { NotifyService } from 'src/app/services/notify.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-manager-create',
  templateUrl: './manager-create.component.html',
  styleUrls: ['./manager-create.component.css']
})
export class ManagerCreateComponent implements OnInit {
  managers:Manager = {};
  products:Product[] = [];
  ManagerForm:FormGroup = new FormGroup({
    managerName:new FormControl('', [Validators.required]),
    picture:new FormControl('', [Validators.required]),
    productId:new FormControl(undefined, [Validators.required])
  });
  constructor(
    private managerSvc:ManagerService,
    private productSvc:ProductService,
    private nptifySvc:NotifyService
  ){}
 
 
  get f(){
    return this.ManagerForm.controls;
  }
  save(){
    if(this.ManagerForm.invalid) return;
    Object.assign(this.managers, this.ManagerForm.value);
    this.managerSvc.post(this.managers)
      .subscribe({
        next:r=>{
          this.managers = {};
          this.ManagerForm.reset({});
          this.ManagerForm.markAsPristine();
          this.ManagerForm.markAsUntouched();
          this.nptifySvc.notify("Data Saved", "DISMISS");
        },
        error:er=>{
          this.nptifySvc.notify("Data Save Failed", "DISMISS");
        }
    })
  }
  ngOnInit(): void {
    this.productSvc.get()
      .subscribe({
        next:r=>{
          this.products = r;
        },
        error:er=>{
          this.nptifySvc.notify("section load Failed", "DISMISS");
        }
      })
    }
  }


