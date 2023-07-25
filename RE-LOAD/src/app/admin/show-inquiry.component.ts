import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { inquiryData } from '../model/inquiryData';
import { commonResponse } from '../model/commonResponse';
import { inquiryListResponse } from '../model/inquiryListResponse';

@Component({
  selector: 'app-show-inquiry',
  templateUrl: './show-inquiry.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowInquiryComponent {
  inquiryData: inquiryData[] | undefined;
  inquiryListResponse:inquiryListResponse | undefined;
  commonResponse:commonResponse | undefined;

  constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.showInquiry();
  }
  showInquiry()
  {
    this.service.getInquiryList().subscribe(res=>{
    console.log(res);
      this.inquiryListResponse= res as inquiryListResponse;
      this.inquiryData=this.inquiryListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deleteinquiry(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteInquiry(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showInquiry();
      },err=>{
        console.log(err);
      });
    }
  }
}