import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ManagerCreateComponent } from './components/Managers/manager-create/manager-create.component';
import { ManagerEditComponent } from './components/Managers/manager-edit/manager-edit.component';
import { ManagerViewComponent } from './components/Managers/manager-view/manager-view.component';
import { ProductCreateComponent } from './components/Products/product-create/product-create.component';
import { ProductEditComponent } from './components/Products/product-edit/product-edit.component';
import { ProductViewComponent } from './components/Products/product-view/product-view.component';
import { SectionCreateComponent } from './components/Sections/section-create/section-create.component';
import { SectionEditComponent } from './components/Sections/section-edit/section-edit.component';
import { SectionViewComponent } from './components/Sections/section-view/section-view.component';

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'home', component:HomeComponent},
  {path:'sections', component:SectionViewComponent},
  {path:'section-create', component:SectionCreateComponent},
  {path:'section-edit/:id', component:SectionEditComponent},
  {path:'products', component:ProductViewComponent},
  {path:'product-create',component:ProductCreateComponent},
  {path:'product-edit/:id',component:ProductEditComponent},
  {path:'managers', component:ManagerViewComponent},
  {path:'manager-create', component:ManagerCreateComponent},
  {path:'manager-edit/:id', component:ManagerEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
