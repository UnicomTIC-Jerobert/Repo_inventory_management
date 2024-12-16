import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../../service/category.service';
import { CategoryResponse } from '../../../models/CategoryResponse';
import { ApiResponse } from '../../../helpers/ApiResponse';


@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
})
export class CategoriesComponent implements OnInit {
  categories: { id: string | null; name: string; description: string; editMode: boolean }[] = [];

  constructor(private categoryService: CategoryService) { }

  ngOnInit() {
    this.loadCategories();
  }

  // Fetch categories from API
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

  // Add a new category
  addCategory() {
    this.categories.push({
      id: null,
      name: '',
      description: '',
      editMode: true, // Allow editing immediately after creation
    });
  }

  // Enable edit mode for a category
  editCategory(category: any) {
    category.editMode = true;
  }

  // Save a category (either create or update)
  saveCategory(category: any) {
   
    if (category.id) {
      
      // Update existing category
      this.categoryService.updateCategory(category.id, category).subscribe((response: ApiResponse<CategoryResponse>) => {
        if (response.success) {
          category.editMode = false;
        } else {
          console.error('Failed to update category:', response.errors);
        }
      });
    } else {
      // Create new category
      this.categoryService.saveCategory(category).subscribe((response: ApiResponse<CategoryResponse>) => {
        if (response.success) {
          category.id = response.payload.id; // Assign the new ID
          category.editMode = false;
        } else {
          console.error('Failed to create category:', response.errors);
        }
      });
    }
  }

  // Delete a category
  deleteCategory(index: number) {
    const category = this.categories[index];
    if (category.id) {
      this.categoryService.deleteCategory(category.id).subscribe((response: ApiResponse<void>) => {
        if (response.success) {
          this.categories.splice(index, 1);
        } else {
          console.error('Failed to delete category:', response.errors);
        }
      });
    } else {
      // Remove unsaved category directly
      this.categories.splice(index, 1);
    }
  }
}


