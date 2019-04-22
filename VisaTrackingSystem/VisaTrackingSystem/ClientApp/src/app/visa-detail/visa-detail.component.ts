import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Router,ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-visa-detail',
  templateUrl: './visa-detail.component.html'
})
export class VisaDetailComponent {
  public visadetails: VisaDetails[];
  public httpClient: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _router : Router) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.getVisaDetails();
  }

  getVisaDetails() {
    this.httpClient.get<VisaDetails[]>(this.baseUrl + 'api/VisaDetails/Index').subscribe(result => {
      this.visadetails = result;
    }, error => console.error(error));
  }
  delete(visaRequistionId) {   
    console.info(visaRequistionId);
    console.log(visaRequistionId);
    var confirmMsg = confirm("Do you want to delete the Visa Requsition ID:" + visaRequistionId);
    if (confirmMsg) {
      console.log(visaRequistionId);     
      this.httpClient.delete(this.baseUrl + 'api/VisaDetails/Delete/' + visaRequistionId).subscribe(
        result => {
          alert("Record Deleted Successfully");
          this.getVisaDetails();         
        }
        , error => { alert("Was Not Able to Delete the Record.Please Contact the Help Desk."); console.error(error); })
    }
  }
}

interface VisaDetails {
  VisaRequsitionId: number;
  EmployeeId: number;
  CountryName: string;
  VisaIssueDate: Date;
  VisaExpiryDate: Date;
  VisaStatus: string;
}
