import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { IndexComponent } from './admin/index.component';
import { HeaderComponent } from './admin/header.component';
import { FooterComponent } from './admin/footer.component';
import { AddEventComponent } from './admin/add-event.component';
import { ShowEventComponent } from './admin/show-event.component';
import { ShowFaqComponent } from './admin/show-faq.component';
import { ShowFoodcourtComponent } from './admin/show-foodcourt.component';
import { ShowGalleryComponent } from './admin/show-gallery.component';
import { ShowInquiryComponent } from './admin/show-inquiry.component';
import { ShowOffersComponent } from './admin/show-offers.component';
import { ShowPackageComponent } from './admin/show-package.component';
import { ShowReviewComponent } from './admin/show-review.component';
import { ShowUserComponent } from './admin/show-user.component';
import { AddFaqComponent } from './admin/add-faq.component';
import { AddFoodcourtComponent } from './admin/add-foodcourt.component';
import { AddGalleryComponent } from './admin/add-gallery.component';
import { AddOffersComponent } from './admin/add-offers.component';
import { AddPackageComponent } from './admin/add-package.component';
import { AppRoutingModule } from './app.routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ShowBookingComponent } from './admin/show-booking.component';
import { LoginComponent } from './login.component';
import { AddBookingComponent } from './admin/add-booking.component';
@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    IndexComponent,
    HeaderComponent,
    FooterComponent,
    AddEventComponent,
    ShowEventComponent,
    ShowBookingComponent,
    ShowFaqComponent,
    ShowFoodcourtComponent,
    LoginComponent,
    ShowGalleryComponent,
    ShowInquiryComponent,
    ShowOffersComponent,
    ShowPackageComponent,
    ShowReviewComponent,
    ShowUserComponent,
    AddFaqComponent,
    AddFoodcourtComponent,
    AddBookingComponent,
    AddGalleryComponent,
    AddOffersComponent,
    AddPackageComponent
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
