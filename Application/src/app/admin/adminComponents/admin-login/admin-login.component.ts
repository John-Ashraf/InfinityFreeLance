import { Component } from '@angular/core';
import { LoginAdminServiceService } from '../../../services/login-admin-service.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { adminData } from '../../../models/ilogin';



@Component({
  selector: 'app-admin-login',
  imports: [CommonModule,FormsModule],
  templateUrl: './admin-login.component.html',
  styleUrl: './admin-login.component.css'
})
export class AdminLoginComponent {
  data:adminData={
    UserName:'',
    Password:''
  }
  constructor(private loginService:LoginAdminServiceService){}
  login(){
    // const formData = new FormData();
    //   formData.append('UserName', this.data.UserName);
    //   formData.append('Password', this.data.Password);
    const formData = {
      UserName: this.data.UserName,
      Password: this.data.Password
    };
      console.log(formData);
      this.loginService.postLogin(formData).subscribe({
        next:(res)=>{
          console.log(res)
        },
        error:(err)=>{
          console.log(err)
        }
      })

  }
}
