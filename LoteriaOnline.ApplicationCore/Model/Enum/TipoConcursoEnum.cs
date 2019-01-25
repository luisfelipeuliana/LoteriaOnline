using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Model.Enum
{
    public enum TipoConcursoEnum
    {
        [Description("MEGA-SENA")]
        MegaSena = 1,

        [Description("LOTOFÁCIL")]
        LotoFacil = 2,

        [Description("QUINA")]
        Quina = 3,

        [Description("LOTOMANIA")]
        LotoMania = 4,

        [Description("TIMEMANIA")]
        TimeMania = 5,

        [Description("DUPLA SENA")]
        DuplaSena = 6,
    }
}
