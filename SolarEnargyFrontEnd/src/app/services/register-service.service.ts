import { Injectable } from '@angular/core';
import { SigupModel } from '../models/signup-model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginModel } from '../models/login-model';
import { Category } from '../models/category-model';
import { Product } from '../models/product-model';


@Injectable({
  providedIn: 'root'
})
export class RegisterServiceService {

  constructor(private http: HttpClient) { }

  Url = 'https://localhost:7211/';
  cUrl = 'https://localhost:7211/api/';

  headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  };

  Signup(reg: SigupModel): Observable<SigupModel> {
    return this.http.post<SigupModel>(this.Url + 'register', reg, this.headers).pipe();
  }

  Login(log: LoginModel): Observable<LoginModel> {
    return this.http.post<LoginModel>(this.Url + 'login', log, this.headers).pipe();
  }

  GetAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.cUrl + 'Category', this.headers).pipe();
  }

  GetAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.cUrl + 'Product', this.headers).pipe();
  }

  AddProduct(fd: FormData) {
    return this.http.post(this.cUrl + 'Product' + fd, { withCredentials : true }).pipe();
  }
}




