import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/app/models/product';
import { Section } from 'src/app/models/section';
import { NotifyService } from 'src/app/Services/notify.service';
import { ProductService } from 'src/app/Services/product.service';
import { SectionService } from 'src/app/Services/section.service';

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
  private notifySvc:NotifyService,
  private sectionSvc:SectionService
){}

get f(){
  return this.productForm.controls;
}
save(){
  if(this.productForm.invalid) return;
  Object.assign(this.products, this.productForm.value);
  // console.log(this.products)
  this.productSvc.post(this.products)
    .subscribe({
      next: r=>{
        console.log(r)
        this.notifySvc.notify("Data Saved", "DISMISS");
        this.products={};
        this.productForm.reset({});
        this.productForm.markAsPristine();
        this.productForm.markAsUntouched();

      },
      error: er=>{
        this.notifySvc.notify("Data Save Failed", "DISMISS");
      }
    })
}
ngOnInit(): void {
  this.sectionSvc.get()
    .subscribe({
      next:rr=>{
        this.sections=rr;
      },
      error: er=>{
        this.notifySvc.notify("Section load Failed", "DISMISS");
      }
    })
}
}
