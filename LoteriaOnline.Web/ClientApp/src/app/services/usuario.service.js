"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var UsuarioService = /** @class */ (function () {
    function UsuarioService(_http) {
        this._http = _http;
        this.baseUrl = "https://localhost:44314/";
    }
    UsuarioService.prototype.getListar = function () {
        return this._http.get(this.baseUrl + 'api/Usuario/Listar')
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    UsuarioService.prototype.getRecuperarPorId = function (id) {
        return this._http.get(this.baseUrl + "api/Usuario/Detalhes/" + id)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    UsuarioService.prototype.Salvar = function (usuario) {
        return this._http.post(this.baseUrl + 'api/Usuario/Salvar', usuario)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    UsuarioService.prototype.Excluir = function (usuarioId) {
        return this._http.delete(this.baseUrl + "api/Usuario/Excluir/" + usuarioId)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    UsuarioService.prototype.errorHandler = function (error) {
        console.log(error);
        return Observable_1.Observable.throw(error);
    };
    return UsuarioService;
}());
exports.UsuarioService = UsuarioService;
//# sourceMappingURL=usuario.service.js.map