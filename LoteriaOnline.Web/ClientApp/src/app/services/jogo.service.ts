import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class JogoService {
  baseUrl: string = "https://localhost:44314/";

  constructor(private _http: Http) {
  }  
  getListar() {
    return this._http.get(this.baseUrl + 'api/Jogo/Listar')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getJogosGanhadores(concursoId: number) {
    return this._http.get(this.baseUrl + 'api/Jogo/JogosGanhadores/' + concursoId)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getGerarJogoAleatorio(quantidadeNumeros: number) {
    return this._http.get(this.baseUrl + 'api/Jogo/GerarJogoAleatorio/' + quantidadeNumeros)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getRecuperarPorId(id: number) {
    return this._http.get(this.baseUrl + "api/Jogo/Detalhes/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  getRecuperaNumeroJogo(id: number) {
    return this._http.get(this.baseUrl + "api/Jogo/RecuperaNumeroJogo/" + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  Salvar(jogo) {
    return this._http.post(this.baseUrl + 'api/Jogo/Salvar', jogo)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }

  Excluir(jogoId: number) {
    return this._http.delete(this.baseUrl + "api/Jogo/Excluir/" + jogoId)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
}  
