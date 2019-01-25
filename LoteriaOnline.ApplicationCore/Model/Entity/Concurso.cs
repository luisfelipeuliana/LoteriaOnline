using LoteriaOnline.ApplicationCore.Helps.Extension;
using LoteriaOnline.ApplicationCore.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Model.Entity
{
    public partial class Concurso
    {
        public long ConcursoId { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataSorteio { get; set; }

        public string NumeroSorteado { get; set; }

        public bool Acumulou { get; set; }

        public TipoConcursoEnum TipoConcurso { get; set; }
    }


    public partial class Concurso
    {
        public string NomeTipoConcurso
        {
            get
            {
                return TipoConcurso.GetDescription();
            }
        }

        public List<Usuario> Usuarios { get; set; }
    }
}
