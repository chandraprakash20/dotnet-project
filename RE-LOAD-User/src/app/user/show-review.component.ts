import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { reviewData } from '../model/reviewData';
import { commonResponse } from '../model/commonResponse';
import { reviewListResponse } from '../model/reviewListResponse';

@Component({
  selector: 'app-show-review',
  templateUrl: './show-review.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowReviewComponent {
  reviewData: reviewData[] | undefined;
  reviewListResponse:reviewListResponse | undefined;
  commonResponse:commonResponse | undefined;

  constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.showreview();
  }
  showreview()
  {
    this.service.getReviewList().subscribe(res=>{
    console.log(res);
      this.reviewListResponse= res as reviewListResponse;
      this.reviewData=this.reviewListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletereview(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteReview(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showreview();
      },err=>{
        console.log(err);
      });
    }
  }
}







 