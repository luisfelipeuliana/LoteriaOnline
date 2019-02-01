"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Observable_1 = require("rxjs/Observable");
var http_1 = require("@angular/common/http");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var Subject_1 = require("rxjs/Subject");
var httpOptions = {
    headers: new http_1.HttpHeaders({
        "Authorization": localStorage.getItem("jwt"),
        "Content-Type": "application/json"
    })
};
var LoginService = /** @class */ (function () {
    function LoginService(_http) {
        this._http = _http;
        this.logado = new Subject_1.Subject();
        this.baseUrl = "https://localhost:44314/";
    }
    LoginService.prototype.login = function (usuario) {
        var _this = this;
        return this._http.post(this.baseUrl + 'api/login/', JSON.stringify(usuario), httpOptions)
            .map(function (response) {
            _this.logado.next(true);
            return response;
        })
            .catch(this.errorHandler);
    };
    LoginService.prototype.sair = function () {
        this.logado.next(false);
        localStorage.removeItem("jwt");
    };
    LoginService.prototype.errorHandler = function (error) {
        console.log(error);
        this.logado.next(false);
        return Observable_1.Observable.throw(error);
    };
    return LoginService;
}());
exports.LoginService = LoginService;
//# sourceMappingURL=login.service.js.map