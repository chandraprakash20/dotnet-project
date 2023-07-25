import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class Utils {

  public readonly baseUrl:string = "http://localhost:5090/";
  //loadAPI!: Promise<any>;

  public loadFormScript() {
      var isFound = false;
      var scripts = document.getElementsByTagName("script")
      for (var i = 0; i < scripts.length; ++i) {
        if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
          isFound = true;
        }
      }

      if (!isFound) {
        var dynamicScripts = [
          "./assets/js/scripts.js",
          "./assets/js/custom.js"
        ];

        for (var i = 0; i < dynamicScripts.length; i++) {
          let node = document.createElement('script');
          node.src = dynamicScripts[i];
          node.async = false;
          document.getElementsByTagName('body')[0].appendChild(node);
        }

      }
  }


  public loadIndexScript() {

    var isFound = false;
    var scripts = document.getElementsByTagName("script")
    for (var i = 0; i < scripts.length; ++i) {
      if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
        isFound = true;
      }
    }

    if (!isFound) {
      var dynamicScripts = [
        "./assets/bundles/echart/echarts.js",
        "./assets/bundles/chartjs/chart.min.js",
        "./assets/js/page/index.js",
        "./assets/js/scripts.js",
        "./assets/js/custom.js"
      ];

      for (var i = 0; i < dynamicScripts.length; i++) {
        let node = document.createElement('script');
        node.src = dynamicScripts[i];
        node.async = false;
        node.innerHTML = '';
        node.defer = true;
        document.getElementsByTagName('body')[0].appendChild(node);
      }

    }

  }



  public loadTablesScript() {
      var isFound = false;
      var scripts = document.getElementsByTagName("script")
      for (var i = 0; i < scripts.length; ++i) {
        if (scripts[i].getAttribute('src') != null && scripts[i].getAttribute('src')!.includes("loader")) {
          isFound = true;
        }
      }

      if (!isFound) {
        var dynamicScripts = ["assets/bundles/jquery-ui/jquery-ui.min.js",
          "assets/js/page/advance-table.js",
  "assets/js/scripts.js",
  "assets/js/custom.js"
        ];

        for (var i = 0; i < dynamicScripts.length; i++) {
          let node = document.createElement('script');
          node.src = dynamicScripts[i];
          node.async = false;
          node.innerHTML = '';
          node.defer = true;
          document.getElementsByTagName('body')[0].appendChild(node);
        }

      }
  }

}
