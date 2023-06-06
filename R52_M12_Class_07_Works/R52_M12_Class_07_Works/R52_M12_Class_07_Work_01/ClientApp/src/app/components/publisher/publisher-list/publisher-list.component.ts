import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PublisherService } from 'src/app/services/data/publisher.service';

@Component({
  selector: 'app-publisher-list',
  templateUrl: './publisher-list.component.html',
  styleUrls: ['./publisher-list.component.css']
})
export class PublisherListComponent implements OnInit {
  publishers:Publisher[] =[];
  dataSource:MatTableDataSource<Publisher> = new MatTableDataSource(this.publishers);
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  columns = ['publisherName', 'address', 'actions'];
 constructor(
  private publisherService:PublisherService,
  private notifyService:NotifyService,
  private matDialog:MatDialog
   ){}
  confirmDelete(item:Publisher){
    this.matDialog.open(ConfirmDialogComponent, {
      width: '450px'
    }).afterClosed()
    .subscribe({
      next: c=>{
        if(c){
          this.publisherService.delete(<number>item.publisherId)
          .subscribe({
              next:r=>{
                this.dataSource.data = this.dataSource.data.filter(x=> x.publisherId != item.publisherId);
                this.notifyService.notify("Data Deleted", "DISMISS");
              },
              error:err=>{
                this.notifyService.notify('Failed to delete', 'DISMISS');
                throwError(()=> err.message || err);
              }
          });
        }
      }
    });
  }
  ngOnInit(): void {
    this.publisherService.get()
    .subscribe({
      next: r=>{
        this.publishers=r;
        this.dataSource.data = this.publishers;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error:err=>{
        this.notifyService.notify('Failed to load pub;lishers', 'DISMISS');
        throwError(()=> err.message || err);
      }
    });
  }
}
