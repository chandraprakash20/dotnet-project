import { Component, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from './../services/RestApiService';
import { galleryData } from '../model/galleryData';
import { commonResponse } from '../model/commonResponse';
import { galleryListResponse } from '../model/galleryListResponse'; 

@Component({
  selector: 'app-show-gallery',
  templateUrl: './show-gallery.component.html',
  encapsulation:ViewEncapsulation.None,

})
export class ShowGalleryComponent {
  galleryData: galleryData[] | undefined;
  galleryListResponse:galleryListResponse | undefined;
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
    this.showGallery();
  }
  showGallery()
  {
    this.service.getGalleryList().subscribe(res=>{
    console.log(res);
      this.galleryListResponse= res as galleryListResponse;
      this.galleryData=this.galleryListResponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletegallery(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteGallery(id).subscribe(res=>{
        console.log(res);
        this.commonResponse= res as commonResponse;
        this.showGallery();
      },err=>{
        console.log(err);
      });
    }
  }
}