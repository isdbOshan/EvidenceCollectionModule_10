import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { NotifyServicesService } from 'src/app/services/notify-services.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product:Product = {};
  productForm:FormGroup = new FormGroup({
    productName:new FormControl('', [Validators.required, Validators.maxLength(50)])
  });
  constructor(
    private productSvc:ProductService,
    private notifySvc:NotifyServicesService,
    private actvatedRoute:ActivatedRoute
  ){}
  get f(){
    return this.productForm.controls;
  }
  save(){
      if(this.productForm.invalid) return;
      Object.assign(this.product, this.productForm.value);
      this.productSvc.put(this.product)
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
    this.productSvc.getById(id)
    .subscribe({
      next:r=>{
        console.log(r);
        this.product=r;
        this.productForm.patchValue(this.product)
      }, error:err=>{
        console.log(err.message || err);
        this.notifySvc.openSnackBar("Failed to load Product", "DISMISS");
      }
    })
  }

}
