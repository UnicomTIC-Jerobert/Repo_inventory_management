import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryRequest } from '../models/CategoryRequest';
import { CategoryResponse } from '../models/CategoryResponse';
import { ApiResponse } from '../helpers/ApiResponse'; // Wrapper model for responses

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl = 'http://localhost:5253/api/Category'; // Replace with your actual API endpoint

  constructor(private http: HttpClient) {}

  // Get all categories
  listCategories(): Observable<ApiResponse<CategoryResponse[]>> {
    return this.http.get<ApiResponse<CategoryResponse[]>>(this.apiUrl);
  }

  // Add a new category
  saveCategory(category: CategoryRequest): Observable<ApiResponse<CategoryResponse>> {
    return this.http.post<ApiResponse<CategoryResponse>>(this.apiUrl, category);
  }

  // Update an existing category
  updateCategory(categoryId: string, category: CategoryRequest): Observable<ApiResponse<CategoryResponse>> {
    return this.http.put<ApiResponse<CategoryResponse>>(`${this.apiUrl}/${categoryId}`, category);
  }

  // Delete a category
  deleteCategory(categoryId: string): Observable<ApiResponse<void>> {
    return this.http.delete<ApiResponse<void>>(`${this.apiUrl}/${categoryId}`);
  }
}
