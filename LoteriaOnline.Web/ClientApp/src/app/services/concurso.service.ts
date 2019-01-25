import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class ConcursoService {
  baseUrl: string = "https://localhost:44314/";

  constructor(private _http: Http) {
  }

  getListar() {
    return this._http.get(this.baseUrl + 'api/Concurso/Listar')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getRecuperarPorId(id: number) {
    return this._http.get(this.baseUrl + "api/Concurso/RecuperarPorId/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  Salvar(concurso) {
    return this._http.post(this.baseUrl + 'api/Concurso/Salvar', concurso)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  Finalizar(concurso) {
    return this._http.post(this.baseUrl + 'api/Concurso/FinalizarConcurso', concurso)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  Excluir(concursoId: number) {
    return this._http.delete(this.baseUrl + "api/Concurso/Excluir/" + concursoId)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}  
