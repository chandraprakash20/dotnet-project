import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';;
import { restapi } from '../services/RestApiService'; 
import { Utils } from '../services/utils.service'; 
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class HeaderComponent {
  
  isLoggedIn=false;
  user_type:string|undefined;
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private Router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.user_type=sessionStorage.getItem("userType")?.toString();
    if(sessionStorage.getItem("isLoggedIn")=="true"){
      this.isLoggedIn=true;
    }
    
  }
  logout(){
    sessionStorage.clear();

    this.Router.navigate(['/user']).then(()=>{
      window.location.reload();
    });
  }
}
