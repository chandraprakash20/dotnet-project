import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { ActivatedRoute, Router,Params } from '@angular/router';
import { restapi } from './../services/RestApiService';
import { packageData } from '../model/packageData'; 
import { commonResponse } from '../model/commonResponse';
import { packageDetailResponse } from '../model/packageDetailResponse'; 
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-package',
  templateUrl: './add-package.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class AddPackageComponent {
  getpackageDetailResponse!:packageDetailResponse;
  commonResponse!:commonResponse;
  packageData:packageData={
    
    packageIDPK:0,
    packageName:"",
    packageDescription:"",
    packageImage:"",
    packageCharges:"",
    addedOn:"",
  isActive:0,
  }
  packageIDPK=0;

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
      this.packageIDPK=Params['id'];
    });
   
    if(this.packageIDPK==0|| this.packageIDPK==undefined)
    {
      this.packageData =new packageData();
    }else{
      console.log();
      this.getpackage();
    }

  }
  getpackage()
  {
    console.log("packageIDPK:"+this.packageIDPK);
    this.service.getPackageDetail(this.packageIDPK).subscribe(res=>{
      this.getpackageDetailResponse=res as packageDetailResponse;
      this.packageData = this.getpackageDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }
  onsubmit(form:NgForm)
  {
    console.log("packageIDPK:"+this.packageIDPK);
    if(this.packageIDPK==0 || this.packageIDPK==undefined)
    {
      this.insertdetails(form);
    }
    else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    if(this.packageData.packageName != "" && this.packageData.packageDescription !="" && this.packageData.packageCharges !="" ){
   const formData = new FormData();
   formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
   formData.append('packageIDPK',this.packageData.packageIDPK.toString())
   formData.append('packageName',this.packageData.packageName.toString())
   formData.append('packageDescription',this.packageData.packageDescription.toString())
   formData.append('packageImage',this.packageData.packageImage.toString())
   formData.append('packageCharges',this.packageData.packageCharges.toString())
 
     this.service.InsertPackage(formData).subscribe(res=>{
       console.log(res);
       this.commonResponse=res as commonResponse;
       if(this.commonResponse.result==="success")
       {
         this.restform(form);
         this.Router.navigate(['/admin/showPackage']).then(() => {
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
       formData.append('images',this.packageData.packageImage)
     }
     
     formData.append('packageIDPK',this.packageData.packageIDPK.toString())
     formData.append('packageName',this.packageData.packageName.toString())
   formData.append('packageDescription',this.packageData.packageDescription.toString())
   formData.append('packageImage',this.packageData.packageImage.toString())
   formData.append('packageCharges',this.packageData.packageCharges.toString())
 
    this.service.UpdatePackage(formData).subscribe(res=>{
      this.commonResponse=res as commonResponse;
      if(this.commonResponse.result==="success")
      {
        this.restform(form);
        this.Router.navigate(['/admin/showPackage']).then(() => {
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
    this.packageData=new packageData();
  }

}



