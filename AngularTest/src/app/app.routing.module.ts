import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EmployeeDetailComponent } from "./employee-detail/employee-detail.component";
import { EmployeeListComponent } from "./employee-list/employee-list.component";
import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";


const routes: Routes = [
  //{ path: '', component: EmployeeListComponent },
  { path: '', redirectTo: "/employees", pathMatch: 'full' },
  { path: 'employees', component: EmployeeListComponent },
  { path: 'employee-detail/:id', component: EmployeeDetailComponent },
  { path: '**', component: PageNotFoundComponent }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponents = [EmployeeDetailComponent, EmployeeListComponent, PageNotFoundComponent]
