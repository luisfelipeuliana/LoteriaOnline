using LoteriaOnline.ApplicationCore.Interface.Repository;
using LoteriaOnline.ApplicationCore.Interface.Service;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.ApplicationCore.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Service
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public Jogo Cadastrar(Jogo jogo)
        {
            var jogoOriginal = _jogoRepository.RecuperarPorId(jogo.JogoId);
            if (jogoOriginal == null)
            {                
                _jogoRepository.Inserir(jogo);
                return jogo;
            }
            jogoOriginal.DataJogo = jogo.DataJogo;
            jogoOriginal.ConcursoId = jogo.ConcursoId;
            jogoOriginal.NumeroJogo = jogo.NumeroJogo;
            jogoOriginal.UsuarioId = jogo.UsuarioId;
            _jogoRepository.Editar(jogoOriginal);
            return jogoOriginal;
        }

        public void Excluir(long jogoId)
        {
            var jogo = _jogoRepository.RecuperarPorId(jogoId);
            _jogoRepository.Excluir(jogo);
        }

        public IEnumerable<int> GerarJogoAleatorio(int quantidadeNumero, int numeroMinimo, int numeroMaximo)
        {
            var random = new Random();
            var retorno = new List<int>();
            for (int i = 0; i < quantidadeNumero; i++)
            {
                var numeroValido = false;
                while (!numeroValido)
                {
                    var numeroAleatorio = random.Next(numeroMinimo, numeroMaximo);
                    if (!retorno.Contains(numeroAleatorio))
                    {
                        retorno.Add(numeroAleatorio);
                        numeroValido = true;
                    }
                }
            }
            return retorno.OrderBy(x => x).ToList();
        }

        public List<int> RecuperaNumeroJogo(long jogoId)
        {
            return RecuperarListaNumeroJogo(_jogoRepository.RecuperarPorId(jogoId).NumeroJogo);           
        }

        public List<int> RecuperarListaNumeroJogo(string numeroJogo)
        {
            var retorno = new List<int>();
            foreach (var numero in numeroJogo.Split('-'))
            {
                retorno.Add(int.Parse(numero));
            }
            return retorno;
        }

        public Jogo RecuperarPorId(long jogoId)
        {
            return _jogoRepository.RecuperarPorId(jogoId);
        }

        public IEnumerable<Jogo> RecuperaTodos()
        {
            return _jogoRepository.RecuperaTodos();
        }

        public IEnumerable<Jogo> RecuperarJogosGanhadores(long concursoId)
        {
            return _jogoRepository.RecuperaJogosGanhadores(concursoId);
        }

        public void AtualizarPremiu(long jogoId, int acertos)
        {
            var jogo = _jogoRepository.RecuperarPorId(jogoId);
            switch (acertos)
            {
                case (6) :
                    jogo.Premiu = PremiuEnum.Sena;
                    break;
                case (5) :
                    jogo.Premiu = PremiuEnum.Quina;
                    break;
                case (4):
                    jogo.Premiu = PremiuEnum.Quadra;
                    break;
                default:
                    jogo.Premiu = PremiuEnum.NaoPremiado;
                    break;
            }
            _jogoRepository.Editar(jogo);
        }
    }
}
