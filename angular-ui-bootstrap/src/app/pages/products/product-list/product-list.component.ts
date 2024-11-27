import { Component } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  products = [
    { name: 'Product 1', description: 'Description 1', image: 'path/to/image1.jpg' },
    { name: 'Product 2', description: 'Description 2', image: 'path/to/image2.jpg' },
  ];
}
