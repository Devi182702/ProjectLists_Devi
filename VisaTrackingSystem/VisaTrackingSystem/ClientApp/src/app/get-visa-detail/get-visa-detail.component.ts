import { Component, Inject, Output, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { VisaDetails } from '../visa-detail/visa-detail.model';
import { ParcelService } from '../services/parcel.service';

@Component({  
  templateUrl: './get-visa-detail.component.html'
})
export class GetVisaDetailComponent{
  public visaDetails: VisaDetails;
  public httpClient: HttpClient;
  public baseUrl: string;
  public visaRequistionId: number;
  public postBox: ParcelService;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _route: ActivatedRoute, private _router: Router, private parcelService: ParcelService) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.postBox = parcelService;
  }

  ngOnInit() {
    this.visaDetails = this.postBox.getVisaDetail();
    this.visaRequistionId = this.visaDetails.VisaRequsitionId;
    /*if (this._route.snapshot.params['id']) {
      this.visaRequistionId = this._route.snapshot.params['id'];      
      this.getVisaDetailsById();
    }*/
  }

  cancel() {
    this._router.navigate(['visa-detail']);
  }

  getVisaDetailsById() {
    this.httpClient.get<VisaDetails>(this.baseUrl + 'api/VisaDetails/Get/' + this.visaRequistionId).subscribe(
      result => {
        this.visaDetails = result;
        console.info(this.visaDetails);
    }, error => console.error(error));
  }
}
