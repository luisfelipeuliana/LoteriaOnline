using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Model.Entity
{
    public partial class Usuario
    {
        public long UsuarioId { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
    }

}
