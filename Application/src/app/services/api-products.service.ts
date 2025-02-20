import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
// import { Iproduct } from '../models/iproduct';
interface ProductData {
  Name: string;
  Description: string;
  Price: string;
  Catid:string;
  Photos: File[];
}
@Injectable({
  providedIn: 'root'
})
export class ApiProductsService {

  constructor(private httpClient:HttpClient) { }
  getAllProducts(){//products
   return this.httpClient.get(`${environment.baseUrl}/products`)
  }
  getAllCategories(){//Categories
    return this.httpClient.get(`${environment.baseUrl}/products/categories`)
   }
   getProductByCategories(keyword:string){
    return this.httpClient.get(`${environment.baseUrl}/products/category/${keyword}`)
   }
   getproductById(id:number){//Product Details
    return this.httpClient.get(`${environment.baseUrl}/products/${id}`)
   }
   AddProduct(product: FormData): Observable<any> {
    console.log('Sending product data:', product);
    const headers = new HttpHeaders({ 'Content-Type': 'multipart/form-data' }); // <-- Debug here
    return this.httpClient.post(
      `${environment.baseurl2}/Api/V1/ProductRoute/Create`,
      product
    );
  }
   
   
  // getProductById(id:number):Observable<Iproduct>{//details
  //   return this.httpClient.get<Iproduct>(`${environment.baseUrl}/products/${id}`)
  // }
  // getProductByCatId(catId:number):Observable<Iproduct[]>{
  //   return this.httpClient.get<Iproduct[]>(`${environment.baseUrl}/products?catId=${catId}`)
  // }
}
