using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.ApplicationCore.Model.Enum;

namespace LoteriaOnline.Test
{
    
    public class NovoConcursoDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Concurso { Acumulou = false, DataCriacao = new DateTime(2019,1,22), DataSorteio = DateTime.Now, NumeroSorteado = "01-02-03-04-05-06", TipoConcurso = TipoConcursoEnum.MegaSena} },

            new object[] { new Concurso { Acumulou = false, DataCriacao = new DateTime(2019,1,23), DataSorteio = new DateTime(2019, 1, 25), TipoConcurso = TipoConcursoEnum.MegaSena} }
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class EditarConcursoDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Concurso { ConcursoId = 1, Acumulou = false, DataCriacao = new DateTime(2019,1,22), DataSorteio = DateTime.Now, NumeroSorteado = "01-02-03-04-05-06", TipoConcurso = TipoConcursoEnum.MegaSena} },
            new object[] { new Concurso { ConcursoId = 2, Acumulou = false, DataCriacao = new DateTime(2019,1,21), DataSorteio = DateTime.Now, TipoConcurso = TipoConcursoEnum.MegaSena} },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
