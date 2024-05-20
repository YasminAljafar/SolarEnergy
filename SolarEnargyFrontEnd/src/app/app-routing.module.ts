import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { SignupComponent } from './components/signup/signup.component';
import { LoginComponent } from './components/login/login.component';
import { CategoryComponent } from './components/category/category.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MechenicalDesginComponent } from './components/mechenical-desgin/mechenical-desgin.component';
import { MentinenceDesginComponent } from './components/mentinence-desgin/mentinence-desgin.component';
import { FooterMenuComponent } from './components/footer-menu/footer-menu.component';
import { AddProductComponent } from './components/add-product/add-product.component';

const routes: Routes = [
  {path:'' , component: HomeComponent, pathMatch:'full'},
  {path:'products' , component: ProductsComponent},
  {path:'login' , component: LoginComponent},
  {path:'signup' , component: SignupComponent},
  {path:'category' , component: CategoryComponent},
  {path:'home' , component: HomeComponent},
  {path:'mechenicaldesgin' , component: MechenicalDesginComponent},
  {path:'mentinencedesgin' , component: MentinenceDesginComponent},
  {path:'footer' , component: FooterMenuComponent},
  {path:'addproduct', component:AddProductComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
