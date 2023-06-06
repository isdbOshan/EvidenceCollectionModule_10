import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/app/models/product';
import { Section } from 'src/app/models/section';
import { NotifyServicesService } from 'src/app/services/notify-services.service';
import { ProductService } from 'src/app/services/product.service';
import { SectionService } from 'src/app/services/section.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  products:Product = {};
  sections:Section[]=[];
  productForm:FormGroup = new FormGroup({
    productName:new FormControl('', [Validators.required]),
    sectionId:new FormControl(undefined, [Validators.required])
  });
  constructor(
    private productSvc:ProductService,
    private notifySvc:NotifyServicesService,
    private sectionSvc:SectionService
  ){}

  get f(){
    return this.productForm.controls;
  }
  save(){
    if(this.productForm.invalid) return;
    Object.assign(this.products, this.productForm.value);
    this.productSvc.post(this.products)
      .subscribe({
        next: r=>{
          this.notifySvc.openSnackBar("Data Saved", "DISMISS");
          this.products={};
          this.productForm.reset({});
          this.productForm.markAsPristine();
          this.productForm.markAsUntouched();
        },
        error: er=>{
          this.notifySvc.openSnackBar("Data Save Failed", "DISMISS");
        }
      })
  }
  ngOnInit(): void {
    this.sectionSvc.get()
      .subscribe({
        next:r=>{
          this.sections=r;
        },
        error: er=>{
          this.notifySvc.openSnackBar("Product load Failed", "DISMISS");
        }
      })
  }
}