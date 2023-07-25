import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { commonResponse } from '../model/commonResponse';
import { inquiryData } from '../model/inquiryData';
import { inquiryDetailResponse } from '../model/inquiryDetailResponse'; 
import { packageData } from '../model/packageData';
import { packageListResponse } from '../model/packageListResponse';
@Component({
  selector: 'app-add-inquiry',
  templateUrl: './add-inquiry.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddInquiryComponent {
  packageData: packageData[] | undefined;
  packageListResponse:packageListResponse | undefined;
  
  getinquiryDetailResponse!:inquiryDetailResponse;
  commonResponse!:commonResponse;
  inquiryData:inquiryData={
    inquiryIDPK:0,
    packageNameIDFK:0,
    inquiryName:"",
    inquiryEmail:"",
    inquiryCity:"",
    inquiryContactNo:"",
    inquiryDate:"",
    inquiryNoOfPeople:"",
    inquiryMessage:"",
    packageName:"",
    addedOn:"",
    isActive:0,
  }
  inquiryIDPK=0;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    
  }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.inquiryIDPK=params['id'];
    });

    if(this.inquiryIDPK==0|| this.inquiryIDPK==undefined){
      this.inquiryData=new inquiryData();
    }else{
      console.log();
      this.getinquiry();
    }
    this.showPackage();
  }
  showPackage()
  {
    this.service.getPackageList().subscribe(res=>{
    console.log(res);
      this.packageListResponse= res as packageListResponse;
      this.packageData=this.packageListResponse.data;
    },err=>{
      console.log(err);
    });
  }


  getinquiry()
  {
    console.log("inquiryIDPK:" +this.inquiryIDPK);
    this.service.getInquiryDetail(this.inquiryIDPK).subscribe(res=>{
    this.getinquiryDetailResponse=res as inquiryDetailResponse;
    this.inquiryData=this.getinquiryDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }

  onsubmit(form:NgForm)
  {
    console.log("inquiryIDPK:"+this.inquiryIDPK);
    if(this.inquiryIDPK==0 || this.inquiryIDPK==undefined)
    {
      this.insertdetails(form);

    }else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    console.log(this.inquiryData);
    
     if(this.inquiryData.inquiryName != "" && this.inquiryData.packageNameIDFK != 0 && this.inquiryData.inquiryEmail != "" && this.inquiryData.inquiryCity != "" && this.inquiryData.inquiryContactNo != "" && this.inquiryData.inquiryDate != "" && this.inquiryData.inquiryMessage != "" && this.inquiryData.inquiryNoOfPeople != "" ){

  //  this.inquiryData.packageName="string";
    this.inquiryData.addedOn = "string";
    console.log(this.inquiryData);
    
     this.service.InsertInquiry(this.inquiryData).subscribe(res=>{
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
     this.service.UpdateInquiry(this.inquiryData).subscribe(res=>{
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
    this.inquiryData=new inquiryData();
  }


}





  


















  


