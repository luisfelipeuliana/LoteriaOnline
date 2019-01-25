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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("api/Usuario/Listar")]
        public IEnumerable<Usuario> Listar()
        {
            return _usuarioService.RecuperaTodos();
        }

        [HttpPost]
        [Route("api/Usuario/Salvar")]
        public Usuario Salvar([FromBody] Usuario usuario)
        {
            return _usuarioService.Cadastrar(usuario);
        }

        [HttpGet]
        [Route("api/Usuario/Detalhes/{id}")]
        public Usuario RecuperarPorId(long id)
        {
            return _usuarioService.RecuperarPorId(id);
        }

        [HttpDelete]
        [Route("api/Usuario/Excluir/{id}")]
        public long Excluir(long id)
        {
            _usuarioService.Excluir(id);
            return id;
        }
    }
}