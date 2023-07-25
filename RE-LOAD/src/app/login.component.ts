import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { loginData } from './model/loginData';
import { loginDetailResponse } from './model/loginDetailResponse';
import { loginListResponse } from './model/loginListResponse';
import { restapi } from './services/RestApiService';
import { Utils } from './services/utils.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class LoginComponent implements OnInit{
  
  loginData: loginData = {
    userIdPk:0,
  userName:"",
  email:"",
  password:"",
  contactNo:"",
  userType:"",
  addedOn:"",
  isActive:0,
    
  };
  getloginListResponse!: loginListResponse;

  isvalid = false;
  loginDetailResponse: loginDetailResponse | undefined;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private Router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }
  
  ngOnInit(): void {
    this.loginData = new loginData();
  }
  onSubmit(form: NgForm) {
    this.service.InsertLogin(this.loginData).subscribe(res => {
      console.log(res);
      this.loginDetailResponse = res as loginDetailResponse;


      if (this.loginDetailResponse.result === "success") {

        this.loginData = this.loginDetailResponse.data;
        console.log(this.loginData);

        sessionStorage.setItem('isLoggedIn', "true");
        sessionStorage.setItem('userID', this.loginData.userIdPk.toString());
        sessionStorage.setItem('userType', this.loginData.userType);


        if (this.loginData.userType === 'admin') {
          console.log("success");
          this.Router.navigate(['/admin']).then(() => {
            window.location.reload();
          });
        }
      }
      else {
        console.log("failed");
        

      }

    });

  }

 

}
