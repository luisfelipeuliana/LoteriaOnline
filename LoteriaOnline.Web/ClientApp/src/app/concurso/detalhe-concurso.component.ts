import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ConcursoService } from '../services/concurso.service';
import { JogoService } from '../services/jogo.service';

@Component({
  templateUrl: './detalhe-concurso.componet.html',
  selector: "app-detalhe-concurso.component"
})

export class DetalheConcursoConponent implements OnInit {
  concurso: concursoData;
  jogos: jogoData[];
  concursoId: number;
  errorMessage: any;

  constructor(private _avRoute: ActivatedRoute, private _concursoService: ConcursoService,
    private _jogoService: JogoService, private _router: Router) {
    this.concursoId = this._avRoute.snapshot.params["id"];
  }

  ngOnInit() {
    this.getConcurso();
    this.getJogosGanhadores();
  }

  getConcurso() {
    this._concursoService.getRecuperarPorId(this.concursoId)
      .subscribe(resp => this.concurso = resp
        , error => this.errorMessage = error);
  }

  getJogosGanhadores() {
    this._jogoService.getJogosGanhadores(this.concursoId)
      .subscribe(resp => this.jogos = resp
        , error => this.errorMessage = error);
  }

  voltar() {
    this._router.navigate(['/concursos']);
  }

}

interface concursoData {
  concursoId: number;
  dataCriacao: Date;
  dataSorteio: Date;
  numeroSorteado: string;
  acumulou: boolean;
  nomeTipoConcurso: string;
}

interface jogoData {
  jogoId: number;
  numeroJogo: string;
  usuarioId: number;
  concursoId: number;
  dataJogo: Date;
  descricaoPremiu: string;
}
