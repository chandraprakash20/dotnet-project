import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  encapsulation:ViewEncapsulation.None,
})
export class AppComponent {
  title = 'RE-LOAD';
  isLoggedIn=false;
  user_type:string|undefined;
  constructor()
  {

  }
  ngOnInit(): void {
    this.user_type=sessionStorage.getItem("userType")?.toString();
    if(sessionStorage.getItem("isLoggedIn")=="true"){
      this.isLoggedIn=true;
    }
    
  }
}
