import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../service/ProductService';
import { ProductRequest } from '../../../models/ProductRequest';
import { ProductResponse } from '../../../models/ProductResponse';
import { CategoryService } from '../../../service/category.service';
import { ApiResponse } from '../../../helpers/ApiResponse';
import { CategoryResponse } from '../../../models/CategoryResponse';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  product: ProductRequest = { name: '', description: '', categoryId: '' };
  imagePreview: string | null = null;
  categories: CategoryResponse[] = [];
  stocks = [{ dateOfUpdate: '', quantity: 0, isEditable: false }];
  prices = [{ date: '', amount: 0, isEditable: false }];
  products: ProductResponse[] = []; // For displaying existing products
  isEditMode = false;
  productId: string | null = null;

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadCategories();

    // Check if product ID is in the route
    this.route.paramMap.subscribe(params => {
      this.productId = params.get('id');
      if (this.productId) {
        this.isEditMode = true;
        this.loadProduct(this.productId);
      }
    });
  }


  loadCategories() {
    this.categoryService.listCategories().subscribe((response: ApiResponse<CategoryResponse[]>) => {
      if (response.success) {
        this.categories = response.payload.map((category: any) => ({
          id: category.id,
          name: category.name,
          description: category.description,
          editMode: false, // Default to non-editable
        }));
      } else {
        console.error('Failed to load categories:', response.errors);
      }
    });
  }

   // Load product details for editing
   loadProduct(productId: string) {
    this.productService.getProductById(productId).subscribe({
      next: (response: ApiResponse<ProductResponse>) => {
        if (response.success) {
          const product = response.payload;
          this.product = {
            name: product.name,
            description: product.description,
            categoryId: product.categoryId,
          };
          // this.stocks = product.stocks || this.stocks;
          // this.prices = product.prices || this.prices;
        } else {
          console.error('Failed to load product:', response.errors);
        }
      },
      error: (err) => console.error('API error:', err),
    });
  }

  // Save a new product
  onSubmit(): void {
    if (this.isEditMode && this.productId) {
      // Update product
      this.productService.updateProduct(this.productId, this.product).subscribe({
        next: (response) => {
          if (response.success) {
            console.log('Product updated successfully:', response.payload);
            this.router.navigate(['/products/list']); // Navigate after update
          } else {
            console.error('Error updating product:', response.errors);
          }
        },
        error: (err) => console.error('API error:', err),
      });
    } else {
      // Add product
      this.productService.addProduct(this.product).subscribe({
        next: (response) => {
          if (response.success) {
            console.log('Product added successfully:', response.payload);
            this.resetForm();
            this.router.navigate(['/products/list']); // Navigate after add
          } else {
            console.error('Error adding product:', response.errors);
          }
        },
        error: (err) => console.error('API error:', err),
      });
    }
  }

  // Update stocks
  updateStocks(productId: number): void {
    this.productService.updateStock(productId, this.stocks).subscribe({
      next: (response) => {
        console.log('Stocks updated successfully:', response);
      },
      error: (err) => console.error('API error:', err)
    });
  }

  // Update prices
  updatePrices(productId: number): void {
    this.productService.updatePrices(productId, this.prices).subscribe({
      next: (response) => {
        console.log('Prices updated successfully:', response);
      },
      error: (err) => console.error('API error:', err)
    });
  }

  // Stock management
  addStock(): void {
    this.stocks.push({ dateOfUpdate: '', quantity: 0, isEditable: true });
  }

  editStock(index: number): void {
    this.stocks[index].isEditable = true;
  }

  updateStock(index: number): void {
    this.stocks[index].isEditable = false;
  }

  removeStock(index: number): void {
    this.stocks.splice(index, 1);
  }

  // Price management
  addPrice(): void {
    this.prices.push({ date: '', amount: 0, isEditable: true });
  }

  editPrice(index: number): void {
    this.prices[index].isEditable = true;
  }

  updatePrice(index: number): void {
    this.prices[index].isEditable = false;
  }

  removePrice(index: number): void {
    this.prices.splice(index, 1);
  }

  // Reset form
  private resetForm(): void {
    this.product = { name: '', description: '', categoryId: '' };
    this.stocks = [{ dateOfUpdate: '', quantity: 0, isEditable: false }];
    this.prices = [{ date: '', amount: 0, isEditable: false }];
  }
}
