import { Component, OnInit, ViewEncapsulation } from '@angular/core'; 
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService'; 
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { commonResponse } from '../model/commonResponse';
import { userData } from '../model/userData';
import { userDetailResponse } from '../model/userDetailResponse';

@Component({
  selector: 'app-forgetpassword',
  templateUrl: './forgetpassword.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ForgetpasswordComponent implements OnInit {

  getuserDetailResponse!:userDetailResponse;
  commonResponse!:commonResponse;
  userData:userData={
    userIdPk:0,
    userName:"",
    email:"",
    password:"",
    contactNo:"",
    userType:"",
    addedOn:"",
    isActive:0,
  }
  userIDPK=0;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }


  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.userIDPK=params['id'];
    });

    if(this.userIDPK==0|| this.userIDPK==undefined){
      this.userData=new userData();
    }else{
      console.log();
      this.getuser();
    }
  }
  getuser()
  {
    console.log("userIDPK:" +this.userIDPK);
    this.service.getUserDetail(this.userIDPK).subscribe(res=>{
    this.getuserDetailResponse=res as userDetailResponse;
    this.userData=this.getuserDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }

  onsubmit(form:NgForm)
  {
    console.log("userIDPK:"+this.userIDPK);
    if(this.userIDPK==0 || this.userIDPK==undefined)
    {
      this.getUserbyemail();
    }
  }

  getUserbyemail()
  {
    this.service.getUserbyemail(this.userData.email).subscribe(res=>{
      console.log(res);
      this.getuserDetailResponse=res as userDetailResponse;
      this.userData=this.getuserDetailResponse.data;
        this.router.navigate(['/user/resetpassword/'+this.userData.userIdPk.toString()]).then(() => {
            window.location.reload();
          });
        });
      
      }
}




