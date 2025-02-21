import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {

  constructor(private httpClient:HttpClient) { }
  getListOfCategory(){//selectCategory
      // console.log("testing");
      return this.httpClient.get(`${environment.baseurl2}/Api/V1/CategoryRouteGetCategoryList`)
    }
}
