import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public employees =
    [
      { "id": 1, "age": 23, "name": "Patrick Mboma" },
      { "id": 2, "age": 23, "name": "Hezekiah Ngong" },
      { "id": 3, "age": 23, "name": "Timothy Mbam" },
      { "id": 4, "age": 23, "name": "David Yusinyu" },
      { "id": 5, "age": 23, "name": "Evaristus Namdi" },
      { "id": 6, "age": 23, "name": "Titus Nicodemus" },
    ];
} 
