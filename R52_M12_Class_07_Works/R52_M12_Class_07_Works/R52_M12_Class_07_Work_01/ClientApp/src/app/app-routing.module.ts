import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PublisherListComponent } from './components/publisher/publisher-list/publisher-list.component';
import { PublisherCreateComponent } from './components/publisher/publisher-create/publisher-create.component';
import { PublisherEditComponent } from './components/publisher/publisher-edit/publisher-edit.component';
import { BookListComponent } from './components/book/book-list/book-list.component';
import { BookCreateComponent } from './components/book/book-create/book-create.component';
import { BookEditComponent } from './components/book/book-edit/book-edit.component';


const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'home', component:HomeComponent},
  {path:'publishers', component:PublisherListComponent},
  {path:'publisher-create', component:PublisherCreateComponent},
  {path:'publisher-edit/:id', component:PublisherEditComponent},
  {path:'books', component:BookListComponent},
  {path:'book-create', component:BookCreateComponent},
  {path:'book-edit/:id', component:BookEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
