import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SigupModel } from 'src/app/models/signup-model';
import { RegisterServiceService } from 'src/app/services/register-service.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  userForm !: FormGroup;
  reg !: { email: string; password: string; } ;

  constructor(
    private fb: FormBuilder,
    private service: RegisterServiceService
  ) { }
  ngOnInit() {
    this.reg = {
      email: '',
      password: ''
    }
    this.userForm = this.fb.group({
      email: '',
      password: ''
    });
  }
  signup() {
    if (this.userForm.valid) {
      this.validateRegisterModel();
      this.service.Signup(this.reg).subscribe(succes=>
        {
          alert('registration succes');
        }, 
        err=> console.log(err))
    }
  }
  validateRegisterModel() {
this.reg.email=this.userForm.value.email;
this.reg.password=this.userForm.value.password;

  }
}
