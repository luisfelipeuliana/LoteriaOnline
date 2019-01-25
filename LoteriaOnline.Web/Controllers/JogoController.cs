using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoteriaOnline.ApplicationCore.Interface.Service;
using LoteriaOnline.ApplicationCore.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoteriaOnline.Web.Controllers
{
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        [Route("api/Jogo/Listar")]
        public IEnumerable<Jogo> Listar()
        {
            return _jogoService.RecuperaTodos();
        }

        [HttpPost]
        [Route("api/Jogo/Salvar")]
        public Jogo Salvar([FromBody] Jogo jogo)
        {
            return _jogoService.Cadastrar(jogo);
        }

        [HttpGet]
        [Route("api/Jogo/Detalhes/{id}")]
        public Jogo RecuperarPorId(long id)
        {
            return _jogoService.RecuperarPorId(id);
        }

        [HttpGet]
        [Route("api/Jogo/GerarJogoAleatorio/{quantidadeNumero}")]
        public IEnumerable<int> GerarJogoAleatorioMegaSena(int quantidadeNumero)
        {
            return _jogoService.GerarJogoAleatorio(quantidadeNumero, 1, 60);
        }

        [HttpGet]
        [Route("api/Jogo/RecuperaNumeroJogo/{id}")]
        public IEnumerable<int> RecuperarNumeroJogo(long id)
        {
            return _jogoService.RecuperaNumeroJogo(id);
        }

        [HttpGet]
        [Route("api/Jogo/JogosGanhadores/{id}")]
        public IEnumerable<Jogo> RecuperarJogosGanhadores(long id)
        {
            return _jogoService.RecuperarJogosGanhadores(id);
        }

        [HttpDelete]
        [Route("api/Jogo/Excluir/{id}")]
        public long Excluir(long id)
        {
            _jogoService.Excluir(id);
            return id;
        }

    }
}