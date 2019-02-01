import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  templateUrl: './login.componet.html',
  selector: "app-login"
})

export class LoginConponent {
  loginForm: FormGroup;
  invalidLogin: boolean;
  errorMessage: any;

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _loginService: LoginService, private _router: Router) {

    this.loginForm = this._fb.group({
      login: ['', [Validators.required]],
      senha: ['', [Validators.required]],
    })
  }

  logar() {
    this._loginService.login(this.loginForm.value)
      .subscribe((data) => {
        let token = (<any>data).token;
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this._router.navigate(["/"]);
      }, error => this.errorMessage = error)
  }

  get login() { return this.loginForm.get('login'); }
  get senha() { return this.loginForm.get('senha'); }
}  
