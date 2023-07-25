import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { ActivatedRoute, Router,Params } from '@angular/router';
import { restapi } from './../services/RestApiService';
import { bookingData } from '../model/bookingData';
import { commonResponse } from '../model/commonResponse';
import { bookingDetailResponse } from '../model/bookingDetailResponse'; 
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
encapsulation:ViewEncapsulation.None,
})
export class AddBookingComponent {
  getbookingDetailResponse!:bookingDetailResponse;
  commonResponse!:commonResponse;
  bookingData:bookingData={
    userIDFK:0,
    userName:"",
    packageIDFK:0,
    packageName:"",
    bookingIDPK:0,
    bookingName:"",
    bookingType:"select",
    includeEvent:"select",
    includeFoodCourt:"select",
    includeDecorations:"select",
    includeRooms:"select",
    noOfPeoples:"",
    eventDate:"",
    eventTime:"",
    bookingCharges:"",
    bookingStatus:"",

    addedOn:"",
    isActive:0,
  }
  
  bookingIDPK=0;
  
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.bookingIDPK=params['id'];
    });

    if(this.bookingIDPK==0|| this.bookingIDPK==undefined){
      this.bookingData=new bookingData();
    }else{
      console.log();
      this.getbooking();
    }
  }
  getbooking()
  {
    console.log("bookingIDPK:" +this.bookingIDPK);
    this.service.getBookingDetail(this.bookingIDPK).subscribe(res=>{
    this.getbookingDetailResponse=res as bookingDetailResponse;
    this.bookingData=this.getbookingDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }

  onsubmit(form:NgForm)
  {
    console.log("bookingIDPK:"+this.bookingIDPK);
    if(this.bookingIDPK==0 || this.bookingIDPK==undefined)
    {
      this.insertdetails(form);

    }else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    if(this.bookingData.userName != "" && this.bookingData.packageName !="" && this.bookingData.bookingType != "" && this.bookingData.includeEvent != "" && this.bookingData.includeFoodCourt != "" && this.bookingData.includeDecorations != "" && this.bookingData.includeRooms != "" && this.bookingData.noOfPeoples != "" && this.bookingData.eventDate != "" && this.bookingData.eventTime != "" && this.bookingData.bookingCharges != "" && this.bookingData.bookingStatus != ""){
     this.service.InsertBooking(this.bookingData).subscribe(res=>{
      console.log(res);
       this.commonResponse=res as commonResponse;

       if(this.commonResponse.result==="success")
       {
        this.resetForm(form);
          this.router.navigate(['/admin/showbooking']).then(() => {
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
     this.service.UpdateBooking(this.bookingData).subscribe(res=>{
       this.commonResponse=res as commonResponse;

       if(this.commonResponse.result==="success")
       {
         this.resetForm(form);
          this.router.navigate(['/admin/showBooking']).then(() => {
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
    this.bookingData=new bookingData();
  }

}

 
 
  
   

