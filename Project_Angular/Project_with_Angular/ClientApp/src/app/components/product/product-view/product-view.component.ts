import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/models/product';
import { NotifyServicesService } from 'src/app/services/notify-services.service';
import { ProductService } from 'src/app/services/product.service';
import { ConfirmDialogComponent } from '../../delete/confirm-dialog/confirm-dialog.component';
import { SectionService } from 'src/app/services/section.service';


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
    private productSvc:ProductService,
    private sectionSvc:SectionService,
    private notifySvc:NotifyServicesService,
    private matDialog: MatDialog
   ){}
   confirmDelete(item:Product){
    this.matDialog.open(ConfirmDialogComponent, {
      width: '450px'
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
              this.notifySvc.openSnackBar("Failed to delete", "DISMISS");
            }
          })
        }
      }
    })
  }
  ngOnInit(): void {
    this.productSvc.getWithSection()
      .subscribe({
        next: r=>{
          this.products=r;
          this.dataSource.data = this.products;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        },
        error: er=>{
          this.notifySvc.openSnackBar("Failed to load Product", "DISMISS");
        }
      })
  }
  }