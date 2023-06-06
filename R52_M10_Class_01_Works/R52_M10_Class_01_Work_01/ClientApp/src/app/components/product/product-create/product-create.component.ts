import { Component } from '@angular/core';
import { ProductModel } from 'src/app/models/data/product-model';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent {
product:ProductModel={}
}
