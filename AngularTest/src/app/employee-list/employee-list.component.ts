import { Component, OnInit } from '@angular/core';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  public employees = [];
  constructor(private _employeeService: EmployeeServiceService) { }

  ngOnInit(): void {
    this.employees = this._employeeService.getEmployee();
  }

}
