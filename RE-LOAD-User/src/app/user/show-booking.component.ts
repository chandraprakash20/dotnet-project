import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { commonResponse } from '../model/commonResponse';
import { bookingData } from '../model/bookingData'; 
import { bookingListResponse } from '../model/bookingListResponse'; 

@Component({
  selector: 'app-show-booking',
  templateUrl: './show-booking.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowBookingComponent {
  bookingData: bookingData[] | undefined;
  bookingListResponse:bookingListResponse | undefined;
  commonResponse:commonResponse | undefined;
  baseUrl =" ";
  userIDFK=0;
constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.baseUrl = this.utils.baseUrl;
    this.showbooking();
  }
  showbooking()
  {
  
    
    // this.service.getUserDetail(this.userIdPk).subscribe(res=>{
    // console.log(res);
    //   this.userDetailResponse= res as userDetailResponse;
    //   this.userData=this.userDetailResponse.data;
    //   this.bookingData.userIDFK = this.userData.userIdPk;
    //   this.bookingData.bookingName = this.userData.userName;
    // },err=>{
    //   console.log(err);
    // });
    this.userIDFK= Number.parseInt(sessionStorage.getItem("userID")!.toString());
    console.log(this.userIDFK);
    
    this.service.getDataByID(this.userIDFK).subscribe(res=>{
    console.log(res);
      this.bookingListResponse= res as bookingListResponse;
      this.bookingData=this.bookingListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletebooking(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteBooking(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showbooking();
      },err=>{
        console.log(err);
      });
    }
  
}

}

