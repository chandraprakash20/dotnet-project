import { NgModule } from "@angular/core";
import { RouterModule,Routes } from "@angular/router";
import { AdminComponent } from "./admin/admin.component";
import { IndexComponent } from "./admin/index.component";
import { AddEventComponent } from "./admin/add-event.component";
import { ShowEventComponent } from "./admin/show-event.component";
import { AddFaqComponent } from "./admin/add-faq.component";
import { ShowFaqComponent } from "./admin/show-faq.component";
import { AddFoodcourtComponent } from "./admin/add-foodcourt.component";
import { ShowFoodcourtComponent } from "./admin/show-foodcourt.component";
import { AddGalleryComponent } from "./admin/add-gallery.component";
import { ShowGalleryComponent } from "./admin/show-gallery.component";
import { AddOffersComponent } from "./admin/add-offers.component";
import { ShowOffersComponent } from "./admin/show-offers.component";
import { AddPackageComponent } from "./admin/add-package.component";
import { ShowPackageComponent } from "./admin/show-package.component";
import { ShowInquiryComponent } from "./admin/show-inquiry.component";
import { ShowReviewComponent } from "./admin/show-review.component";
import { ShowUserComponent } from "./admin/show-user.component";
import { ShowBookingComponent } from "./admin/show-booking.component";
import { LoginComponent } from "./login.component"; 
import { AuthGuard } from "./services/auth.guard";
import { AddBookingComponent } from "./admin/add-booking.component";

const routes:Routes=[

    

{path:"",redirectTo:"/login",pathMatch:"full"},

{path:"login",component:LoginComponent},

{path:"admin",component:AdminComponent,children:[
    {path:"",component:IndexComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    
    //Booking
    {path:"editBooking/:id",component:AddBookingComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"showBooking",component:ShowBookingComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    //Event
    {path:"addEvent",component:AddEventComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"editEvent/:id",component:AddEventComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"showEvent",component:ShowEventComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

   

    //Faq
    {path:"addFaq",component:AddFaqComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"editFaq/:id",component:AddFaqComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"showFaq",component:ShowFaqComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    //FoodCourt
    {path:"addFoodcourt",component:AddFoodcourtComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"editFoodcourt/:id",component:AddFoodcourtComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"showFoodcourt",component:ShowFoodcourtComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},


    //Gallery
    {path:"addGallery",component:AddGalleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"editGallery/:id",component:AddGalleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"showGallery",component:ShowGalleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    //Inquiry
    {path:"showInquiry",component:ShowInquiryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    //Offers
    {path:"addOffers",component:AddOffersComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"editOffers/:id",component:AddOffersComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"showOffers",component:ShowOffersComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    //Package
    {path:"addPackage",component:AddPackageComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"editPackage/:id",component:AddPackageComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    {path:"showPackage",component:ShowPackageComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

 

    //Review
    {path:"showReview",component:ShowReviewComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    //User
    {path:"showUser",component:ShowUserComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},


]}
];


@NgModule({
    imports:[RouterModule.forRoot(routes)],
    exports:[RouterModule]
})
export class AppRoutingModule{}