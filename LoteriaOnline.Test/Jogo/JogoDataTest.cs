using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LoteriaOnline.ApplicationCore.Model.Entity;

namespace LoteriaOnline.Test
{
    
    public class NovoJogoDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Jogo { ConcursoId = 1, DataJogo = DateTime.Now, NumeroJogo = "01-02-03-04-05-06", UsuarioId = 1} },

            new object[] { new Jogo { ConcursoId = 1, DataJogo = new DateTime(2019,01,22), NumeroJogo = "01-11-15-26-36-50", UsuarioId = 1} },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }

    public class EditarJogoDataTest : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Jogo { JogoId = 1, ConcursoId = 1, DataJogo = DateTime.Now, NumeroJogo = "01-02-03-04-05-06", UsuarioId = 1} },

            new object[] { new Jogo { JogoId = 2, ConcursoId = 1, DataJogo = new DateTime(2019,01,22), NumeroJogo = "01-11-15-26-36-50", UsuarioId = 1} },
         };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }
    }
}
