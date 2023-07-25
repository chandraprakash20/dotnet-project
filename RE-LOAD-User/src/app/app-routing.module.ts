import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { IndexComponent } from './user/index.component';
import { HeaderComponent } from './user/header.component';
import { FooterComponent } from './user/footer.component';
import { AddInquiryComponent } from './user/add-inquiry.component';
import { AddReviewComponent } from './user/add-review.component';
import { AddUserComponent } from './user/add-user.component';
import { ShowInquiryComponent } from './user/show-inquiry.component';
import { ShowReviewComponent } from './user/show-review.component';
import { ShowUserComponent } from './user/show-user.component';
import { ShowEventComponent } from './user/show-event.component';
import { ShowFaqComponent } from './user/show-faq.component';
import { ShowFoodcourtComponent } from './user/show-foodcourt.component';
import { ShowGalleryComponent } from './user/show-gallery.component';
import { ShowPackageComponent } from './user/show-package.component';
import { ShowOffersComponent } from './user/show-offers.component';
import { ShowBookingComponent } from "./user/show-booking.component";
import { AddBookingComponent } from './user/add-booking.component'; 
import { ThankYouComponent } from './user/thank-you.component';
import { TrampolineComponent } from './user/trampoline.component';
import { BowlingAlleComponent } from './user/bowling-alle.component';
import { JumpingParkComponent } from './user/jumping-park.component';
import { VirtualRealityComponent } from './user/virtual-reality.component';
import { ShootingRangeComponent } from './user/shooting-range.component';
import { ArcadeGamesComponent } from './user/arcade-games.component';
import { LoginComponent } from './login.component';
import { ForgetpasswordComponent } from './user/forgetpassword.component';
import { ResetpasswordComponent } from './user/resetpassword.component';
const routes: Routes = [
   {path:"",redirectTo:"/user",pathMatch:"full"},
   
     
     
 {path:"user",component:UserComponent,children:[
     {path:"",component:IndexComponent},

     {path:"Login",component:LoginComponent},




     //Booking
    {path:"addBooking/:id",component:AddBookingComponent},
    {path:"editBooking/:id",component:AddBookingComponent},
   {path:"showBooking",component:ShowBookingComponent},

    //Event
    {path:"showEvent",component:ShowEventComponent},

   
    //Faq
      {path:"showFaq",component:ShowFaqComponent},

    //FoodCourt
     {path:"showFoodcourt",component:ShowFoodcourtComponent},

    

    //Gallery
     {path:"showGallery",component:ShowGalleryComponent},

    //Inquiry
    {path:"addInquiry",component:AddInquiryComponent},
    {path:"editInquiry/:id",component:AddInquiryComponent},
     {path:"showInquiry",component:ShowInquiryComponent},

    //Offers
    {path:"showOffers",component:ShowOffersComponent},

    //Package
     {path:"showPackage",component:ShowPackageComponent},

    
    //Review
    {path:"addReview",component:AddReviewComponent},
    {path:"editReview/:id",component:AddReviewComponent},
     {path:"showReview",component:ShowReviewComponent},

    //User
    {path:"addUser",component:AddUserComponent},
    {path:"editUser/:id",component:AddUserComponent},
     {path:"showUser",component:ShowUserComponent},

     {path:"trampoline",component:TrampolineComponent},
     {path:"bowlingAlle",component:BowlingAlleComponent},
     {path:"arcadeGames",component:ArcadeGamesComponent},
     {path:"shootingRange",component:ShootingRangeComponent},
     {path:"jumpingPark",component:JumpingParkComponent},
     {path:"virtualReality",component:VirtualRealityComponent},

     {path:"forgetpassword",component:ForgetpasswordComponent},
     {path:"resetpassword/:id",component:ResetpasswordComponent},
      //Thank you
      {path:"thankyou",component:ThankYouComponent},

 ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
