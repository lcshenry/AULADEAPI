using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MODULOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        [HttpGet("OberDataHoraAtual")]
        public IActionResult ObterDataHora()
        {
            var obj = new 
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };
            return Ok(obj);
        }

        [HttpGet("Apresentar/{nome}/{idade}")]
        public IActionResult Apresentar(string nome, int idade)
        {
            var mensagem = $"Olá {nome}, você tem {idade} anos, seja bem vindo!";

            return Ok(new { mensagem });
        }
    }
}