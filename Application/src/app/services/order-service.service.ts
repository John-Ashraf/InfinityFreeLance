import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Iorder } from '../models/iorder';

@Injectable({
  providedIn: 'root'
})
export class OrderServiceService {

  constructor(private httpClient: HttpClient) { }

  postOrder(orderData: FormData) {

  
    return this.httpClient.post(`${environment.baseurl2}/Api/V1/OrderRoute/Create`, orderData);
  }
}