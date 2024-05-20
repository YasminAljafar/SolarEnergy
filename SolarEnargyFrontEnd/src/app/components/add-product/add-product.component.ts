import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Category } from 'src/app/models/category-model';
import { RegisterServiceService } from 'src/app/services/register-service.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  constructor(
    private service: RegisterServiceService,
    private fb: FormBuilder
  ) { }
  categories!: Category[];
  AddProductForm!: FormGroup;



  ngOnInit(): void {
    this.getAllCategories();
    this.AddProductForm=this.fb.group({
      name: '',
      price: 0,
      description:'',
      catid:0,
  //   id:0
    })

  }

  getAllCategories() {
    this.service.GetAllCategories().subscribe(list => {
      this.categories = list;
      console.log(list);
    },
      ex => console.log(ex));
  }

  AddProduct() {
    if (this.AddProductForm.valid) {
      const fd=new FormData();
      //fd.append('id',this.AddProductForm.value.id);
      fd.append('name',this.AddProductForm.value.name);
      fd.append('catid',this.AddProductForm.value.catid);
      fd.append('price',this.AddProductForm.value.price);
      fd.append('description', this.AddProductForm.value.description);
      
      this.service.AddProduct(fd).subscribe(success => {
        alert('product added successfully')
      },
        err => console.log(err))
        alert('product ok ')

    }
  }


}
