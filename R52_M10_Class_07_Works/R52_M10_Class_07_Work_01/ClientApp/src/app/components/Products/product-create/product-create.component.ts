import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent {
product:Product={};
productForm:FormGroup=new FormGroup({
  productName: new FormControl('', [Validators.required, Validators.maxLength(50)])
});
constructor(
  private productSvc:ProductService

  ){}

  get f(){
    return this.productForm.controls;
  }

  save(){
    if(this.productForm.invalid) return;
    Object.assign(this.product, this.productForm.value);
    console.log(this.product);
    this.productSvc.post(this.product)
    .subscribe({
      next:r=>{
        console.log(r);
        this.product={};
        this.productForm.reset({});
        this.productForm.markAsPristine();
        this.productForm.markAsUntouched();

      },
      error:er=>{
        console.log(er);
      }
    })

  }
}
