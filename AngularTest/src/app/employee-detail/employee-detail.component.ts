import { Component, OnInit } from '@angular/core';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  public employees = [];
  constructor(private _employeeService: EmployeeServiceService) { }

  ngOnInit(): void {
    this.employees = this._employeeService.getEmployee();
  }
} 
