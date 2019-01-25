import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UsuarioService } from '../services/usuario.service';

@Component({
  templateUrl: './cadastro-usuario.componet.html',
  selector: "app-cadastro-usuario.component"
})

export class CadastroUsuarioConponent implements OnInit {
  usuarioForm: FormGroup;
  title: string = "Adicionar usuário";
  usuarioId: number;
  errorMessage: any;
  cityList: Array<any> = [];

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _usuarioService: UsuarioService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.usuarioId = this._avRoute.snapshot.params["id"];
    }

    this.usuarioForm = this._fb.group({
      usuarioId: 0,
      nome: ['', [Validators.required]],
      dataNascimento: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      email: ['', [Validators.required]],
      login: ['', [Validators.required]],
      senha: ['', [Validators.required]],
    })
  }

  ngOnInit() {
    if (this.usuarioId > 0) {
      this.title = "Editar usuário";
      this._usuarioService.getRecuperarPorId(this.usuarioId)
        .subscribe(resp => this.usuarioForm.setValue(resp)
          , error => this.errorMessage = error);
    }
  }

  salvar() {

    if (!this.usuarioForm.valid) {
      return;
    }

    this._usuarioService.Salvar(this.usuarioForm.value)
      .subscribe((data) => {
        this._router.navigate(['/usuarios']);
      }, error => this.errorMessage = error)
  }

  cancelar() {
    this._router.navigate(['/usuarios']);
  }

  get nome() { return this.usuarioForm.get('nome'); }
  get dataNascimento() { return this.usuarioForm.get('dataNascimento'); }
  get cpf() { return this.usuarioForm.get('cpf'); }
  get email() { return this.usuarioForm.get('email'); }
  get login() { return this.usuarioForm.get('login'); }
  get senha() { return this.usuarioForm.get('senha'); }
}  
