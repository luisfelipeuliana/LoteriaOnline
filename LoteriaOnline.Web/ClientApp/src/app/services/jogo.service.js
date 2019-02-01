"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var JogoService = /** @class */ (function () {
    function JogoService(_http) {
        this._http = _http;
        this.baseUrl = "https://localhost:44314/";
    }
    JogoService.prototype.getListar = function () {
        return this._http.get(this.baseUrl + 'api/Jogo/Listar')
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    JogoService.prototype.getJogosGanhadores = function (concursoId) {
        return this._http.get(this.baseUrl + 'api/Jogo/JogosGanhadores/' + concursoId)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    JogoService.prototype.getGerarJogoAleatorio = function (quantidadeNumeros) {
        return this._http.get(this.baseUrl + 'api/Jogo/GerarJogoAleatorio/' + quantidadeNumeros)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    JogoService.prototype.getRecuperarPorId = function (id) {
        return this._http.get(this.baseUrl + "api/Jogo/Detalhes/" + id)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    JogoService.prototype.getRecuperaNumeroJogo = function (id) {
        return this._http.get(this.baseUrl + "api/Jogo/RecuperaNumeroJogo/" + id)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    JogoService.prototype.Salvar = function (jogo) {
        return this._http.post(this.baseUrl + 'api/Jogo/Salvar', jogo)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    JogoService.prototype.Excluir = function (jogoId) {
        return this._http.delete(this.baseUrl + "api/Jogo/Excluir/" + jogoId)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    JogoService.prototype.errorHandler = function (error) {
        console.log(error);
        return Observable_1.Observable.throw(error);
    };
    return JogoService;
}());
exports.JogoService = JogoService;
//# sourceMappingURL=jogo.service.js.map