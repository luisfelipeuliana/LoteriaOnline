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
    public class ConcursoUnitTest
    {
        private readonly IConcursoRepository _concursoRepository;
        private readonly IConcursoService _concursoService;
        private readonly ConcursoController _concursoController;
        private readonly IJogoRepository _jogoRepository;
        private readonly IJogoService _jogoService;

        public ConcursoUnitTest()
        {
            _jogoRepository = new JogoRepository();
            _jogoService = new JogoService(_jogoRepository);
            _concursoRepository = new ConcursoRepository();
            _concursoService = new ConcursoService(_concursoRepository, _jogoRepository, _jogoService);
            _concursoController = new ConcursoController(_concursoService);
        }

        #region Listar
        [Fact(DisplayName = "Verifica se existe algum concurso cadastrado")]
        public void Verifica_Existencia_Concurso()
        {
            var concursos = _concursoController.Listar();
            Assert.True(concursos.Any());
        }
        #endregion

        #region RecuperarPorId
        [Theory(DisplayName = "Deve retornar o concurso pelo concursoId")]
        [InlineData(1)]
        public void Deve_Retorna_Concurso(long concursoId)
        {
            var concurso = _concursoController.RecuperarPorId(concursoId);
            Assert.NotNull(concurso);
        }
        #endregion

        #region Cadastro
        [Theory(DisplayName = "Deve cadastrar o novo usuário")]
        [ClassData(typeof(NovoConcursoDataTest))]
        public void Cadastra_Novo_Concurso(Concurso concurso)
        {
            var concursoId = concurso.ConcursoId;
            var concursoDB = _concursoController.Salvar(concurso);
            Assert.NotEqual(concursoDB.ConcursoId, concursoId);
            ValidarConcurso(concursoDB, concurso);
        }

        [Theory(DisplayName = "Deve editar o usuário")]
        [ClassData(typeof(NovoConcursoDataTest))]
        public void Editar_Concurso_Existente(Concurso concurso)
        {
            var concursoDB = _concursoController.Salvar(concurso);
            Assert.Equal(concursoDB.ConcursoId, concurso.ConcursoId);
            ValidarConcurso(concursoDB, concurso);
        }
        #endregion

        #region Excluir
        [Theory(DisplayName = "Deve excluir o usuário pelo ConcursoId")]
        [InlineData(2)]
        public void Deve_excluir_Concurso(long concursoId)
        {
            var ConcursoExcluidoId = _concursoController.Excluir(concursoId);
            var ConcursoExcluido = _concursoController.RecuperarPorId(ConcursoExcluidoId);
            Assert.Null(ConcursoExcluido);
        }
        #endregion

        #region Métodos privados
        private void ValidarConcurso(Concurso concursoDB, Concurso concursoParametro)
        {
            Assert.Equal(concursoDB.Acumulou, concursoParametro.Acumulou);
            Assert.Equal(concursoDB.DataCriacao, concursoParametro.DataCriacao);
            Assert.Equal(concursoDB.DataSorteio, concursoParametro.DataSorteio);
            Assert.Equal(concursoDB.NumeroSorteado, concursoParametro.NumeroSorteado);
            Assert.Equal(concursoDB.TipoConcurso, concursoParametro.TipoConcurso);
        }
        #endregion
    }
}
