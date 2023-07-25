import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { commonResponse } from '../model/commonResponse';
import { userData } from '../model/userData'; 
import { userDetailResponse } from '../model/userDetailResponse';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddUserComponent {
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
  show: boolean = false;

  
  spassword() {
      this.show = !this.show;
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
      this.insertdetails(form);

    }else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    if(this.userData.userName != "" && this.userData.password !="" && this.userData.email !="" && this.userData.contactNo !="" ){

    this.userData.userType = "user";
     this.service.InsertUser(this.userData).subscribe(res=>{
      console.log(res);
       this.commonResponse=res as commonResponse;

       if(this.commonResponse.result==="success")
       {
        this.resetForm(form);
          this.router.navigate(['/user']).then(() => {
            window.location.reload();
          });
       }else{
         console.log(res);
       }
     },err=>{
       console.log(err);
     });
    }
  }
  updatedetails(form:NgForm)
  {
     this.service.UpdateUser(this.userData).subscribe(res=>{
       this.commonResponse=res as commonResponse;

       if(this.commonResponse.result==="success")
       {
         this.resetForm(form);
          this.router.navigate(['/user']).then(() => {
            window.location.reload();
          });
       }else{
         console.log(res);
       }
     },err=>{
       console.log(err);
     });
  }
  resetForm(form:NgForm)
  {
    form.form.reset();
    this.userData=new userData();
  }


}












  


