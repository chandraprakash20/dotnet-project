import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { ActivatedRoute, Router,Params } from '@angular/router';
import { restapi } from './../services/RestApiService';
import { eventData } from '../model/eventData';
import { commonResponse } from '../model/commonResponse';
import { EventDetailResponse } from '../model/eventDetailResponse';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  encapsulation:ViewEncapsulation.None,
})

export class AddEventComponent {
  geteventDetailResponse!:EventDetailResponse;
  commonResponse!:commonResponse;
  EventData:eventData={
    
  eventIDPK:0,
  eventName:"",
  eventDescription:"",
  eventImage:"",
  eventCharges:"",
  addedOn:"",
  isActive:0,
  }
  eventIDPK=0;

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
      this.eventIDPK=Params['id'];
    });
   
    if(this.eventIDPK==0|| this.eventIDPK==undefined)
    {
      this.EventData =new eventData();
    }else{
      console.log();
      this.getevent();
    }

  }
  getevent()
  {
    console.log("eventIDPK:"+this.eventIDPK);
    this.service.getEventDetail(this.eventIDPK).subscribe(res=>{
      this.geteventDetailResponse=res as EventDetailResponse;
      this.EventData = this.geteventDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }
  onsubmit(form:NgForm)
  {
    console.log("eventIDPK:"+this.eventIDPK);
    if(this.eventIDPK==0 || this.eventIDPK==undefined)
    {
      this.insertdetails(form);
    }
    else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
 
    if(this.EventData.eventName != "" && this.EventData.eventDescription !="" && this.EventData.eventCharges != "" ){
   const formData = new FormData();
   formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
   formData.append('eventIDPK',this.EventData.eventIDPK.toString())
   formData.append('eventName',this.EventData.eventName.toString())
   formData.append('eventDescription',this.EventData.eventDescription.toString())
   formData.append('eventCharges',this.EventData.eventCharges.toString())
 
     this.service.InsertEvent(formData).subscribe(res=>{
       console.log(res);
       this.commonResponse=res as commonResponse;
       if(this.commonResponse.result==="success")
       {
         this.restform(form);
         this.Router.navigate(['/admin/showEvent']).then(() => {
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
       formData.append('images',this.EventData.eventImage)
     }
     
     formData.append('eventIDPK',this.EventData.eventIDPK.toString())
     formData.append('eventName',this.EventData.eventName.toString())
   formData.append('eventDescription',this.EventData.eventDescription.toString())
   formData.append('eventCharges',this.EventData.eventCharges.toString())
 
    this.service.UpdateEvent(formData).subscribe(res=>{
      this.commonResponse=res as commonResponse;
      if(this.commonResponse.result==="success")
      {
        this.restform(form);
        this.Router.navigate(['/admin/showEvent']).then(() => {
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
    this.EventData=new eventData();
  }
   
}
