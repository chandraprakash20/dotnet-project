import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { commonResponse } from '../model/commonResponse';
import { reviewData } from '../model/reviewData'; 
import { reviewDetailResponse } from '../model/reviewDetailResponse';
@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddReviewComponent {

  getreviewDetailResponse!:reviewDetailResponse;
  commonResponse!:commonResponse;
  reviewData:reviewData={
    reviewIDPK:0,
    reviewName:"",
    reviewEmail:"",
    reviewFeedBack:"",
    reviewServices:"",
    reviewLocation:"",
    reviewFacilities:"",
    addedOn:"",
    isActive:0,
  }
  reviewIDPK=0;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.reviewIDPK=params['id'];
    });

    if(this.reviewIDPK==0|| this.reviewIDPK==undefined){
      this.reviewData=new reviewData();
    }else{
      console.log();
      this.getfaq();
    }
  }
  getfaq()
  {
    console.log("reviewIDPK:" +this.reviewIDPK);
    this.service.getReviewDetail(this.reviewIDPK).subscribe(res=>{
    this.getreviewDetailResponse=res as reviewDetailResponse;
    this.reviewData=this.getreviewDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }

  onsubmit(form:NgForm)
  {
    console.log("reviewIDPK:"+this.reviewIDPK);
    if(this.reviewIDPK==0 || this.reviewIDPK==undefined)
    {
      this.insertdetails(form);

    }else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    if(this.reviewData.reviewName != ""&&this.reviewData.reviewEmail !=""&&this.reviewData.reviewFeedBack != ""&&this.reviewData.reviewServices != ""&&this.reviewData.reviewLocation != ""&&this.reviewData.reviewFacilities != ""){

     this.service.InsertReview(this.reviewData).subscribe(res=>{
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
     this.service.UpdateReview(this.reviewData).subscribe(res=>{
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
    this.reviewData=new reviewData();
  }



}
















  


