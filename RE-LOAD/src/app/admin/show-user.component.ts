import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { userData } from '../model/userData'; 
import { commonResponse } from '../model/commonResponse';
import { userListResponse } from '../model/userListResponse'; 

@Component({
  selector: 'app-show-user',
  templateUrl: './show-user.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowUserComponent {
  userData: userData[] | undefined;
  userListResponse:userListResponse | undefined;
  commonResponse:commonResponse | undefined;

  constructor(private utils:Utils,public service:restapi){
    new Promise((resolve) => {
      utils.loadTablesScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    this.showUser();
  }
  showUser()
  {
    this.service.getUserList().subscribe(res=>{
    console.log(res);
      this.userListResponse= res as userListResponse;
      this.userData=this.userListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deleteuser(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      console.log(id);
      this.service.DeleteUser(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showUser();
      },err=>{
        console.log(err);
      });
    }
  }
}