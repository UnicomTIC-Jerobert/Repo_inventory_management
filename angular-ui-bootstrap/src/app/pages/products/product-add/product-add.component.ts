import { Component } from '@angular/core';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent {
  product: any = { name: '', description: '', category: '' };
  imagePreview: string | null = null;
  categories = ['Electronics', 'Books', 'Clothing'];

  newStock: any = { dateOfUpdate: '', quantity: 0 };
  newPrice: any = { date: '', amount: 0 };





  onSubmit(): void {
    console.log('Product Data:', this.product);
    console.log('Stocks:', this.stocks);
    console.log('Prices:', this.prices);
  }

  stocks = [{ dateOfUpdate: '', quantity: 0, isEditable: false }];
  prices = [{ date: '', amount: 0, isEditable: false }];

  addStock() {
    this.stocks.push({ dateOfUpdate: '', quantity: 0, isEditable: true });
  }

  editStock(index: number) {
    this.stocks[index].isEditable = true;
  }

  updateStock(index: number) {
    this.stocks[index].isEditable = false;
  }

  removeStock(index: number) {
    this.stocks.splice(index, 1);
  }

  addPrice() {
    this.prices.push({ date: '', amount: 0, isEditable: true });
  }

  editPrice(index: number) {
    this.prices[index].isEditable = true;
  }

  updatePrice(index: number) {
    this.prices[index].isEditable = false;
  }

  removePrice(index: number) {
    this.prices.splice(index, 1);
  }
}
