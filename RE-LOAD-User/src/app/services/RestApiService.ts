import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { eventData } from "../model/eventData";
import { faqData } from "../model/faqData";
import { foodCourtData } from "../model/foodCourtData";
import { galleryData } from "../model/galleryData";
import { inquiryData } from "../model/inquiryData";
import { offersData } from "../model/offersData";
import { packageData } from "../model/packageData";
import { reviewData } from "../model/reviewData";
import { userData } from "../model/userData";
import { loginData } from "../model/loginData";
import { bookingData } from "../model/bookingData";












@Injectable({
    providedIn:'root'
  })

export class restapi
{
  

    constructor(private http:HttpClient){}
    readonly baseUrl='http://localhost:5090/api/Admin/';


    getDataByID(userID:number):Observable<any>
    {
      return this.http.get(this.baseUrl+"getDataByID/"+userID);
    }
    getUserbyemail(email:string):Observable<any>
    {
      return this.http.get(this.baseUrl+"getUserbyemail/"+email);
    }
    //Login
  getLoginList():Observable<any>
  {
    return this.http.get(this.baseUrl+"LoginList");
  }
  getLoginDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"LoginData/"+id);
  }
  InsertLogin(formData:loginData):Observable<any>
  {
    return this.http.post(this.baseUrl+"Login",formData);
  }
    //Booking
  getBookingList():Observable<any>
  {
    return this.http.get(this.baseUrl+"BookingList");
  }
  getBookingDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"BookingData/"+id);
  }
  InsertBooking(formData:bookingData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertBooking",formData);
  }
  UpdateBooking(formData:bookingData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateBooking",formData);
  }
  DeleteBooking(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteBooking/"+id);
  }

//Event
    getEventList():Observable<any>
  {
    return this.http.get(this.baseUrl+"EventList");
  }
  getEventDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"eventData/"+id);
  }
  InsertEvent(formData :FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertEvent",formData);
  }
  UpdateEvent(formData :FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateEvent",formData);
  }
  DeleteEvent(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteEvent/"+id);
  }

  
//Faq
  getFaqList():Observable<any>
  {
    return this.http.get(this.baseUrl+"FaqList");
  }
  getFaqDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"faqData/"+id);
  }
  InsertFaq(formData:faqData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertFaq",formData);
  }
  UpdateFaq(formData:faqData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateFaq",formData);
  }
  DeleteFaq(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteFaq/"+id);
  }

//FoodCourt
  getFoodCourtList():Observable<any>
  {
    return this.http.get(this.baseUrl+"FoodCourtList");
  }
  getFoodCourtDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"foodCourtData/"+id);
  }
  InsertFoodCourt(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertFoodCourt",formData);
  }
  UpdateFoodCourt(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateFoodCourt",formData);
  }
  DeleteFoodCourt(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteFoodCourt/"+id);
  }

//Gallery
  getGalleryList():Observable<any>
  {
    return this.http.get(this.baseUrl+"GalleryList");
  }
  getGalleryDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"galleryData/"+id);
  }
  InsertGallery(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertGallery",formData);
  }
  UpdateGallery(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateGallery",formData);
  }
  DeleteGallery(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteGallery/"+id);
  }

//Inquiry
  getInquiryList():Observable<any>
  {
    return this.http.get(this.baseUrl+"InquiryList");
  }
  getInquiryDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"inquiryData/"+id);
  }
  InsertInquiry(formData:inquiryData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertinquiry",formData);
  }
  UpdateInquiry(formData:inquiryData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateInquiry",formData);
  }
  DeleteInquiry(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteInquiry/"+id);
  }


//Offers
  getOffersList():Observable<any>
  {
    return this.http.get(this.baseUrl+"OffersList");
  }
  getOffersDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"offersData/"+id);
  }
  InsertOffers(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertOffers",formData);
  }
  UpdateOffers(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateOffers",formData);
  }
  DeleteOffers(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteOffers/"+id);
  }

//Package
  getPackageList():Observable<any>
  {
    return this.http.get(this.baseUrl+"PackageList");
  }
  getPackageDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"packageData/"+id);
  }
  InsertPackage(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertPackage",formData);
  }
  UpdatePackage(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updatePackage",formData);
  }
  DeletePackage(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deletePackage/"+id);
  }



//Review
  getReviewList():Observable<any>
  {
    return this.http.get(this.baseUrl+"reviewList");
  }
  getReviewDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"reviewData/"+id);
  }
  InsertReview(formData:reviewData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertReview",formData);
  }
  UpdateReview(formData:reviewData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateReview",formData);
  }
  DeleteReview(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteReview/"+id);
  }


//User
  getUserList():Observable<any>
  {
    return this.http.get(this.baseUrl+"UserList");
  }
  getUserDetail(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"userData/"+id);
  }
  InsertUser(formData:userData):Observable<any>
  {
    return this.http.post(this.baseUrl+"insertUser",formData);
  }
  UpdateUser(formData:userData):Observable<any>
  {
    return this.http.post(this.baseUrl+"updateUser",formData);
  }
  DeleteUser(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"deleteUser/"+id);
  }


}
