import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
//import { ShowBookingComponent } from './admin/show-booking.component';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ShowBookingComponent } from './user/show-booking.component';
import { AddBookingComponent } from './user/add-booking.component';
import { LoginComponent } from './login.component';
import { TrampolineComponent } from './user/trampoline.component';
import { BowlingAlleComponent } from './user/bowling-alle.component';
import { JumpingParkComponent } from './user/jumping-park.component';
import { ArcadeGamesComponent } from './user/arcade-games.component';
import { VirtualRealityComponent } from './user/virtual-reality.component';
import { ShootingRangeComponent } from './user/shooting-range.component';
import { ForgetpasswordComponent } from './user/forgetpassword.component';
import { ResetpasswordComponent } from './user/resetpassword.component';
import { ThankYouComponent } from './user/thank-you.component';
@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    IndexComponent,
    HeaderComponent,
    FooterComponent,
    AddInquiryComponent,
    AddReviewComponent,
    AddUserComponent,
    LoginComponent,
  //  ShowBookingComponent,
    ShowInquiryComponent,
    ShowReviewComponent,
    ShowUserComponent,
    ShowEventComponent,
    ShowFaqComponent,
    ShowFoodcourtComponent,
    ShowGalleryComponent,
    ShowPackageComponent,
    ShowOffersComponent,
    ShowBookingComponent,
    AddBookingComponent,
    LoginComponent,
    TrampolineComponent,
    BowlingAlleComponent,
    JumpingParkComponent,
    ArcadeGamesComponent,
    VirtualRealityComponent,
    ShootingRangeComponent,
    ForgetpasswordComponent,
    ResetpasswordComponent,
    ThankYouComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
