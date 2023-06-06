import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/dialogs/confirm-dialog/confirm-dialog.component';
import { Format } from 'src/app/environment/app-constant';
import { Book } from 'src/app/models/data/book';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { BookService } from 'src/app/services/data/book.service';
import { PublisherService } from 'src/app/services/data/publisher.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books:Book[] =[];
  publishers:Publisher[] =[];
  dataSource:MatTableDataSource<Book> = new MatTableDataSource(this.books);
  columns= ['title', 'releaseDate', 'format', 'releaseDate','coverPrice', 'publisherId', 'actions']
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(
    private bookService:BookService,
    private publisherService:PublisherService,
    private notifyService:NotifyService,
    private matDialog:MatDialog
  ){ }
  getPublisherName(publisherId:number){
    return this.publishers.find(x=> x.publisherId == publisherId)?.publisherName;
  }
  getFormatName(v:any){
    return Format[v];
  }
  confirmDelete(item:Book){
    this.matDialog.open(ConfirmDialogComponent, {
      width: '450px'
    }).afterClosed()
    .subscribe({
      next: c=>{
        if(c){
          this.bookService.delete(<number>item.bookId)
          .subscribe({
              next:r=>{
                this.dataSource.data = this.dataSource.data.filter(x=> x.bookId != item.bookId);
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
    this.bookService.get()
    .subscribe({
      next: r=> {
        this.books=r;
        this.dataSource.data = this.books;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error:err=>{
        this.notifyService.notify('Failed to load books', 'DISMISS');
        throwError(()=> err.message || err);
      }
    });
    this.publisherService.get()
    .subscribe({
      next: r=>{
        this.publishers=r;
        
      },
      error:err=>{
        this.notifyService.notify('Failed to load pub;lishers', 'DISMISS');
        throwError(()=> err.message || err);
      }
    });
  }

}
