import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/models/product';
import { NotifyService } from 'src/app/Services/notify.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
  products:Product[]=[];
  dataSource:MatTableDataSource<Product> = new MatTableDataSource(this.products);
  columnList = ['productName', 'sectionId', 'actions']
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
constructor(
  private ProductSrv:ProductService,
  private notifySvc:NotifyService,

  ){}

  ngOnInit(): void {
    this.ProductSrv.getWithSection()
      .subscribe({
        next: r=>{
          this.products=r;
          this.dataSource.data = this.products;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error: er=>{
          this.notifySvc.notify("Failed to load section", "DISMISS");
        }
      })
  }

}



