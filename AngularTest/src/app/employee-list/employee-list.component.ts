import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  public employees =
  [
      { "id": 1, "age": 23, "name": "Patrick Mboma"},
      { "id": 2, "age": 23, "name": "Hezekiah Ngong"},
      { "id": 3, "age": 23, "name": "Timothy Mbam"},
      { "id": 4, "age": 23, "name": "David Yusinyu"},
      { "id": 5, "age": 23, "name": "Evaristus Namdi"},
      { "id": 6, "age": 23, "name": "Titus Nicodemus" },
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
