using LoteriaOnline.ApplicationCore.Interface.Repository;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.ApplicationCore.Model.Enum;
using LoteriaOnline.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoteriaOnline.Infrastructure.Repository
{
    public class JogoRepository : IJogoRepository
    {

        public virtual void Editar(Jogo jogo)
        {
            foreach (var item in LoteriaOnlineData.Jogos)
            {
                if(jogo.JogoId == item.JogoId)
                {
                    item.ConcursoId = jogo.ConcursoId;
                    item.DataJogo = jogo.DataJogo;
                    item.NumeroJogo = jogo.NumeroJogo;
                    item.UsuarioId = jogo.UsuarioId;
                    break;
                }
            }
        }

        public virtual void Excluir(Jogo jogo)
        {
            LoteriaOnlineData.Jogos.Remove(jogo);
        }

        public virtual Jogo Inserir(Jogo jogo)
        {
            jogo.JogoId = LoteriaOnlineData.RecuperaUltimoJogoId();
            LoteriaOnlineData.Jogos.Add(jogo);
            return jogo;
        }

        public IEnumerable<Jogo> RecuperaJogosGanhadores(long concursoId)
        {
            return LoteriaOnlineData.Jogos.Where(x => x.ConcursoId == concursoId && x.Premiu != PremiuEnum.NaoSorteado);
        }

        public IEnumerable<Jogo> RecuperaPorConcurso(long concursoId)
        {
            return LoteriaOnlineData.Jogos.Where(x => x.ConcursoId == concursoId);
        }

        public virtual Jogo RecuperarPorId(long jogoId)
        {
            return LoteriaOnlineData.Jogos.FirstOrDefault( x => x.JogoId == jogoId);
        }

        public virtual IEnumerable<Jogo> RecuperaTodos()
        {
            return LoteriaOnlineData.Jogos;
        }

    }
}
