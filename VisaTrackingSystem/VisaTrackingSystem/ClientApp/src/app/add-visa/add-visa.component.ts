import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VisaDetails } from '../visa-detail/visa-detail.model';
import { NgForm } from '@angular/forms';
import { ActivatedRoute,Router, Params } from '@angular/router';
import { error } from 'protractor';


@Component({  
  templateUrl: './add-visa.component.html'
})

export class AddVisaComponent implements OnInit {
  formData: VisaDetails;
  public httpClient: HttpClient;
  public baseUrl: string;
   /**start - this is new code */
  public countryName: string;
   /**End - this is new code */

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private _route: ActivatedRoute, private _router: Router) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.resetFormData();
  }
  resetFormData() {
    this.formData = {
      VisaRequsitionId: 0,
      EmployeeId: null,
      CountryName: '',
      VisaIssueDate: null,
      VisaExpiryDate: null,
      VisaStatus: ''
    }
  }

  ngOnInit() {   
    if (this._route.snapshot.params['id']) {
      this.formData.VisaRequsitionId = this._route.snapshot.params['id'];
      /**start - this is new code */
      if (this.formData.VisaRequsitionId > 0) {       
        this.httpClient.get<VisaDetails>(this.baseUrl + 'api/VisaDetails/Get/' + this.formData.VisaRequsitionId)
          .subscribe(result => {
            this.formData = result;
          }, error => console.error(error));
      }
      /**End - this is new code */
      else {
        this.resetFormData();
      }
    }
  }

  cancel() {
    this._router.navigate(['visa-detail']);
  }
  onSave(form: NgForm) {   
      /**start - this is new code */
    if (this.formData.VisaRequsitionId > 0) {
      this.httpClient.put(this.baseUrl + 'api/VisaDetails/Update/', this.formData).subscribe(
        result => {
          alert("Visa Details Updated Successfully");
          this._router.navigate(['visa-detail']);
        },
        error => console.error(error));
    }
    else {
        /**End - this is new code */
      this.httpClient.post(this.baseUrl + "api/VisaDetails/Create", this.formData).subscribe(
        result => {
          alert("Visa Record Created Successfully");
          this._router.navigate(['visa-detail']);
        },
        error => console.error(error));
       /**start - this is new code */
    }
     /**End - this is new code */
  }
}
