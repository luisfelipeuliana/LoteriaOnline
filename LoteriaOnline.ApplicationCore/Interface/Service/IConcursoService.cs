using LoteriaOnline.ApplicationCore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Interface.Service
{
    public interface IConcursoService
    {
        Concurso Cadastrar(Concurso concurso);
        void Excluir(long ConcursoId);
        IEnumerable<Concurso> RecuperaTodos();
        Concurso RecuperarPorId(long concursoId);
        Concurso FinalizarConcurso(long concursoId, string numeroSorteado);
    }
}
