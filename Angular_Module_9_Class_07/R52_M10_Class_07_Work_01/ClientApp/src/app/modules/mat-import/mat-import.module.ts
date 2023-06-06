import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatTableModule} from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';

const modules =[
  CommonModule,
  MatToolbarModule,
  MatButtonModule,
  MatSidenavModule,
  MatIconModule,
  MatListModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatTableModule,
  MatSortModule,
  MatPaginatorModule,
  MatDialogModule,
  MatSelectModule,
  MatSnackBarModule
  // CommonModule,
  // MatSnackBarModule,
  // MatDialogModule,
  // MatCardModule,
  // MatTableModule,
  // MatSortModule,
  // MatPaginatorModule,
  // MatInputModule,
  // MatSelectModule
  
];



@NgModule({
  declarations: [],
  imports: [
    ...modules
  ],
  exports:[
    ...modules
  ]
})
export class MatImportModule { }
