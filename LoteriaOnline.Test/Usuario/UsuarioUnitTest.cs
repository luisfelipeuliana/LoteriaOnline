using LoteriaOnline.ApplicationCore.Interface.Repository;
using LoteriaOnline.ApplicationCore.Interface.Service;
using LoteriaOnline.ApplicationCore.Model.Entity;
using LoteriaOnline.ApplicationCore.Service;
using LoteriaOnline.Infrastructure.Repository;
using LoteriaOnline.Web.Controllers;
using System;
using System.Linq;
using Xunit;

namespace LoteriaOnline.Test
{
    public class UsuarioUnitTest
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly UsuarioController _usuarioController;

        public UsuarioUnitTest()
        {
            _usuarioRepository = new UsuarioRepository();
            _usuarioService = new UsuarioService(_usuarioRepository);
            _usuarioController = new UsuarioController(_usuarioService);
        }

        #region Listar
        [Fact(DisplayName ="Verifica se existe algum usuário cadastrado")]
        public void Verifica_Existencia_usuario()
        {
            var usuarios = _usuarioController.Listar();
            Assert.True(usuarios.Any());
        }
        #endregion

        #region RecuperarPorId
        [Theory(DisplayName = "Deve retornar o usuário pelo usuarioId")]
        [InlineData(1)]
        public void Deve_Retorna_Usuario(long usuarioId)
        {
            var usuario = _usuarioController.RecuperarPorId(usuarioId);
            Assert.NotNull(usuario);
        }
        #endregion

        #region Cadastro
        [Theory(DisplayName = "Deve cadastrar o novo usuário")]
        [ClassData(typeof(NovoUsuarioDataTest))]
        public void Cadastra_Novo_Usuario(Usuario usuario)
        {
            var usuarioId = usuario.UsuarioId;
            var usuarioDB = _usuarioController.Salvar(usuario);
            Assert.NotEqual(usuarioDB.UsuarioId, usuarioId);
            ValidarUsuario(usuarioDB, usuario);
        }

        [Theory(DisplayName = "Deve editar o usuário")]
        [ClassData(typeof(NovoUsuarioDataTest))]
        public void Editar_Usuario_Existente(Usuario usuario)
        {
            var usuarioDB = _usuarioController.Salvar(usuario);
            Assert.Equal(usuarioDB.UsuarioId, usuario.UsuarioId);
            ValidarUsuario(usuarioDB, usuario);
        }
        #endregion

        #region Excluir
        [Theory(DisplayName = "Deve excluir o usuário pelo usuarioId")]
        [InlineData(2)]
        public void Deve_excluir_Usuario(long usuarioId)
        {
            var usuarioExcluidoId = _usuarioController.Excluir(usuarioId);
            var usuarioExcluido = _usuarioController.RecuperarPorId(usuarioExcluidoId);
            Assert.Null(usuarioExcluido);
        }
        #endregion

        #region Métodos privados
        private void ValidarUsuario(Usuario usuarioDB, Usuario usuarioParametro )
        {
            Assert.Equal(usuarioDB.Cpf, usuarioParametro.Cpf);
            Assert.Equal(usuarioDB.DataNascimento, usuarioParametro.DataNascimento);
            Assert.Equal(usuarioDB.Email, usuarioParametro.Email);
            Assert.Equal(usuarioDB.Nome, usuarioParametro.Nome);
        }
        #endregion
    }
}
