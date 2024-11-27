import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopNavComponent } from './components/top-nav/top-nav.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProductListComponent } from './pages/products/product-list/product-list.component';
import { ProductAddComponent } from './pages/products/product-add/product-add.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { CategoriesComponent } from './pages/categories/categories/categories.component';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductFormComponent } from './pages/products/product-form/product-form.component';
import { InvoiceComponent } from './pages/invoices/invoice/invoice.component';


@NgModule({
  declarations: [
    AppComponent,
    TopNavComponent,
    FooterComponent,
    ProductListComponent,
    ProductAddComponent,
    LoginComponent,
    CategoriesComponent,
    MainLayoutComponent,
    AuthLayoutComponent,
    ProductFormComponent,
    InvoiceComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
