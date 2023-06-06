import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProductModel } from 'src/app/models/data/product-model';
import { ProductService } from 'src/app/services/data/product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent {
  product:ProductModel = {};
  createForm:FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    price: new FormControl(undefined, Validators.required),
    mfgDate: new FormControl(undefined, Validators.required)
  });
  constructor(
    private productSvc:ProductService,
    private datePipe:DatePipe
  ){}
  get f() {
    return this.createForm.controls;
  }
  save(){
    if(this.createForm.invalid) return;
    
    Object.assign(this.product, this.createForm.value)
    
    this.product.mfgDate = <string>(this.datePipe.transform(this.product.mfgDate, "yyyy-MM-dd"))
    console.log(this.product);
    this.productSvc.post(this.product)
    .subscribe({
      next: r=>{
        this.product = {};
        this.createForm.reset({});
        this.createForm.markAsPristine();
        this.createForm.markAsUntouched();
      },
      error:err=> {console.log(err.message || err);}
    })
  }
}
