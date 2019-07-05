import { Injectable } from '@angular/core'
import { VisaDetails } from '../visa-detail/visa-detail.model';

@Injectable()
export class ParcelService {

  public visaDetail: VisaDetails

  public getVisaDetail(): VisaDetails {
    return this.visaDetail;
  }

  public setVisaDetail(obj: VisaDetails) {
    this.visaDetail = obj;
  }
}
