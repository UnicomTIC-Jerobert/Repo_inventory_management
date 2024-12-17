import { Component } from '@angular/core';
import { ProductResponse } from '../../../models/ProductResponse';
import { ProductService } from '../../../service/ProductService';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  products: ProductResponse[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  // Fetch all products
  loadProducts(): void {
    this.productService.getProducts().subscribe({
      next: (response) => {
        if (response.success) {
          this.products = response.payload;
        } else {
          console.error('Error fetching products:', response.errors);
        }
      },
      error: (err) => console.error('API error:', err)
    });
  }
}
