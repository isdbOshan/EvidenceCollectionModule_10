import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { Section } from 'src/app/models/section';
import { NotifyService } from 'src/app/services/notify.service';
import { ProductService } from 'src/app/services/product.service';
import { SectionService } from 'src/app/services/section.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  products:Product = {};
  sections:Section[] = [];
  productForm:FormGroup = new FormGroup({
    productName:new FormControl('', [Validators.required]),
    sectionId:new FormControl(undefined, [Validators.required])
  });
  constructor(
    private productSvc:ProductService,
    private nptifySvc:NotifyService,
    private sectionSvc:SectionService,
    private activatedRoute:ActivatedRoute
  ){}

 
  get f(){
    return this.productForm.controls;
  }
  save(){
    if(this.productForm.invalid) return;
    Object.assign(this.products, this.productForm.value);
    this.productSvc.put(this.products)
      .subscribe({
        next:r=>{
          this.nptifySvc.notify("Data Updated", "DISMISS");
        },
        error:er=>{
          this.nptifySvc.notify("Data Update Failed", "DISMISS");
        }
      })
  }
  ngOnInit(): void {
    let id:number = this.activatedRoute.snapshot.params['id'];
    this.productSvc.getById(id)
      .subscribe({
        next:r=>{
          this.products = r;
          this.productForm.patchValue(this.products);
        },
        error:er=>{
          this.nptifySvc.notify("Failed to load products", "DISMISS");
        }
      })
      this.sectionSvc.get()
        .subscribe({
          next:r=>{
            this.sections =r;
            
          },
          error:er=>{
            this.nptifySvc.notify("Failed to load section", "DISMISS");
          }
        })
  }
  
}