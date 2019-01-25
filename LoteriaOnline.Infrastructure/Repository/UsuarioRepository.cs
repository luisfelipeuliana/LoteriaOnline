using LoteriaOnline.ApplicationCore.Interface.Repository;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoteriaOnline.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public virtual void Editar(Usuario usuario)
        {
            foreach (var item in LoteriaOnlineData.Usuarios)
            {
                if(usuario.UsuarioId == item.UsuarioId)
                {
                    item.Cpf = usuario.Cpf;
                    item.DataNascimento = usuario.DataNascimento;
                    item.Email = usuario.Email;
                    item.Nome = usuario.Nome;
                    item.Login = usuario.Login;
                    item.Senha = usuario.Senha;
                    break;
                }
            }
        }

        public virtual void Excluir(Usuario usuario)
        {
            LoteriaOnlineData.Usuarios.Remove(usuario);
        }

        public virtual Usuario Inserir(Usuario usuario)
        {
            usuario.UsuarioId = LoteriaOnlineData.RecuperaUltimoUsuarioId();
            LoteriaOnlineData.Usuarios.Add(usuario);
            return usuario;
        }

        public virtual Usuario RecuperarPorId(long usuarioId)
        {
            return LoteriaOnlineData.Usuarios.FirstOrDefault( x => x.UsuarioId == usuarioId);
        }

        public virtual IEnumerable<Usuario> RecuperaTodos()
        {
            return LoteriaOnlineData.Usuarios;
        }

    }
}
