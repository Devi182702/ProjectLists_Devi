import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
/**import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component'; */
import { VisaDetailComponent } from './visa-detail/visa-detail.component';
import { AddVisaComponent } from './add-visa/add-visa.component';
import { GetVisaDetailComponent } from './get-visa-detail/get-visa-detail.component';
import { ParcelService } from './services/parcel.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    /**CounterComponent,
    FetchDataComponent,*/
    VisaDetailComponent,
    AddVisaComponent,
    GetVisaDetailComponent
  ],
  imports: [    
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),    
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'visa-detail', component: VisaDetailComponent },
      { path: 'add-visa/:id', component: AddVisaComponent },
      //{ path: 'get-visa-detail/:id', component: GetVisaDetailComponent },
      { path: 'get-visa-detail/:id', component: GetVisaDetailComponent },  
    ])
  ],
  providers: [ParcelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
