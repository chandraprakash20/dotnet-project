import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { commonResponse } from '../model/commonResponse';
import { bookingData } from '../model/bookingData'; 
import { bookingDetailResponse } from '../model/bookingDetailResponse';  
import { userData } from '../model/userData';
import { userListResponse } from '../model/userListResponse';
import { userDetailResponse } from '../model/userDetailResponse';
import { packageData } from '../model/packageData';
import { packageDetailResponse } from '../model/packageDetailResponse';
import { packageListResponse } from '../model/packageListResponse';
@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AddBookingComponent {
  userData: userData | undefined;
  userListResponse:userListResponse | undefined;
  userDetailResponse:userDetailResponse | undefined;

  packageData: packageData | undefined;
  packageListResponse:packageListResponse | undefined;
  packageDetailResponse:packageDetailResponse | undefined;

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
  userIdPk=0;
  bookingIDPK=0;
  packageIDPK=0;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe((Params:Params)=>{
      this.packageIDPK=Params['id'];
    });
    this.bookingData.packageIDFK = this.packageIDPK;
    this.showUser();
    this.showPackage();
  }
   
  showPackage()
  {
   
    this.service.getPackageDetail(this.packageIDPK).subscribe(res=>{
    console.log(res);
      this.packageDetailResponse= res as packageDetailResponse;
      this.packageData=this.packageDetailResponse.data;
      
      this.bookingData.packageName = this.packageData.packageName;
  
    },err=>{
      console.log(err);
    });
  }
  
  showUser()
  {
    this.userIdPk= Number.parseInt(sessionStorage.getItem("userID")!.toString());
    console.log(this.userIdPk);
    
    this.service.getUserDetail(this.userIdPk).subscribe(res=>{
    console.log(res);
      this.userDetailResponse= res as userDetailResponse;
      this.userData=this.userDetailResponse.data;
      this.bookingData.userIDFK = this.userData.userIdPk;
      this.bookingData.userName = this.userData.userName;
    },err=>{
      console.log(err);
    });
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
    console.log(this.bookingData.userName )
    console.log(this.bookingData.packageName )
    console.log(this.bookingData.bookingType )
    console.log(this.bookingData.includeEvent )
    console.log(this.bookingData.includeFoodCourt )
    console.log(this.bookingData.includeDecorations )

    console.log(this.bookingData.includeRooms )
    console.log(this.bookingData.eventDate )
    console.log(this.bookingData.eventTime )
    if(this.bookingData.userName != "" && this.bookingData.packageName !="" && this.bookingData.bookingType != "" && this.bookingData.includeEvent != "" && this.bookingData.includeFoodCourt != "" && this.bookingData.includeDecorations != "" && this.bookingData.includeRooms != "" && this.bookingData.noOfPeoples != "" && this.bookingData.eventDate != "" && this.bookingData.eventTime != ""  ){

    this.bookingData.bookingCharges="waiting";
    this.bookingData.addedOn = "string";
    this.bookingData.bookingStatus="waiting";

      
     this.service.InsertBooking(this.bookingData).subscribe(res=>{
      console.log(res);
       this.commonResponse=res as commonResponse;

       if(this.commonResponse.result==="success")
       {
        this.resetForm(form);
          this.router.navigate(['/user/thankyou']).then(() => {
            window.location.reload();
          });
       }else{
         console.log(res);
       }
     },err=>{
       console.log(err);
     });
    }else{
      console.log('else')
    }
  }
  updatedetails(form:NgForm)
  {
     this.service.UpdateBooking(this.bookingData).subscribe(res=>{
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
    this.bookingData=new bookingData();
  }


}









  


















  


