import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PublisherService } from 'src/app/services/publisher.service';
import { ConfirmDialogComponent } from '../../dialogs/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-publisher-list',
  templateUrl: './publisher-list.component.html',
  styleUrls: ['./publisher-list.component.css'],
})
export class PublisherListComponent implements OnInit {
  publisher: Publisher[] = [];
  dataSource: MatTableDataSource<Publisher> = new MatTableDataSource(
    this.publisher
  );
  columnList = ['publisherName', 'address', 'actions'];
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  constructor(
    private publihserSvc: PublisherService,
    private notifySvc: NotifyService,
    private matDialog: MatDialog
  ) {}
  confirmDelete(item: Publisher) {
    this.matDialog
      .open(ConfirmDialogComponent, {
        width: '450px',
      })
      .afterClosed()
      .subscribe({
        next: (r) => {
          if (r) {
            this.publihserSvc.delete(Number(item.publisherId)).subscribe({
              next: (r) => {
                this.dataSource.data = this.dataSource.data.filter(
                  (x) => x.publisherId != item.publisherId
                );
              },
              error: (err) => {
                this.notifySvc.notify('Failed to delete', 'DISMISS');
              },
            });
          }
        },
      });
  }

  ngOnInit(): void {
    this.publihserSvc.get().subscribe({
      next: (r) => {
        this.publisher = r;
        this.dataSource.data = this.publisher;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => {
        console.log(err.message || err);
      },
    });
  }
}
