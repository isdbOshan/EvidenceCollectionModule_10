import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/common/nav-bar/nav-bar.component';
import { LayoutModule } from '@angular/cdk/layout';

import { HomeComponent } from './components/home/home.component';
import { ProductService } from './services/data/product.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductCreateComponent } from './components/product/product-create/product-create.component';
import { ProductEditComponent } from './components/product/product-edit/product-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    ProductListComponent,
    ProductCreateComponent,
    ProductEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatImportModule
  ],
  providers: [DatePipe, HttpClient, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
