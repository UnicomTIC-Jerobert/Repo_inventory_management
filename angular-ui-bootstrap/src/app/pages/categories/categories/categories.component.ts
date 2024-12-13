import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent {
  
  categoriesForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.categoriesForm = this.fb.group({
      categories: this.fb.array([]), // Initialize FormArray
    });
  }

  // Getter for categories FormArray
  get categories(): FormArray {
    return this.categoriesForm.get('categories') as FormArray;
  }

  // Add a new category
  addCategory() {
    this.categories.push(
      this.fb.group({
        name: [''], // Default empty name
        editMode: [true], // New category is editable by default
      })
    );
  }

  // Edit a category
  editCategory(index: number) {
    const category = this.categories.at(index);
    category.patchValue({ editMode: true }); // Enable edit mode
  }

  // Save changes to a category
  saveCategory(index: number) {
    const category = this.categories.at(index);
    category.patchValue({ editMode: false }); // Disable edit mode
  }

  // Delete a category
  deleteCategory(index: number) {
    this.categories.removeAt(index);
  }

  // Submit the form (e.g., to save categories to backend)
  onSubmit() {
    console.log(this.categoriesForm.value);
  }
}
