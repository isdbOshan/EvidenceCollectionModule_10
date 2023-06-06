import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent {
products: Product[]=[];
dataSource:MatTableDataSource<Product>= new MatTableDataSource(this.products);
columnList= ['productName', 'actions'];
@ViewChild(MatSort, {static:false}) sort!:MatSort;
@ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
constructor(
  private productSvc: ProductService,
  private matDialog: MatDialog

){}
consfirmDelete(item:Product){
this.matDialog.open(ConfirmDialogComponent, {
  width:'450px'
}).afterClosed()
.subscribe({
  next:r=>{
    if(r){
      this.productSvc.delete(Number(item.productId))
      .subscribe({
        next:r=>{
          this.dataSource.data = this.dataSource.data.filter(x=> x.productId != item.productId);
        }
        ,
        error: err=>{
          console.log('err');

        }
      })
    }
  }
})
}
ngOnInit(): void {
 this.productSvc.get()
 .subscribe({
  next: r=>{
    this.products = r;
    this.dataSource.data = this.products;
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  },
  error:err=>{
    console.log(err.message || err);
  }
 })
}
}
