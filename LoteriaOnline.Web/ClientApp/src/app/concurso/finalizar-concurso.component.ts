import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ConcursoService } from '../services/concurso.service';

@Component({
  templateUrl: './finalizar-concurso.componet.html',
  selector: "app-finalizar-concurso.component",
  styleUrls: ['./finalizar-concurso.componet.css']
})

export class FinalizarConcursoConponent implements OnInit {
  concursoId: number;
  habilidarBotaoFinalizar : boolean;
  errorMessage: any;
  numerosMegaSena: Array<numeroSelecionadoData>;
  numerosSelecionados: Array<number> = [];

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _concursoService: ConcursoService, private _router: Router) {
      this.concursoId = this._avRoute.snapshot.params["id"];
    }

  ngOnInit() {
    this.getNumerosMegaSena();
  }

  getNumerosMegaSena() {
    this.numerosMegaSena = [];
    for (let i = 1; i <= 60; i++) {
      let numero: numeroSelecionadoData = { numero: i, selecionado: this.numerosSelecionados.includes(i) }
      this.numerosMegaSena.push(numero);
    }
    this.habilidarBotaoFinalizar = this.numerosSelecionados.length == 6;
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

  finalizar() {
    let concurso: concursoData = { concursoId: this.concursoId, numeroSorteado: this.numerosSelecionados.join('-') };
    this._concursoService.Finalizar(concurso)
      .subscribe((data) => {
        this._router.navigate(['/concurso/detalhe/' + this.concursoId]);
      }, error => this.errorMessage = error);
  }

  limpar() {
    this.numerosSelecionados = new Array<number>();
    this.getNumerosMegaSena();
  }

  voltar() {
    this._router.navigate(['/concursos']);
  }
}

interface concursoData {
  numeroSorteado: string;
  concursoId: number;
}

interface numeroSelecionadoData {
  numero: number;
  selecionado: boolean;
}
