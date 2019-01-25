using LoteriaOnline.ApplicationCore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Interface.Repository
{
    public interface IJogoRepository : IRepository<Jogo>
    {
        IEnumerable<Jogo> RecuperaJogosGanhadores(long concursoId);

        IEnumerable<Jogo> RecuperaPorConcurso(long concursoId);
    }
}