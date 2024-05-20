import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/models/category-model';
import { RegisterServiceService } from 'src/app/services/register-service.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
categories!:Category[];

constructor(
  private service:RegisterServiceService,
  private router: Router

){}
  ngOnInit(): void {
 this.getAllCategories();
  }


  getAllCategories(){
this.service.GetAllCategories().subscribe(list=>{
  this.categories=list;
  console.log(list);
},
   ex=> console.log(ex));
  }
}
