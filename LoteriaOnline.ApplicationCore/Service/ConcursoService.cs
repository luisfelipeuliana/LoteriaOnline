using LoteriaOnline.ApplicationCore.Interface.Repository;
using LoteriaOnline.ApplicationCore.Interface.Service;
using LoteriaOnline.ApplicationCore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Service
{
    public class ConcursoService : IConcursoService
    {
        private readonly IConcursoRepository _concursoRepository;
        private readonly IJogoRepository _jogoRepository;
        private readonly IJogoService _jogoService;

        public ConcursoService(IConcursoRepository concursoRepository, IJogoRepository jogoRepository, IJogoService jogoService)
        {
            _concursoRepository = concursoRepository;
            _jogoService = jogoService;
            _jogoRepository = jogoRepository;
        }

        public Concurso Cadastrar(Concurso concurso)
        {
            var concursoOriginal = _concursoRepository.RecuperarPorId(concurso.ConcursoId);
            if (concursoOriginal == null)
            {
                _concursoRepository.Inserir(concurso);
                return concurso;
            }
            concursoOriginal.DataCriacao = concurso.DataCriacao;
            concursoOriginal.DataSorteio = concurso.DataSorteio;
            concursoOriginal.TipoConcurso = concurso.TipoConcurso;
            _concursoRepository.Editar(concursoOriginal);
            return concursoOriginal;
        }

        public void Excluir(long concursoId)
        {
            var concurso = _concursoRepository.RecuperarPorId(concursoId);
            _concursoRepository.Excluir(concurso);
        }

        public Concurso RecuperarPorId(long concursoId)
        {
            return _concursoRepository.RecuperarPorId(concursoId);
        }

        public IEnumerable<Concurso> RecuperaTodos()
        {
            return _concursoRepository.RecuperaTodos();
        }

        public Concurso FinalizarConcurso(long concursoId, string numeroSorteado)
        {
            var listaNumerosSortiado = _jogoService.RecuperarListaNumeroJogo(numeroSorteado);
            var jogos = _jogoRepository.RecuperaPorConcurso(concursoId);
            var acumulou = true;
            foreach (var jogo in jogos)
            {
                int acertos = 0;
                var listaNumeroJogo = _jogoService.RecuperarListaNumeroJogo(jogo.NumeroJogo);
                listaNumeroJogo.ForEach(x =>
                {
                    if (listaNumerosSortiado.Contains(x))
                        acertos++;
                });
                _jogoService.AtualizarPremiu(jogo.JogoId, acertos);
                if (acertos == 6)
                    acumulou = false;
            }
            var concurso = _concursoRepository.RecuperarPorId(concursoId);
            concurso.Acumulou = acumulou;
            concurso.NumeroSorteado = numeroSorteado;
            _concursoRepository.Editar(concurso);
            return concurso;
        }
    }
}
