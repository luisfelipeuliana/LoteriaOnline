"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var ConcursoService = /** @class */ (function () {
    function ConcursoService(_http) {
        this._http = _http;
        this.baseUrl = "https://localhost:44314/";
    }
    ConcursoService.prototype.getListar = function () {
        return this._http.get(this.baseUrl + 'api/Concurso/Listar')
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    ConcursoService.prototype.getRecuperarPorId = function (id) {
        return this._http.get(this.baseUrl + "api/Concurso/RecuperarPorId/" + id)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    ConcursoService.prototype.Salvar = function (concurso) {
        return this._http.post(this.baseUrl + 'api/Concurso/Salvar', concurso)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    ConcursoService.prototype.Finalizar = function (concurso) {
        return this._http.post(this.baseUrl + 'api/Concurso/FinalizarConcurso', concurso)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    ConcursoService.prototype.Excluir = function (concursoId) {
        return this._http.delete(this.baseUrl + "api/Concurso/Excluir/" + concursoId)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    ConcursoService.prototype.errorHandler = function (error) {
        console.log(error);
        return Observable_1.Observable.throw(error);
    };
    return ConcursoService;
}());
exports.ConcursoService = ConcursoService;
//# sourceMappingURL=concurso.service.js.map