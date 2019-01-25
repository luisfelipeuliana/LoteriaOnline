using LoteriaOnline.ApplicationCore.Interface.Repository;
using LoteriaOnline.ApplicationCore.Interface.Service;
using LoteriaOnline.ApplicationCore.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaOnline.ApplicationCore.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            var usuarioOriginal = _usuarioRepository.RecuperarPorId(usuario.UsuarioId);
            if (usuarioOriginal == null)
            {
                _usuarioRepository.Inserir(usuario);
                return usuario;
            }
            usuarioOriginal.Cpf = usuario.Cpf;
            usuarioOriginal.DataNascimento = usuario.DataNascimento;
            usuarioOriginal.Nome = usuario.Nome;
            usuarioOriginal.Email = usuario.Email;
            usuarioOriginal.Login = usuario.Login;
            usuarioOriginal.Senha = usuario.Senha;
            _usuarioRepository.Editar(usuarioOriginal);
            return usuarioOriginal;
        }

        public void Excluir(long usuarioId)
        {
            var usuario = _usuarioRepository.RecuperarPorId(usuarioId);
            _usuarioRepository.Excluir(usuario);
        }

        public Usuario RecuperarPorId(long usuarioId)
        {
            return _usuarioRepository.RecuperarPorId(usuarioId);
        }

        public IEnumerable<Usuario> RecuperaTodos()
        {
            return _usuarioRepository.RecuperaTodos();
        }
    }
}
