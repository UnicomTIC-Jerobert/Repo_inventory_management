import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { ProductListComponent } from './pages/products/product-list/product-list.component';
import { ProductAddComponent } from './pages/products/product-add/product-add.component';
import { CategoriesComponent } from './pages/categories/categories/categories.component';
import { InvoiceComponent } from './pages/invoices/invoice/invoice.component';

const routes: Routes = [
  {
    path: 'login', // Login route
    component: AuthLayoutComponent,
    children: [
      { path: '', component: LoginComponent }, // Default login child route
    ],
  },
  {
    path: '', // Dashboard route
    component: MainLayoutComponent,
    children: [
      { path: '', redirectTo: 'products', pathMatch: 'full' }, // Redirect '/' to 'products'
      { path: 'products', component: ProductListComponent },
      { path: 'products/add', component: ProductAddComponent },
      { path: 'categories', component: CategoriesComponent }, // Categories route
      { path: 'invoices', component: InvoiceComponent },
    ],
  },
  { path: '**', redirectTo: 'login' }, // Redirect unknown routes to login
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
