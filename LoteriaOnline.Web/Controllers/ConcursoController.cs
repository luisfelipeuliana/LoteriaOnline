using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoteriaOnline.ApplicationCore.Interface.Service;
using LoteriaOnline.ApplicationCore.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoteriaOnline.Web.Controllers
{
    [ApiController]
    public class ConcursoController : ControllerBase
    {
        private readonly IConcursoService _concursoService;

        public ConcursoController(IConcursoService concursoService)
        {
            _concursoService = concursoService;
        }

        [HttpGet]
        [Route("api/Concurso/Listar")]
        public IEnumerable<Concurso> Listar()
        {
            return _concursoService.RecuperaTodos();
        }

        [HttpPost]
        [Route("api/Concurso/Salvar")]
        public Concurso Salvar([FromBody] Concurso concurso)
        {
            return _concursoService.Cadastrar(concurso);
        }

        [HttpGet]
        [Route("api/Concurso/RecuperarPorId/{id}")]
        public Concurso RecuperarPorId(long id)
        {
            return _concursoService.RecuperarPorId(id);
        }

        [HttpPost]
        [Route("api/Concurso/FinalizarConcurso")]
        public Concurso FinalizarConcurso([FromBody] Concurso concurso)
        {
            return _concursoService.FinalizarConcurso(concurso.ConcursoId, concurso.NumeroSorteado);
        }

        [HttpDelete]
        [Route("api/Concurso/Excluir/{id}")]
        public long Excluir(long id)
        {
            _concursoService.Excluir(id);
            return id;
        }
    }
}