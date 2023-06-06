import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Section } from 'src/app/models/section';
import { SectionService } from 'src/app/Services/section.service';

@Component({
  selector: 'app-section-view',
  templateUrl: './section-view.component.html',
  styleUrls: ['./section-view.component.css']
})
export class SectionViewComponent {
  Sections:Section[] =[];
  dataSource:MatTableDataSource<Section> = new MatTableDataSource(this.Sections);
  columnList = ['sectionName', 'actions'];
  @ViewChild(MatSort, {static:false}) sort!:MatSort;
  @ViewChild(MatPaginator, {static:false}) paginator!:MatPaginator;
  constructor(private sectionsrv:SectionService){}
   ngOnInit(): void {
      this.sectionsrv.get()
      .subscribe({
       next: r=>{
         this.Sections = r;
         this.dataSource.data = this.Sections;
         this.dataSource.sort = this.sort;
         this.dataSource.paginator = this.paginator;
       },
       error:err=>{
         console.log(err.message || err);
       }
      })
   }
}
