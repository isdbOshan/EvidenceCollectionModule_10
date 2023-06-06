import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Manager } from 'src/app/models/manager';
import { ManagerService } from 'src/app/services/manager.service';
import { NotifyService } from 'src/app/services/notify.service';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-manager-view',
  templateUrl: './manager-view.component.html',
  styleUrls: ['./manager-view.component.css']
})
export class ManagerViewComponent implements OnInit {
  managers:Manager[]=[];
  dataSource:MatTableDataSource<Manager> = new MatTableDataSource(this.managers);
  columnList = ['managerName','picture','productId', 'actions'];
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;

  constructor(
    private managerSvc:ManagerService,
    private notifySvc:NotifyService,
    private matDialog:MatDialog
  ){}
 
  confirmDelete(item:Manager){
    this.matDialog.open(ConfirmDialogComponent, {
      width: '450px'
    }).afterClosed()
      .subscribe({
        next:r=>{
          if(r){
            this.managerSvc.delete(Number(item.managerId))
            .subscribe({
              next:r=>{
                this.dataSource.data = this.dataSource.data.filter(x=> x.managerId != item.managerId);
              },
              error: er=>{
                this.notifySvc.notify("Failed to Delete", "DISMISS");
              }
            })
          }
        }
      })
  }
   ngOnInit(): void {
    this.managerSvc.get()
    .subscribe({
      next:r=>{
        this.managers = r;
        this.dataSource.data = this.managers;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error:er=>{
        this.notifySvc.notify("Failed to load section", "DISMISS");
      }
    })
  }
}

