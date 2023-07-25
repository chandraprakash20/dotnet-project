import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { commonResponse } from '../model/commonResponse';
import { faqData } from '../model/faqData'; 
import { faqListResponse } from '../model/faqListResponse'; 

@Component({
  selector: 'app-show-faq',
  templateUrl: './show-faq.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowFaqComponent {
  faqData: faqData[] | undefined;
  faqListResponse:faqListResponse | undefined;
  commonResponse:commonResponse | undefined;

  constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.showfaq();
  }
  showfaq()
  {
    this.service.getFaqList().subscribe(res=>{
    console.log(res);
      this.faqListResponse= res as faqListResponse;
      this.faqData=this.faqListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletefaq(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteFaq(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showfaq();
      },err=>{
        console.log(err);
      });
    }
  
}

}
