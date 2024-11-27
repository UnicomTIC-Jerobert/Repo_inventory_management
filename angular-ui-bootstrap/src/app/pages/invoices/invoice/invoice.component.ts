import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrl: './invoice.component.css'
})
export class InvoiceComponent {
  invoiceForm!: FormGroup;
  customers = [
    { id: 1, name: 'Customer A' },
    { id: 2, name: 'Customer B' },
  ];
  products = [
    { id: 1, name: 'Product A', price: 50 },
    { id: 2, name: 'Product B', price: 100 },
  ];

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.invoiceForm = this.fb.group({
      invoiceNumber: ['', Validators.required],
      date: ['', Validators.required],
      customer: ['', Validators.required],
      items: this.fb.array([]),
    });
    this.addItem(); // Add an initial item row
  }

  get invoiceItems(): FormArray {
    return this.invoiceForm.get('items') as FormArray;
  }

  addItem() {
    const itemGroup = this.fb.group({
      product: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      price: [{ value: '', disabled: true }], // Auto-calculated
      subtotal: [{ value: '', disabled: true }], // Auto-calculated
    });
    this.invoiceItems.push(itemGroup);
  }

  updatePrice(index: number) {
    const selectedProductId = this.invoiceItems.at(index).get('product')?.value;
    const selectedProduct = this.products.find((p) => p.id === +selectedProductId);
    if (selectedProduct) {
      const priceControl = this.invoiceItems.at(index).get('price');
      priceControl?.setValue(selectedProduct.price);
      this.updateSubtotal(index);
    }
  }

  updateSubtotal(index: number) {
    const quantity = this.invoiceItems.at(index).get('quantity')?.value;
    const price = this.invoiceItems.at(index).get('price')?.value;
    const subtotalControl = this.invoiceItems.at(index).get('subtotal');
    subtotalControl?.setValue(quantity * price);
  }

  deleteItem(index: number) {
    this.invoiceItems.removeAt(index);
  }

  calculateTotal(): number {
    return this.invoiceItems.controls.reduce((total, item) => {
      const subtotal = item.get('subtotal')?.value || 0;
      return total + subtotal;
    }, 0);
  }
}
