import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    private baseUrl = 'https://api.example.com/products'; // Replace with your API URL

    constructor(private http: HttpClient) { }

    getProducts(): Observable<any[]> {
        return this.http.get<any[]>(this.baseUrl);
    }

    getProductById(id: number): Observable<any> {
        return this.http.get<any>(`${this.baseUrl}/${id}`);
    }

    addProduct(product: any): Observable<any> {
        return this.http.post<any>(this.baseUrl, product);
    }

    updateProduct(id: number, product: any): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/${id}`, product);
    }

    deleteProduct(id: number): Observable<any> {
        return this.http.delete<any>(`${this.baseUrl}/${id}`);
    }

    updateStock(productId: number, stocks: any[]): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/${productId}/stocks`, stocks);
    }

    updatePrices(productId: number, prices: any[]): Observable<any> {
        return this.http.put<any>(`${this.baseUrl}/${productId}/prices`, prices);
    }
}
