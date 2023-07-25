import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { reviewData } from '../model/reviewData';
import { reviewListResponse } from '../model/reviewListResponse';
import { userData } from '../model/userData'; 
import { userListResponse } from '../model/userListResponse';
import { inquiryData } from '../model/inquiryData';
import { inquiryListResponse } from '../model/inquiryListResponse';
import { bookingData } from '../model/bookingData'; 

import { bookingListResponse } from '../model/bookingListResponse';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class IndexComponent {
  userData: userData[] | undefined;
  userListResponse:userListResponse | undefined;
  userCount=0;

  bookingData: bookingData[] | undefined;
  bookingListResponse:bookingListResponse | undefined;
  bookingCount=0;

  reviewData: reviewData[] | undefined;
  reviewListResponse:reviewListResponse | undefined;
  reviewCount=0;

  inquiryData: inquiryData[] | undefined;
  inquiryListResponse:inquiryListResponse | undefined;
  inquiryCount=0;

 
  constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadIndexScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.showUser();
    this.showreview();
    this.showInquiry();
    this.showbooking();

  }
  showUser()
  {
    this.service.getUserList().subscribe(res=>{
    console.log(res);
      this.userListResponse= res as userListResponse;
      this.userData=this.userListResponse.data;
      this.userCount=this.userData.length;
    },err=>{
      console.log(err);
    });
  }
  showbooking()
  {
    this.service.getBookingList().subscribe(res=>{
    console.log(res);
      this.bookingListResponse= res as bookingListResponse;
      this.bookingData=this.bookingListResponse.data;
      this.bookingCount=this.bookingData.length;

    },err=>{
      console.log(err);
    });
  }
  showreview()
  {
    this.service.getReviewList().subscribe(res=>{
    console.log(res);
      this.reviewListResponse= res as reviewListResponse;
      this.reviewData=this.reviewListResponse.data;
      this.reviewCount=this.reviewData.length;

    },err=>{
      console.log(err);
    });
  }
  
  showInquiry()
  {
    this.service.getInquiryList().subscribe(res=>{
    console.log(res);
      this.inquiryListResponse= res as inquiryListResponse;
      this.inquiryData=this.inquiryListResponse.data;
      this.inquiryCount=this.inquiryData.length;

    },err=>{
      console.log(err);
    });
  }

  
}
