import { Component} from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ConcursoService } from '../services/concurso.service'

@Component({
  templateUrl: './concurso.component.html',
  selector: "app-concurso.component"
})

export class ConcursoComponent {
  public concursos: concursoData[];

  constructor(public http: Http, private _router: Router, private _concursoService: ConcursoService) {
    this.getConcursos();
  }

  getConcursos() {
    this._concursoService.getListar().subscribe(
      data => this.concursos = data
    )
  }

  excluir(concursoId) {
    var ans = confirm("Deseja realmente excluir esse concurso: " + concursoId);
    if (ans) {
      this._concursoService.Excluir(concursoId).subscribe((data) => {
        this.getConcursos();
      }, error => console.error(error))
    }
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
