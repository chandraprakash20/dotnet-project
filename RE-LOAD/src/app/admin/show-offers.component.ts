import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { offersData } from '../model/offersData';
import { commonResponse } from '../model/commonResponse';
import { offersListResponse } from '../model/offersListResponse';

@Component({
  selector: 'app-show-offers',
  templateUrl: './show-offers.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowOffersComponent {
  offersData: offersData[] | undefined;
  offersListResponse:offersListResponse | undefined;
  commonResponse:commonResponse | undefined;
  baseUrl =" ";
  constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.baseUrl = this.utils.baseUrl;
    this.showOffers();
  }
  showOffers()
  {
    this.service.getOffersList().subscribe(res=>{
    console.log(res);
      this.offersListResponse= res as offersListResponse;
      this.offersData=this.offersListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deleteoffers(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteOffers(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showOffers();
      },err=>{
        console.log(err);
      });
    }
  }
}