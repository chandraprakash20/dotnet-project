import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { packageData } from '../model/packageData';  
import { commonResponse } from '../model/commonResponse';
import { packageListResponse } from '../model/packageListResponse';

@Component({
  selector: 'app-show-package',
  templateUrl: './show-package.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowPackageComponent {
  packageData: packageData[] | undefined;
  packageListResponse:packageListResponse | undefined;
  commonResponse:commonResponse | undefined;
  baseUrl =" ";
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.baseUrl = this.utils.baseUrl;
    this.showPackage();
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

  showPackage()
  {
    this.service.getPackageList().subscribe(res=>{
    console.log(res);
      this.packageListResponse= res as packageListResponse;
      this.packageData=this.packageListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletepackage(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeletePackage(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showPackage();
      },err=>{
        console.log(err);
      });
    }
  }
}