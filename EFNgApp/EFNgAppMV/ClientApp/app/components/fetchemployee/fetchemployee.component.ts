import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

import { EmployeeService } from '../../services/empservice.service';
import { EmployeeData } from '../../models/employeedata.model';

@Component({
    templateUrl: './fetchemployee.component.html'
})

export class FetchEmployeeComponent {
    public empList: EmployeeData[];

    constructor(public http: Http, private _router: Router, private _empService: EmployeeService) {
        this.getEmployees();
    }

    getEmployees() {
        this._empService.getEmployees().subscribe(
            data => this.empList = data
        );
    }

    delete(empId: number) {
        this._empService.deleteEmployee(empId).subscribe(data => {
            this.getEmployees();
        }, error => console.error(error));
    }
}
