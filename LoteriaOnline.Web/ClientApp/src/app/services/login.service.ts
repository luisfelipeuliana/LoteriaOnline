import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw'
import { EventEmitter } from 'protractor';
import { Subject } from 'rxjs/Subject';
import { read } from 'fs';

const httpOptions = {
  headers: new HttpHeaders({
    "Authorization": "Bearer " + localStorage.getItem("jwt"),
    "Content-Type": "application/json"
  })
};

@Injectable()
export class LoginService {
  public logado = new Subject();
  baseUrl: string = "https://localhost:44314/";

  constructor(private _http: HttpClient) {
  }

  login(usuario) {
    return this._http.post(this.baseUrl + 'api/login/', JSON.stringify(usuario), httpOptions)
      .map((response: Response) => {
        this.logado.next(true);
        return response;
      })
      .catch(this.errorHandler)
  }

  sair() {
    this.logado.next(false);
    localStorage.removeItem("jwt");
  }

  errorHandler(error: Response) {
    console.log(error);
    this.logado.next(false);
    return Observable.throw(error);
  }
}  
