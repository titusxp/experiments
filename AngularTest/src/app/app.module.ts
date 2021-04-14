import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { EmployeeServiceService } from './employee-service.service';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app.routing.module';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    EmployeeDetailComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [EmployeeServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
export const routingComponents = [EmployeeDetailComponent, EmployeeListComponent]
