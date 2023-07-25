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
  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private Router:Router){
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }
  logout(){
    sessionStorage.clear();

    this.Router.navigate(['/login']).then(()=>{
      window.location.reload();
    });
  }
}
