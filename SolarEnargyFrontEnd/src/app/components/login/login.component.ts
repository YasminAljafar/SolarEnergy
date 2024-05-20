import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterServiceService } from 'src/app/services/register-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup;
  logModel!: { email: string; password: string; };
constructor(
  private fb: FormBuilder,
  private service: RegisterServiceService,
  private route :Router
){}

ngOnInit() {
  this.logModel = {
    email: '',
    password: '',
  }
}
login() {
  if(this.loginForm.valid){
    this.ValodateModel();
    this.service.Login(this.logModel).subscribe(success=>{
    this.route.navigate(['home']);
    alert('login succes');
    }, err => {
      console.log(err);
      alert('login fiald');
    })
  }
}
  ValodateModel() {
this.logModel.email=this.loginForm.value.email;
this.logModel.password=this.loginForm.value.password;

}
}
