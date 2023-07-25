import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { packageData } from '../model/packageData';  
import { packageListResponse } from '../model/packageListResponse';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { offersData } from '../model/offersData';
import { offersListResponse } from '../model/offersListResponse';
import { galleryData } from '../model/galleryData';
import { galleryListResponse } from '../model/galleryListResponse'; 

import { foodCourtData } from '../model/foodCourtData'; 
import { FoodCourtListResponse } from '../model/foodCourtListResponse'; 
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class IndexComponent {
  packageData: packageData[] | undefined;
  packageListResponse:packageListResponse | undefined;
  packageCount=0;
  baseUrl =" ";
  foodCourtData: foodCourtData[] | undefined;
  FoodCourtListResponse:FoodCourtListResponse | undefined;
  
  offersData: offersData[] | undefined;
  offersListResponse:offersListResponse | undefined;
  
  galleryData: galleryData[] | undefined;
  galleryListResponse:galleryListResponse | undefined;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.baseUrl = this.utils.baseUrl;
    this.showPackage();
    this.showOffers();
    this.showGallery();
    this.showfoodCourt();
  }
  add(id:number){
    if(sessionStorage.getItem("isLoggedIn")){
    this.router.navigate(['/user/addBooking/'+id]).then(()=>{
      window.location.reload();
    });
  }else{
    this.router.navigate(['/user/Login']).then(()=>{
      window.location.reload();
    });
  }
  }
  showfoodCourt()
  {
    this.service.getFoodCourtList().subscribe(res=>{
    console.log(res);
      this.FoodCourtListResponse= res as FoodCourtListResponse;
      this.foodCourtData=this.FoodCourtListResponse.data.splice(0,4);
    },err=>{
      console.log(err);
    });
  }
  showPackage()
  {
    this.service.getPackageList().subscribe(res=>{
    console.log(res);
      this.packageListResponse= res as packageListResponse;
      this.packageData=this.packageListResponse.data;
      this.packageCount=this.packageData.length;

    },err=>{
      console.log(err);
    });
  }
  showOffers()
  {
    this.service.getOffersList().subscribe(res=>{
    console.log(res);
      this.offersListResponse= res as offersListResponse;
      this.offersData=this.offersListResponse.data.splice(0,4);
    },err=>{
      console.log(err);
    });
  }
  showGallery()
  {
    this.service.getGalleryList().subscribe(res=>{
    console.log(res);
      this.galleryListResponse= res as galleryListResponse;
      this.galleryData=this.galleryListResponse.data.splice(0,4);
    },err=>{
      console.log(err);
    });
  }
}
