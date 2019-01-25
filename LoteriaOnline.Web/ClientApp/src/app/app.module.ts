import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler  } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common'; 
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http'; 

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { UsuarioComponent } from './usuario/usuario.component'
import { CadastroUsuarioConponent } from './usuario/cadastro-usuario.component'

import { ConcursoComponent } from './concurso/concurso.component'
import { CadastroConcursoConponent } from './concurso/cadastro-concurso.component'
import { DetalheConcursoConponent } from './concurso/detalhe-concurso.component'
import { FinalizarConcursoConponent } from './concurso/finalizar-concurso.component'

import { JogoMegaSenaConponent } from './jogo/jogo-mega-sena.component'

import { LoginConponent } from './login/login.component'

import { UsuarioService } from './services/usuario.service';
import { ConcursoService } from './services/concurso.service';
import { JogoService } from './services/jogo.service';
import { LoginService } from './services/login.service';

import { AuthGuard } from './guards/auth-guard.service';
import { JwtHelper } from 'angular2-jwt';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuarioComponent,
    CadastroUsuarioConponent,
    ConcursoComponent,
    CadastroConcursoConponent,
    JogoMegaSenaConponent,
    DetalheConcursoConponent,
    FinalizarConcursoConponent,
    LoginConponent,
  ],
  imports: [
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'login', component: LoginConponent },
      { path: 'usuarios', component: UsuarioComponent, canActivate: [AuthGuard] },
      { path: 'usuario/adicionar', component: CadastroUsuarioConponent, canActivate: [AuthGuard] },
      { path: 'usuario/editar/:id', component: CadastroUsuarioConponent, canActivate: [AuthGuard] },
      { path: 'concursos', component: ConcursoComponent, canActivate: [AuthGuard] },
      { path: 'concurso/adicionar', component: CadastroConcursoConponent, canActivate: [AuthGuard] },
      { path: 'concurso/editar/:id', component: CadastroConcursoConponent, canActivate: [AuthGuard] },
      { path: 'concurso/detalhe/:id', component: DetalheConcursoConponent, canActivate: [AuthGuard] },
      { path: 'concurso/finalizar/:id', component: FinalizarConcursoConponent, canActivate: [AuthGuard] },
      { path: 'jogos', component: JogoMegaSenaConponent, canActivate: [AuthGuard] },
    ])
  ],
  providers: [
    UsuarioService,
    ConcursoService,
    JogoService,
    LoginService,
    AuthGuard,
    JwtHelper,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
