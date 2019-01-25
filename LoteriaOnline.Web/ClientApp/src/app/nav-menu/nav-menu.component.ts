import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';

import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  logado: any;
  constructor(private jwtHelper: JwtHelper, private _loginService: LoginService, private _router: Router) {
  }

  ngOnInit() {
    this._loginService.logado.subscribe(x => this.logado = x);
  }

  public isTokenExpired() {
    if (localStorage.getItem("jwt")) {
      return this.jwtHelper.isTokenExpired(localStorage.getItem("jwt"));
    }
    return true;
  }

  atualizarMenu() {
    if (!this.isTokenExpired)
      this.logado = true;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  sair() {
    this._loginService.sair();
    this._router.navigate(['/login']);
  }
}
