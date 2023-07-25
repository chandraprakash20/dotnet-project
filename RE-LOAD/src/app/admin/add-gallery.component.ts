import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { ActivatedRoute, Router,Params } from '@angular/router';
import { restapi } from './../services/RestApiService';
import { galleryData } from '../model/galleryData'; 
import { commonResponse } from '../model/commonResponse';
import { galleryDetailResponse } from '../model/galleryDetailResponse';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-gallery',
  templateUrl: './add-gallery.component.html',
  encapsulation:ViewEncapsulation.None,
})

export class AddGalleryComponent {

  getgalleryDetailResponse!:galleryDetailResponse;
  commonResponse!:commonResponse;
  galleryData:galleryData={
    
    galleryIDPK:0,
    galleryImage:"",
    addedOn:"",
  isActive:0,
  }
  galleryIDPK=0;

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
      this.galleryIDPK=Params['id'];
    });
   
    if(this.galleryIDPK==0|| this.galleryIDPK==undefined)
    {
      this.galleryData =new galleryData();
    }else{
      console.log();
      this.getGallery();
    }

  }
  getGallery()
  {
    console.log("galleryIDPK:"+this.galleryIDPK);
    this.service.getGalleryDetail(this.galleryIDPK).subscribe(res=>{
      this.getgalleryDetailResponse=res as galleryDetailResponse;
      this.galleryData = this.getgalleryDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }
  onsubmit(form:NgForm)
  {
    console.log("galleryIDPK:"+this.galleryIDPK);
    if(this.galleryIDPK==0 || this.galleryIDPK==undefined)
    {
      this.insertdetails(form);
    }
    else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    
   const formData = new FormData();
   formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
   formData.append('galleryIDPK',this.galleryData.galleryIDPK.toString())
   formData.append('GalleryName',this.galleryData.galleryImage.toString())
   
     this.service.InsertGallery(formData).subscribe(res=>{
       console.log(res);
       this.commonResponse=res as commonResponse;
       if(this.commonResponse.result==="success")
       {
         this.restform(form);
         this.Router.navigate(['/admin/showGallery']).then(() => {
           window.location.reload();
         });
       }else{
         console.log(res);
       }
     },err=>{
       console.log(err);
     });
    
  }
  updatedetails(form:NgForm)
  {
   const formData = new FormData();
     if(this.filesToUpload != null || this.filesToUpload != undefined){
       formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
     }else{
       formData.append('images',this.galleryData.galleryImage)
     }
     
     formData.append('galleryIDPK',this.galleryData.galleryIDPK.toString())
     formData.append('GalleryName',this.galleryData.galleryImage.toString())
  
    this.service.UpdateGallery(formData).subscribe(res=>{
      this.commonResponse=res as commonResponse;
      if(this.commonResponse.result==="success")
      {
        this.restform(form);
        this.Router.navigate(['/admin/showGallery']).then(() => {
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
    this.galleryData=new galleryData();
  }
 
}