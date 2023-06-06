import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavBarComponent } from './components/common/nav-bar/nav-bar.component';
import { HomeComponent } from './components/home/home.component';
import { ProductCreateComponent } from './components/product/product-create/product-create.component';
import { ProductEditComponent } from './components/product/product-edit/product-edit.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductService } from './services/data/product.service';

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path: 'home', component:HomeComponent},
  {path: 'products', component:ProductListComponent},
  {path: 'product-create', component:ProductCreateComponent},
  {path: 'product-edit', component:ProductEditComponent},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
