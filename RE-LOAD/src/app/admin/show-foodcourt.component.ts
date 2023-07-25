import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { commonResponse } from '../model/commonResponse';
import { foodCourtData } from '../model/foodCourtData'; 
import { FoodCourtListResponse } from '../model/foodCourtListResponse'; 

@Component({
  selector: 'app-show-foodcourt',
  templateUrl: './show-foodcourt.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowFoodcourtComponent {
  foodCourtData: foodCourtData[] | undefined;
  FoodCourtListResponse:FoodCourtListResponse | undefined;
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
    this.showfoodCourt();
  }
  showfoodCourt()
  {
    this.service.getFoodCourtList().subscribe(res=>{
    console.log(res);
      this.FoodCourtListResponse= res as FoodCourtListResponse;
      this.foodCourtData=this.FoodCourtListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletefoodCourt(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteFoodCourt(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showfoodCourt();
      },err=>{
        console.log(err);
      });
    }
  
}

}
