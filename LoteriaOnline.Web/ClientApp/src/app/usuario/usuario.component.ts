import { Component} from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { UsuarioService } from '../services/usuario.service'

@Component({
  templateUrl: './usuario.component.html',
  selector: "app-usuario.component"
})

export class UsuarioComponent {
  public usuarios: UsuarioData[];

  constructor(public http: Http, private _router: Router, private _usuarioService: UsuarioService) {
    this.getUsuarios();    
  }

  getUsuarios() {
    this._usuarioService.getListar().subscribe(
      data => this.usuarios = data
    )
  }

  excluir(usuarioId) {
    var ans = confirm("Deseja realmente excluir o usuário: " + usuarioId);
    if (ans) {
      this._usuarioService.Excluir(usuarioId).subscribe((data) => {
        this.getUsuarios();
      }, error => console.error(error))
    }
  }
}

interface UsuarioData {
  usuarioId: number;
  nome: string;
  dataNascimento: Date;
  cpf: string;
  email: string;

} 
