using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.ApplicationCore.Model.Enum;

namespace LoteriaOnline.Test
{
    #region Novo concurso
    public class NovoConcursoDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Concurso { DataCriacao = new DateTime(2019,1,22), DataSorteio = DateTime.Now, TipoConcurso = TipoConcursoEnum.MegaSena} },

            new object[] { new Concurso { DataCriacao = new DateTime(2019,1,23), DataSorteio = new DateTime(2019, 1, 25), TipoConcurso = TipoConcursoEnum.MegaSena} }
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
    #endregion

    #region Editar concurso
    public class EditarConcursoDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Concurso { ConcursoId = 1, Acumulou = false, DataCriacao = new DateTime(2019,1,22), DataSorteio = DateTime.Now, TipoConcurso = TipoConcursoEnum.MegaSena} },
            new object[] { new Concurso { ConcursoId = 2, Acumulou = false, DataCriacao = new DateTime(2019,1,21), DataSorteio = DateTime.Now, TipoConcurso = TipoConcursoEnum.MegaSena} },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
    #endregion

    #region Finalizar concurso
    public class FinalizarConcursoNaoAcumulouDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Concurso { ConcursoId = 2, NumeroSorteado = "3-5-18-39-45-50" } },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class FinalizarConcursoAcumulouDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Concurso { ConcursoId = 2, NumeroSorteado = "1-2-3-4-5-6"} },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
    #endregion
}
