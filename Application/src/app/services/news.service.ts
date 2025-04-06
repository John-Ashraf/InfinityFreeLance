import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private httpclient:HttpClient) { }
  postNews(newsData:FormData){
    return this.httpclient.post(`${environment.baseurl2}/Api/V1/NewsRoute/Create`,newsData)
  }
  getNews(){
    return this.httpclient.get(`${environment.baseurl2}/Api/V1/NewsRouteGetNewsList`)
  }
  deleteNews(id:number){
    return this.httpclient.delete(`${environment.baseurl2}/Api/V1/NewsRoute/${id}`)
  }
}
