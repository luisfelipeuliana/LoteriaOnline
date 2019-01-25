using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Model.Enum
{
    public enum PremiuEnum
    {
        [Description("Não sorteado")]
        NaoSorteado = 1,

        [Description("Quadra")]
        Quadra = 2,

        [Description("Quina")]
        Quina = 3,

        [Description("Sena")]
        Sena = 4,
    }
}
