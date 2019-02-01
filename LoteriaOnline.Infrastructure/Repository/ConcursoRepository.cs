using LoteriaOnline.ApplicationCore.Interface.Repository;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoteriaOnline.Infrastructure.Repository
{
    public class ConcursoRepository : IConcursoRepository
    {

        public virtual void Editar(Concurso concurso)
        {
            foreach (var item in LoteriaOnlineData.Concursos)
            {
                if(concurso.ConcursoId == item.ConcursoId)
                {
                    item.Acumulou = concurso.Acumulou;
                    item.DataCriacao = concurso.DataCriacao;
                    item.DataSorteio = concurso.DataSorteio;
                    item.NumeroSorteado = concurso.NumeroSorteado;
                    item.TipoConcurso = concurso.TipoConcurso;                    
                    break;
                }
            }
        }

        public virtual void Excluir(Concurso concurso)
        {
            LoteriaOnlineData.Concursos.Remove(concurso);
        }

        public virtual Concurso Inserir(Concurso concurso)
        {
            concurso.ConcursoId = LoteriaOnlineData.RecuperaUltimoConcursoId();
            LoteriaOnlineData.Concursos.Add(concurso);
            return concurso;
        }

        public virtual Concurso RecuperarPorId(long concursoId)
        {
            return LoteriaOnlineData.Concursos.FirstOrDefault( x => x.ConcursoId == concursoId);
        }

        public virtual IEnumerable<Concurso> RecuperaTodos()
        {
            return LoteriaOnlineData.Concursos;
        }

    }
}
