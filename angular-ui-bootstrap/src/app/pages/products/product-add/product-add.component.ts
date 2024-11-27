import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.css'
})
export class ProductAddComponent {
  productForm: FormGroup;
  imagePreview: string | null = null;
  categories = ['Electronics', 'Books', 'Clothing'];
  stocks = [{ location: 'Warehouse 1', quantity: 50 }];
  prices = [{ date: '2024-01-01', amount: 100 }];

  constructor(private fb: FormBuilder) {
    this.productForm = this.fb.group({
      name: [''],
      description: [''],
      category: [''],
    });
  }

  onImageChange(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => (this.imagePreview = reader.result as string);
      reader.readAsDataURL(file);
    }
  }

  onSubmit(): void {
    console.log(this.productForm.value);
  }
}
