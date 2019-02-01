using LoteriaOnline.ApplicationCore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Interface.Service
{
    public interface IUsuarioService
    {
        Usuario Cadastrar(Usuario usuario);
        void Excluir(long usuarioId);
        IEnumerable<Usuario> RecuperaTodos();
        Usuario RecuperarPorId(long usuarioId);
        Usuario LogarUsuario(string login, string senha);
    }
}
