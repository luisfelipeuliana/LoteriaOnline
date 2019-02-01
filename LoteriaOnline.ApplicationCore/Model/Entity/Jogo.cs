using LoteriaOnline.ApplicationCore.Helps.Extension;
using LoteriaOnline.ApplicationCore.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Model.Entity
{
    public partial class Jogo
    {
        public long JogoId { get; set; }

        public DateTime DataJogo { get; set; }

        public string NumeroJogo { get; set; }

        public int UsuarioId { get; set; }

        public int ConcursoId { get; set; }

        public PremiuEnum? Premiu { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Concurso Concurso { get; set; }
    }

    public partial class Jogo
    {
        public string DescricaoPremiu
        {
            get
            {
                return Premiu.GetDescription();
            }
        }
    }
}
