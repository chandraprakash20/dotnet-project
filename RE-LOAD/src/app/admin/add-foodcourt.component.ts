import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { ActivatedRoute, Router,Params } from '@angular/router';
import { restapi } from './../services/RestApiService';
import { foodCourtData } from '../model/foodCourtData'; 
import { commonResponse } from '../model/commonResponse';
import { FoodCourtDetailResponse } from '../model/foodCourtDetailResponse'; 
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-foodcourt',
  templateUrl: './add-foodcourt.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class AddFoodcourtComponent {
  getFoodCourtDetailResponse!:FoodCourtDetailResponse;
  commonResponse!:commonResponse;
  foodCourtData:foodCourtData={
    
    foodCourtIDPK:0,
    foodCourtName:"",
    foodCourtImage:"",
    foodCourtDescription:"",
    addedOn:"",
    isActive:0,

  }
  foodCourtIDPK=0;

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
      this.foodCourtIDPK=Params['id'];
    });
   
    if(this.foodCourtIDPK==0|| this.foodCourtIDPK==undefined)
    {
      this.foodCourtData =new foodCourtData();
    }else{
      console.log();
      this.getfoodcourt();
    }

  }
  getfoodcourt()
  {
    console.log("foodCourtIDPK:"+this.foodCourtIDPK);
    this.service.getFoodCourtDetail(this.foodCourtIDPK).subscribe(res=>{
      this.getFoodCourtDetailResponse=res as FoodCourtDetailResponse;
      this.foodCourtData = this.getFoodCourtDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }
  onsubmit(form:NgForm)
  {
    console.log("foodCourtIDPK:"+this.foodCourtIDPK);
    if(this.foodCourtIDPK==0 || this.foodCourtIDPK==undefined)
    {
      this.insertdetails(form);
    }
    else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    if(this.foodCourtData.foodCourtName != "" && this.foodCourtData.foodCourtDescription !="" ){
   const formData = new FormData();
   formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
   formData.append('foodCourtIDPK',this.foodCourtData.foodCourtIDPK.toString())
   formData.append('foodCourtName',this.foodCourtData.foodCourtName.toString())
   formData.append('foodCourtDescription',this.foodCourtData.foodCourtDescription.toString())
 
     this.service.InsertFoodCourt(formData).subscribe(res=>{
       console.log(res);
       this.commonResponse=res as commonResponse;
       if(this.commonResponse.result==="success")
       {
         this.restform(form);
         this.Router.navigate(['/admin/showFoodcourt']).then(() => {
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
       formData.append('images',this.foodCourtData.foodCourtImage)
     }
     
     formData.append('foodCourtIDPK',this.foodCourtData.foodCourtIDPK.toString())
     formData.append('foodCourtName',this.foodCourtData.foodCourtName.toString())
     formData.append('foodCourtDescription',this.foodCourtData.foodCourtDescription.toString())
 
    this.service.UpdateFoodCourt(formData).subscribe(res=>{
      this.commonResponse=res as commonResponse;
      if(this.commonResponse.result==="success")
      {
        this.restform(form);
        this.Router.navigate(['/admin/showFoodcourt']).then(() => {
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
    this.foodCourtData=new foodCourtData();
  }

}
