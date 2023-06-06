import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { ProductViewComponent } from './components/products/product-view/product-view.component';

const routes: Routes = [
  {path: '', component:HomeComponent},
  {path:'home', component:HomeComponent},
  {path:'about', component:AboutComponent},
  {path:'products', component:ProductViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
