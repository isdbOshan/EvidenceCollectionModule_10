import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/common/nav-bar/nav-bar.component';
import { LayoutModule } from '@angular/cdk/layout';

import { HomeComponent } from './components/home/home.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MultilevelMenuService } from 'ng-material-multilevel-menu';
import { DepartmentService } from './services/data/department.service';
import { EmployeeService } from './services/data/employee.service';
import { DepartmentViewComponent } from './components/department/department-view/department-view.component';
import { DepartmentCreateComponent } from './components/department/department-create/department-create.component';
import { DepartmentEditComponent } from './components/department/department-edit/department-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    DepartmentViewComponent,
    DepartmentCreateComponent,
    DepartmentEditComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    LayoutModule,
    MatImportModule,
    AppRoutingModule,
    NgMaterialMultilevelMenuModule,
    HttpClientModule, 
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [HttpClient, MultilevelMenuService, DepartmentService, EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
