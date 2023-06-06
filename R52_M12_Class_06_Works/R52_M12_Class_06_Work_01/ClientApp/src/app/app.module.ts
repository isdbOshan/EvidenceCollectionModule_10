import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './components/common/nav-bar/nav-bar.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MultilevelMenuService, NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { HomeComponent } from './components/home/home.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BookCreateComponent } from './components/book/book-create/book-create.component';
import { BookListComponent } from './components/book/book-list/book-list.component';
import { BookEditComponent } from './components/book/book-edit/book-edit.component';
import { PublisherListComponent } from './components/publisher/publisher-list/publisher-list.component';
import { PublisherCreateComponent } from './components/publisher/publisher-create/publisher-create.component';
import { PublisherEditComponent } from './components/publisher/publisher-edit/publisher-edit.component';
import { BookService } from './services/book.service';
import { PublisherService } from './services/publisher.service';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { ConfirmDialogComponent } from './components/dialogs/confirm-dialog/confirm-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatTableModule} from '@angular/material/table';
import {MatCardModule} from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';






@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    BookCreateComponent,
    BookListComponent,
    BookEditComponent,
    PublisherListComponent,
    PublisherCreateComponent,
    PublisherEditComponent,
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
    NgMaterialMultilevelMenuModule,
    HttpClientModule,
    MatSnackBarModule,
    MatDialogModule,
    MatInputModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatCardModule,
    ReactiveFormsModule,


  ],
  providers: [MultilevelMenuService, HttpClient, BookService, PublisherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
