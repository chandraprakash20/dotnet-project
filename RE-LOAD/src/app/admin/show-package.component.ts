import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
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
  constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.baseUrl = this.utils.baseUrl;
    this.showPackage();
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