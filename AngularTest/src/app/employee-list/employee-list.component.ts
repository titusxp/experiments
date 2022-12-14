import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  public employees = [];
  public errorMsg;
  constructor(private _employeeService: EmployeeServiceService, private router: Router) { }

  ngOnInit(): void {
    this._employeeService.getEmployee().subscribe(data => this.employees = data,
                                                 error => this. errorMsg = error);
  }       
  onSelect(employee) {
    this.router.navigate(['/employee-detail', employee.id]);
  }
}
