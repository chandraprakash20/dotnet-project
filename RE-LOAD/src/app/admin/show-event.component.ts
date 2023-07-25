import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { commonResponse } from '../model/commonResponse';
import { eventData } from '../model/eventData';
import { EventListResponse } from '../model/eventListResponse';
@Component({
  selector: 'app-show-event',
  templateUrl: './show-event.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowEventComponent {
  eventData: eventData[] | undefined;
  EventListResponse:EventListResponse | undefined;
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
    this.showevent();
  }
  showevent()
  {
    this.service.getEventList().subscribe(res=>{
    console.log(res);
      this.EventListResponse= res as EventListResponse;
      this.eventData=this.EventListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deleteevent(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteEvent(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showevent();
      },err=>{
        console.log(err);
      });
    }
  
}

}

