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
    public class JogoUnitTest
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IJogoService _jogoService;
        private readonly JogoController _jogoController;

        public JogoUnitTest()
        {
            _jogoRepository = new JogoRepository();
            _jogoService = new JogoService(_jogoRepository);
            _jogoController = new JogoController(_jogoService);
        }

        #region Cadastro
        [Theory(DisplayName = "1.1 Deve cadastrar o novo jogo")]
        [ClassData(typeof(NovoJogoDataTest))]
        public void Cadastra_Novo_Jogo(Jogo jogo)
        {
            var jogoId = jogo.JogoId;
            var jogoDB = _jogoController.Salvar(jogo);
            Assert.NotEqual(jogoDB.JogoId, jogoId);
            ValidarJogo(jogoDB, jogo);
        }

        [Theory(DisplayName = "1.2 Deve editar o jogo")]
        [ClassData(typeof(NovoJogoDataTest))]
        public void Editar_Jogo_Existente(Jogo jogo)
        {
            var jogoDB = _jogoController.Salvar(jogo);
            Assert.Equal(jogoDB.JogoId, jogo.JogoId);
            ValidarJogo(jogoDB, jogo);
        }
        #endregion

        #region Listar
        [Fact(DisplayName = "1.3 Verifica se existe algum jogo cadastrado")]
        public void Verifica_Existencia_Jogo()
        {
            var jogos = _jogoController.Listar();
            Assert.True(jogos.Any());
        }
        #endregion

        #region RecuperarPorId
        [Theory(DisplayName = "1.4 Deve retornar o jogo pelo jogoId")]
        [InlineData(1)]
        public void Deve_Retorna_Jogo(long jogoId)
        {
            var jogo = _jogoController.RecuperarPorId(jogoId);
            Assert.NotNull(jogo);
        }
        #endregion

        #region GerarJogoAleatorioMegaSena
        [Theory(DisplayName = "1.5 Deve gerar um jogo aleatório da Mega-Sena e verificar a quantidade de números distintos")]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(15)]
        public void Deve_Gerar_Jogo_Aleatoriamente_MegaSena_Verifica_Quantidade_Numeros_Gerados(int quantidadeNumeros)
        {
            var listaNumerosAleatorios = _jogoController.GerarJogoAleatorioMegaSena(quantidadeNumeros);
            var numerosDistintosGerados = listaNumerosAleatorios.Distinct().Count();
            Assert.Equal(numerosDistintosGerados, quantidadeNumeros);
        }

        [Theory(DisplayName = "1.6 Deve gerar um jogo aleatório da Mega-Sena e validar valor mínimo e máximo")]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(15)]
        public void Deve_Gerar_Jogo_Aleatoriamente_MegaSena_Verifica_Minimo_Maximo(int quantidadeNumeros)
        {
            var listaNumerosAleatorios = _jogoController.GerarJogoAleatorioMegaSena(quantidadeNumeros);
            var numerosValido = listaNumerosAleatorios.Any(x => x > 60 || x < 1);
            Assert.False(numerosValido);
        }
        #endregion

        #region RecuperarNumeroJogo
        [Theory(DisplayName = "1.7 Verifica se existe números de jogo por jogoId")]
        [InlineData(1)]
        [InlineData(2)]
        public void Verifica_Existencia_Numeros_Jogo(long jogoId)
        {
            var numerosJogo = _jogoController.RecuperarNumeroJogo(jogoId);
            Assert.True(numerosJogo.Any());
        }
        #endregion

        #region RecuperarNumeroJogo
        [Theory(DisplayName = "1.8 Verifica se existe ganhadores por concursoId")]
        [InlineData(1)]
        public void Verifica_Existencia_Ganhadores(long concursoId)
        {
            var ganhadores = _jogoController.RecuperarJogosGanhadores(concursoId);
            Assert.True(ganhadores.Any());
        }
        #endregion

        #region Excluir
        [Theory(DisplayName = "1.9 Deve excluir o jogo pelo jogoId")]
        [InlineData(2)]
        public void Deve_excluir_Jogo(long jogoId)
        {
            var jogoExcluidoId = _jogoController.Excluir(jogoId);
            var jogoExcluido = _jogoController.RecuperarPorId(jogoExcluidoId);
            Assert.Null(jogoExcluido);
        }
        #endregion

        #region Métodos privados
        private void ValidarJogo(Jogo jogoDB, Jogo jogoParametro)
        {
            Assert.Equal(jogoDB.ConcursoId, jogoParametro.ConcursoId);
            Assert.Equal(jogoDB.DataJogo, jogoParametro.DataJogo);
            Assert.Equal(jogoDB.NumeroJogo, jogoParametro.NumeroJogo);
            Assert.Equal(jogoDB.UsuarioId, jogoParametro.UsuarioId);
        }
        #endregion
    }
}
