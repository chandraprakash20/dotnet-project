import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { commonResponse } from '../model/commonResponse';
import { faqData } from '../model/faqData';
import { faqDetailResponse } from '../model/faqDetailResponse';

@Component({
  selector: 'app-add-faq',
  templateUrl: './add-faq.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class AddFaqComponent {
  getfaqDetailResponse!:faqDetailResponse;
  commonResponse!:commonResponse;
  faqData:faqData={
    faqIDPK:0,
    faqQuestions:"",
    faqAnswers:"",
    addedOn:"",
    isActive:0,
  }
  faqIDPK=0;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.faqIDPK=params['id'];
    });

    if(this.faqIDPK==0|| this.faqIDPK==undefined){
      this.faqData=new faqData();
    }else{
      console.log();
      this.getfaq();
    }
  }
  getfaq()
  {
    console.log("faqIDPK:" +this.faqIDPK);
    this.service.getFaqDetail(this.faqIDPK).subscribe(res=>{
    this.getfaqDetailResponse=res as faqDetailResponse;
    this.faqData=this.getfaqDetailResponse.data;
    },err=>{
      console.log(err);
    })
  }

  onsubmit(form:NgForm)
  {
    console.log("faqIDPK:"+this.faqIDPK);
    if(this.faqIDPK==0 || this.faqIDPK==undefined)
    {
      this.insertdetails(form);

    }else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
    if(this.faqData.faqQuestions != "" && this.faqData.faqAnswers !=""){
     this.service.InsertFaq(this.faqData).subscribe(res=>{
      console.log(res);
       this.commonResponse=res as commonResponse;

       if(this.commonResponse.result==="success")
       {
        this.resetForm(form);
          this.router.navigate(['/admin/showFaq']).then(() => {
            window.location.reload();
          });
       }else{
         console.log(res);
       }
     },err=>{
       console.log(err);
     });
    }
  }
  updatedetails(form:NgForm)
  {
     this.service.UpdateFaq(this.faqData).subscribe(res=>{
       this.commonResponse=res as commonResponse;

       if(this.commonResponse.result==="success")
       {
         this.resetForm(form);
          this.router.navigate(['/admin/showFaq']).then(() => {
            window.location.reload();
          });
       }else{
         console.log(res);
       }
     },err=>{
       console.log(err);
     });
  }
  resetForm(form:NgForm)
  {
    form.form.reset();
    this.faqData=new faqData();
  }

}









  

