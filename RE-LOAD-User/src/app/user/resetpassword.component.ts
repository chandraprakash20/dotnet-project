import { Component, OnInit, ViewEncapsulation } from '@angular/core'; 
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService'; 
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { commonResponse } from '../model/commonResponse';
import { userData } from '../model/userData';
import { userDetailResponse } from '../model/userDetailResponse';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class ResetpasswordComponent implements OnInit{
  userData: any;
  userIDPK: any;
  commonResponse: commonResponse | undefined;
  userDetailResponse: userDetailResponse | undefined;


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
    this.getUser();
  }
  getUser() {
    console.log("User ID:" + this.userIDPK);
    console.log(this.userData);
    this.service.getUserDetail(this.userIDPK).subscribe(res => {
      this.userDetailResponse=res as userDetailResponse;
      this.userData=this.userDetailResponse.data;
      
    }, err => {
      console.log(err);
    })
  }

  onsubmit(form: NgForm) {
    console.log("userIDPK:" + this.userIDPK);
   
      this.updateDetails(form);
  }

  updateDetails(form:NgForm)
   {
   

    this.service.UpdateUser(this.userData).subscribe(res=>{
      console.log(res);
      this.commonResponse= res as commonResponse;
      if(this.commonResponse.result === "success")
      {
        this.resetForm(form);
        this.router.navigate(['/']).then(() => {
          window.location.reload();
        });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  restform(form: NgForm) {
    form.form.reset();

    this.userData = new userData();
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.userData=new userData();
  }


}

