import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class UsuarioService {
  baseUrl: string = "https://localhost:44314/";

  constructor(private _http: Http) {
  }

  getListar() {
    let token = localStorage.getItem("jwt");
    return this._http.get(this.baseUrl + 'api/Usuario/Listar')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getRecuperarPorId(id: number) {
    return this._http.get(this.baseUrl + "api/Usuario/Detalhes/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  Salvar(usuario) {
    return this._http.post(this.baseUrl + 'api/Usuario/Salvar', usuario)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  Excluir(usuarioId: number) {
    return this._http.delete(this.baseUrl + "api/Usuario/Excluir/" + usuarioId)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}  
