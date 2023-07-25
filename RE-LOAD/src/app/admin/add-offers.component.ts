import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { ActivatedRoute, Router,Params } from '@angular/router';
import { restapi } from './../services/RestApiService';
import { offersData } from '../model/offersData'; 
import { commonResponse } from '../model/commonResponse';
import { offersDetailResponse } from '../model/offersDetailResponse'; 
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-offers',
  templateUrl: './add-offers.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class AddOffersComponent {
  getoffersDetailResponse!:offersDetailResponse;
  commonResponse!:commonResponse;
  offersData:offersData={
    
  offersIDPK:0,
  offersPromocode:"",
  offersPhoto:"",
  offersDescription:"",
  addedOn:"",
  isActive:0,
  }
  offersIDPK=0;

  filesToUpload : FileList | undefined;

  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private Router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }
  public uploadFile = (files: FileList | null) =>{
    if(files!.length === 0){
      return;
    }
    this.filesToUpload = files!
  }
  ngOnInit(): void {
    this.route.params.subscribe((Params:Params)=>{
      this.offersIDPK=Params['id'];
    });
   
    if(this.offersIDPK==0|| this.offersIDPK==undefined)
    {
      this.offersData =new offersData();
    }else{
      console.log();
      this.getoffers();
    }

  }
  getoffers()
  {
    console.log("offersIDPK:"+this.offersIDPK);
    this.service.getOffersDetail(this.offersIDPK).subscribe(res=>{
      this.getoffersDetailResponse=res as offersDetailResponse;
      this.offersData = this.getoffersDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }
  onsubmit(form:NgForm)
  {
    console.log("offersIDPK:"+this.offersIDPK);
    if(this.offersIDPK==0 || this.offersIDPK==undefined)
    {
      this.insertdetails(form);
    }
    else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    if(this.offersData.offersPromocode != "" && this.offersData.offersDescription !="" ){
   const formData = new FormData();
   formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
   formData.append('offersIDPK',this.offersData.offersIDPK.toString())
   formData.append('offersPromocode',this.offersData.offersPromocode.toString())
   formData.append('offersPhoto',this.offersData.offersPhoto.toString())
   formData.append('offersDescription',this.offersData.offersDescription.toString())
 
     this.service.InsertOffers(formData).subscribe(res=>{
       console.log(res);
       this.commonResponse=res as commonResponse;
       if(this.commonResponse.result==="success")
       {
         this.restform(form);
         this.Router.navigate(['/admin/showOffers']).then(() => {
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
   const formData = new FormData();
     if(this.filesToUpload != null || this.filesToUpload != undefined){
       formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
     }else{
       formData.append('images',this.offersData.offersPhoto)
     }
     
     formData.append('offersIDPK',this.offersData.offersIDPK.toString())
     formData.append('offersPromocode',this.offersData.offersPromocode.toString())
   formData.append('offersPhoto',this.offersData.offersPhoto.toString())
   formData.append('offersDescription',this.offersData.offersDescription.toString())
 
    this.service.UpdateOffers(formData).subscribe(res=>{
      this.commonResponse=res as commonResponse;
      if(this.commonResponse.result==="success")
      {
        this.restform(form);
        this.Router.navigate(['/admin/showOffers']).then(() => {
         window.location.reload();
       });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }
 
 
  restform(form:NgForm)
  {
    form.form.reset();
    this.offersData=new offersData();
  }
}