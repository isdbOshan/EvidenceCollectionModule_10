import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { LayoutModule } from '@angular/cdk/layout';

import { HomeComponent } from './components/home/home.component';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MultilevelMenuService } from 'ng-material-multilevel-menu';
import { SectionViewComponent } from './components/Sections/section-view/section-view.component';
import { SectionCreateComponent } from './components/Sections/section-create/section-create.component';
import { SectionEditComponent } from './components/Sections/section-edit/section-edit.component';
import { ProductViewComponent } from './components/Products/product-view/product-view.component';
import { ProductCreateComponent } from './components/Products/product-create/product-create.component';
import { ProductEditComponent } from './components/Products/product-edit/product-edit.component';
import { ManagerViewComponent } from './components/Managers/manager-view/manager-view.component';
import { ManagerCreateComponent } from './components/Managers/manager-create/manager-create.component';
import { ManagerEditComponent } from './components/Managers/manager-edit/manager-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfirmDialogComponent } from './components/dialog/confirm-dialog/confirm-dialog.component';
import { SectionService } from './Services/section.service';
import { ProductService } from './Services/product.service';
import { ManagerService } from './Services/manager.service';
import { NotifyService } from './Services/notify.service';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    SectionViewComponent,
    SectionCreateComponent,
    SectionEditComponent,
    ProductViewComponent,
    ProductCreateComponent,
    ProductEditComponent,
    ManagerViewComponent,
    ManagerCreateComponent,
    ManagerEditComponent,
    ConfirmDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatImportModule,
    NgMaterialMultilevelMenuModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [HttpClient,MultilevelMenuService,SectionService,ProductService,ManagerService,NotifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
