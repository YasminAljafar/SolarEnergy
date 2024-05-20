import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product-model';
import { RegisterServiceService } from 'src/app/services/register-service.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products!:Product[];
  
  constructor(
    private service:RegisterServiceService,
    private router: Router
  ){}
    ngOnInit() {
   this.getAllProducts();
    }

    getAllProducts(){
    this.service.GetAllProducts().subscribe(list=>{
    this.products=list;
    console.log(list);
  },
     ex=> console.log(ex));
    }

}
