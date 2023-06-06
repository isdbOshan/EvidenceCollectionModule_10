import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/common/nav-bar/nav-bar.component';
import { LayoutModule } from '@angular/cdk/layout';

import { MultilevelMenuService, NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { PublisherListComponent } from './components/publisher/publisher-list/publisher-list.component';
import { PublisherCreateComponent } from './components/publisher/publisher-create/publisher-create.component';
import { PublisherEditComponent } from './components/publisher/publisher-edit/publisher-edit.component';
import { BookListComponent } from './components/book/book-list/book-list.component';
import { BookCreateComponent } from './components/book/book-create/book-create.component';
import { BookEditComponent } from './components/book/book-edit/book-edit.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { PublisherService } from './services/data/publisher.service';
import { BookService } from './services/data/book.service';
import { NotifyService } from './services/common/notify.service';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { HomeComponent } from './components/home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfirmDialogComponent } from './dialogs/confirm-dialog/confirm-dialog.component';
import { MatNativeDateModule } from '@angular/material/core';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    PublisherListComponent,
    PublisherCreateComponent,
    PublisherEditComponent,
    BookListComponent,
    BookCreateComponent,
    BookEditComponent,
    HomeComponent,
    ConfirmDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    NgMaterialMultilevelMenuModule,
    HttpClientModule,
    MatImportModule,
    FormsModule,
    ReactiveFormsModule,
    MatNativeDateModule
  ],
  providers: [DatePipe, MultilevelMenuService, HttpClient, PublisherService, BookService, NotifyService],
  entryComponents: [ConfirmDialogComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
