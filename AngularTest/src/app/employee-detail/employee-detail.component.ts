import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  public errorMsg;
  public employeeId;
  constructor(public route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    let id = parseInt(this.route.snapshot.paramMap.get('id'));
    this.employeeId = id;
  }

  goPrevious() {
    let previousId = this.employeeId - 1;
    this.router.navigate(['/employee-details', previousId]);
  }

  goNext() {

    let nextID = this.employeeId + 1;
    this.router.navigate(['/employee-details', nextID]);
  }
}
