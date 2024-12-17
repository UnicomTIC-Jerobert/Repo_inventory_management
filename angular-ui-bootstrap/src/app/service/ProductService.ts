import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductRequest } from '../models/ProductRequest';
import { ProductResponse } from '../models/ProductResponse';
import { ApiResponse } from '../helpers/ApiResponse'; // Wrapper model for responses

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    private baseUrl = 'http://localhost:5253/api/Product'; // Replace with your API URL

    constructor(private http: HttpClient) { }

    getProducts(): Observable<ApiResponse<ProductResponse[]>> {
        return this.http.get<ApiResponse<ProductResponse[]>>(this.baseUrl);
    }

    getProductById(id: string): Observable<ApiResponse<ProductResponse>> {
        return this.http.get<ApiResponse<ProductResponse>>(`${this.baseUrl}/${id}`);
    }

    addProduct(product: ProductRequest): Observable<ApiResponse<ProductResponse>> {
        return this.http.post<ApiResponse<ProductResponse>>(this.baseUrl, product);
    }

    updateProduct(id: string, product: ProductRequest): Observable<ApiResponse<ProductResponse>> {
        return this.http.put<ApiResponse<ProductResponse>>(`${this.baseUrl}/${id}`, product);
    }

    deleteProduct(id: number): Observable<ApiResponse<ProductResponse>> {
        return this.http.delete<ApiResponse<ProductResponse>>(`${this.baseUrl}/${id}`);
    }

    updateStock(productId: number, stocks: any[]): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/${productId}/stocks`, stocks);
    }

    updatePrices(productId: number, prices: any[]): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/${productId}/prices`, prices);
    }
}
