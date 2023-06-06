import { Component } from '@angular/core';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent {
  products:Product[] = [
    new Product('P1', 19.95),
    new Product('P2', 16.99),
    new Product('P3', .99)
  ];
}
