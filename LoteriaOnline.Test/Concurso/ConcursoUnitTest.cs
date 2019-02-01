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

        #region Cadastro
        [Theory(DisplayName = "1.1 Deve cadastrar o novo usuário")]
        [ClassData(typeof(NovoConcursoDataTest))]
        public void Cadastra_Novo_Concurso(Concurso concurso)
        {
            var concursoId = concurso.ConcursoId;
            var concursoDB = _concursoController.Salvar(concurso);
            Assert.NotEqual(concursoDB.ConcursoId, concursoId);
            ValidarCadastroConcurso(concursoDB, concurso);
        }

        [Theory(DisplayName = "1.2 Deve editar o usuário")]
        [ClassData(typeof(NovoConcursoDataTest))]
        public void Editar_Concurso_Existente(Concurso concurso)
        {
            var concursoDB = _concursoController.Salvar(concurso);
            Assert.Equal(concursoDB.ConcursoId, concurso.ConcursoId);
            ValidarCadastroConcurso(concursoDB, concurso);
        }
        #endregion

        #region Listar
        [Fact(DisplayName = "1.3 Verifica se existe algum concurso cadastrado")]
        public void Verifica_Existencia_Concurso()
        {
            var concursos = _concursoController.Listar();
            Assert.True(concursos.Any());
        }
        #endregion

        #region RecuperarPorId
        [Theory(DisplayName = "1.4 Deve retornar o concurso pelo concursoId")]
        [InlineData(1)]
        public void Deve_Retorna_Concurso(long concursoId)
        {
            var concurso = _concursoController.RecuperarPorId(concursoId);
            Assert.NotNull(concurso);
        }
        #endregion        

        #region Finalizar concurso
        [Theory(DisplayName = "1.5 Finaliza o concurso que não acumulou")]
        [ClassData(typeof(FinalizarConcursoNaoAcumulouDataTest))]
        public void Finalizar_Concurso_Nao_Acumulou(Concurso concurso)
        {
            var concursoDB = _concursoController.FinalizarConcurso(concurso);
            ValidarFinalizarConcurso(concursoDB, concurso);
            Assert.Equal(concursoDB.Acumulou, (bool)false);
        }

        [Theory(DisplayName = "1.6 Finalizar o oncurso que acumulou")]
        [ClassData(typeof(FinalizarConcursoAcumulouDataTest))]
        public void Finalizar_Concurso_Acumulou(Concurso concurso)
        {
            var concursoDB = _concursoController.FinalizarConcurso(concurso);
            ValidarFinalizarConcurso(concursoDB, concurso);
            Assert.Equal(concursoDB.Acumulou, (bool)true);
        }
        #endregion

        #region Excluir
        [Theory(DisplayName = "1.7 Deve excluir o usuário pelo ConcursoId")]
        [InlineData(3)]
        public void Deve_excluir_Concurso(long concursoId)
        {
            var ConcursoExcluidoId = _concursoController.Excluir(concursoId);
            var ConcursoExcluido = _concursoController.RecuperarPorId(ConcursoExcluidoId);
            Assert.Null(ConcursoExcluido);
        }
        #endregion

        #region Métodos privados
        private void ValidarCadastroConcurso(Concurso concursoDB, Concurso concursoParametro)
        {
            Assert.Equal(concursoDB.DataCriacao, concursoParametro.DataCriacao);
            Assert.Equal(concursoDB.DataSorteio, concursoParametro.DataSorteio);
            Assert.Equal(concursoDB.TipoConcurso, concursoParametro.TipoConcurso);
        }

        private void ValidarFinalizarConcurso(Concurso concursoDB, Concurso concursoParametro)
        {
            Assert.Equal(concursoDB.NumeroSorteado, concursoParametro.NumeroSorteado);
            Assert.Equal(concursoDB.ConcursoId, concursoParametro.ConcursoId);
        }
        #endregion
    }
}
