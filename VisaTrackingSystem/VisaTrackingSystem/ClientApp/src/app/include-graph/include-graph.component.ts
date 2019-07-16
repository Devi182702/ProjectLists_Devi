import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VisaDetails } from '../visa-detail/visa-detail.model';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './include-graph.component.html'
})

export class GraphComponent {
  public visadetails: VisaDetails[];
  public httpClient: HttpClient;
  public baseUrl: string;

  constructor(private httpService: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.httpClient = httpService; this.baseUrl = baseUrl; }
  // ADD CHART OPTIONS. 
  pieChartOptions = {
    responsive: true,
    onAnimationComplete: function () {
      this.showTooltip(this.segments, true);
    }
  }

  pieChartOptions2 = {
    responsive: true,
    onAnimationComplete: function () {
      this.showTooltip(this.segments, true);
    }
  }

  pieChartLabels = ['JAN', 'FEB', 'MAR', 'APR', 'MAY'];
  pieChartLabels2 = ['JAN', 'FEB', 'MAR', 'APR', 'MAY'];

  // CHART COLOR.
  pieChartColor: any = [
    {
      backgroundColor: ['rgba(30, 169, 224, 0.8)',
        'rgba(255,165,0,0.9)',
        'rgba(139, 136, 136, 0.9)',
        'rgba(255, 161, 181, 0.9)',
        'rgba(255, 102, 0, 0.9)'
      ]
    }
  ]

  pieChartColor2: any = [
    {
      backgroundColor: ['rgba(30, 169, 224, 0.8)',
        'rgba(255,165,0,0.9)',
        'rgba(139, 136, 136, 0.9)',
        'rgba(255, 161, 181, 0.9)',
        'rgba(255, 102, 0, 0.9)'
      ]
    }
  ]


  pieChartData: any = [
    {
      data: [47, 9, 28, 54, 77] 
    }
  ];

  pieChartData2: any = [
    {
      data: [47, 9, 28, 54, 77]
    }
  ];

  ngOnInit() {
    this.httpClient.get<VisaDetails[]>(this.baseUrl + 'api/VisaDetails/Index').subscribe(result => {
      this.visadetails = result;

      var activeList = this.visadetails.filter(obj => obj.VisaStatus === "Active");
      var activeData = [];
      for (var obj of activeList) {
        var entryFound = false;
        var tempObj = {
          name: obj.CountryName,
          count: 1
        };

        for (var item of activeData) {
          if (item.name === tempObj.name) {
            item.count++;
            entryFound = true;
            break;
          }
        }

        if (!entryFound) {
          activeData.push(tempObj);
        }
      }
      console.log(activeData);
      console.log("***************************");

      var inactiveList = this.visadetails.filter(obj => obj.VisaStatus === "InActive");
      var inactiveData = [];
      for (var obj of inactiveList) {
        var entryFound = false;
        var tempObj = {
          name: obj.CountryName,
          count: 1
        };

        for (var item of inactiveData) {
          if (item.name === tempObj.name) {
            item.count++;
            entryFound = true;
            break;
          }
        }

        if (!entryFound) {
          inactiveData.push(tempObj);
        }
      }
      console.log(inactiveData);

    }, error => console.error(error));
  }

  onChartClick(event) {
    console.log(event);
  }
}
