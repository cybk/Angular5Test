import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/throw';

@Injectable()
export class EmployeeService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getCityList() {
        return this._http.get(this.myAppUrl + 'api/Employee/GetCityList')
            .map(res => res.json())
            .catch(this.errorHandler);
    }

    getEmployees() {
        return this._http.get(this.myAppUrl + 'api/Employee/Index')
            .map(res => res.json())
            .catch(this.errorHandler);
    }

    getEmployeeById(id: number) {
        return this._http.get(this.myAppUrl + 'api/Employee/Details/' + id)
            .map(res => res.json())
            .catch(this.errorHandler);
    }

    saveEmployee(employee: any) {
        return this._http.post(this.myAppUrl + 'api/Employee/Create', employee)
            .map(res => res.json())
            .catch(this.errorHandler);
    }

    updateEmployee(employee: any) {
        return this._http.put(this.myAppUrl + 'api/Employee/Edit', employee)
            .map(res => res.json)
            .catch(this.errorHandler);
    }

    deleteEmployee(id: number) {
        return this._http.delete(this.myAppUrl + 'api/Employee/Delete/' + id)
            .map(res => res.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}