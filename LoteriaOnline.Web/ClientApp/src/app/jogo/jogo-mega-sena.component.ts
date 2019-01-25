import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute, Data } from '@angular/router';
import { JogoService } from '../services/jogo.service';

@Component({
  templateUrl: './jogo-mega-sena.component.html',
  selector: "app-jogo-mega-sena",
  styleUrls: ['./jogo-mega-sena.component.css']
})

export class JogoMegaSenaConponent implements OnInit {
  jogoId: number = 0;
  concursoId: number = 1;
  usuarioId: number = 1;
  habilidarBotaoSalvar = false;
  errorMessage: any;
  numerosMegaSena: Array<NumeroSelecionadoData>;
  numerosSelecionados: Array<number> = [];
  jogos: Array<JogoData> = [];

  constructor(public http: Http, private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _jogoService: JogoService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.jogoId = this._avRoute.snapshot.params["id"];
    }
  }

  ngOnInit() {
    this.limpar();
    this.getNumerosMegaSena();
    this.getJogos();
  }

  getJogos() {
    this._jogoService.getListar().subscribe(
      data => this.jogos = data
    )
  }

  getNumerosMegaSena() {
    this.numerosMegaSena = [];
    for (let i = 1; i <= 60; i++) {
      let numero: NumeroSelecionadoData = { numero: i, selecionado: this.numerosSelecionados.includes(i) }
      this.numerosMegaSena.push(numero);
    }
    this.habilidarBotaoSalvar = this.numerosSelecionados.length == 6;
  }

  getJogo(id) {
    this.jogoId = id;
    this._jogoService.getRecuperaNumeroJogo(id)
      .subscribe((resp) => {
        this.numerosSelecionados = resp;        
        this.getNumerosMegaSena();
      });
  }

  atualizarNumerosSelecionados(numero) {
    if (this.numerosSelecionados.includes(numero)) {
      const index = this.numerosSelecionados.indexOf(numero, 0);
      if (index > -1) {
        this.numerosSelecionados.splice(index, 1);
      }
    }
    else if (this.numerosSelecionados.length < 6) {
      this.numerosSelecionados.push(numero);
    }
    this.getNumerosMegaSena();
  }

  gerarJogoAleatorio() {
    this._jogoService.getGerarJogoAleatorio(6)
      .subscribe((resp) => {
        this.numerosSelecionados = resp;
        this.getNumerosMegaSena();
      });
  }

  excluir(jogoId) {
    var ans = confirm("Deseja realmente excluir esse jogo: " + jogoId);
    if (ans) {
      this._jogoService.Excluir(jogoId).subscribe((data) => {
        this.getJogos();
      }, error => console.error(error))
    }
  }

  limpar() {
    this.numerosSelecionados = new Array<number>();
    this.jogoId = 0;
    this.getNumerosMegaSena();
  }

  salvar() {
    let jogo: JogoData = { jogoId: this.jogoId, numeroJogo: this.numerosSelecionados.join('-'), usuarioId: this.usuarioId, concursoId: this.usuarioId, dataJogo: new Date() };
    this._jogoService.Salvar(jogo)
      .subscribe((data) => {
        this.ngOnInit();
      }, error => this.errorMessage = error);
  }

}

interface NumeroSelecionadoData {
  numero: number;
  selecionado: boolean;
}

interface JogoData {
  jogoId: number;
  numeroJogo: string;
  usuarioId: number;
  concursoId: number;
  dataJogo: Date;
}

