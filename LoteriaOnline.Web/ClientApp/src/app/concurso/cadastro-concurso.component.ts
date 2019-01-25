import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ConcursoService } from '../services/concurso.service';

@Component({
  templateUrl: './cadastro-concurso.componet.html',
  selector: "app-cadastro-concurso.component"
})

export class CadastroConcursoConponent implements OnInit {
  concursoForm: FormGroup;
  title: string = "Adicionar concurso";
  concursoId: number;
  errorMessage: any;
  cityList: Array<any> = [];

  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _concursoService: ConcursoService, private _router: Router) {
    if (this._avRoute.snapshot.params["id"]) {
      this.concursoId = this._avRoute.snapshot.params["id"];
    }

    this.concursoForm = this._fb.group({
      concursoId: 0,
      tipoConcurso: 1,
      dataCriacao: ['', [Validators.required]],
      dataSorteio: ['', [Validators.required]],
    })
  }

  ngOnInit() {

    if (this.concursoId > 0) {
      this.title = "Editar concurso";
      this._concursoService.getRecuperarPorId(this.concursoId)
        .subscribe(resp => this.concursoForm.setValue(resp)
          , error => this.errorMessage = error);
    }
  }

  salvar() {

    if (!this.concursoForm.valid) {
      return;
    }

    this._concursoService.Salvar(this.concursoForm.value)
      .subscribe((data) => {
        this._router.navigate(['/concursos']);
      }, error => this.errorMessage = error)
  }

  cancelar() {
    this._router.navigate(['/concursos']);
  }

  get dataCriacao() { return this.concursoForm.get('dataCriacao'); }
  get dataSorteio() { return this.concursoForm.get('dataSorteio'); }
}  
