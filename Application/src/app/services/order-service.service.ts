import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Iorder } from '../models/iorder';

@Injectable({
  providedIn: 'root'
})
export class OrderServiceService {

  constructor(private httpClient: HttpClient) { }

  postOrder(orderData: Iorder) {
    const formData = new FormData();
    formData.append('ProductName', orderData.ProductName);
    formData.append('Quantity', orderData.Quantity.toString());
    formData.append('PhoneNumber', orderData.PhoneNumber);
    formData.append('Size', orderData.Size);
    formData.append('Address', orderData.Address);
    formData.append('Message', orderData.Message);
    formData.append('date', orderData.date);
    formData.append('price', orderData.price.toString());
    formData.append('totalPrice', orderData.totalPrice.toString());

    orderData.Photos.forEach((file) => {
      formData.append('Photos', file, file.name);
    });

    return this.httpClient.post(`${environment.baseurl2}/Api/V1/OrderRoute/Create`, formData);
  }
}