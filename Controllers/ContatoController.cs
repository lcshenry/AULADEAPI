using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MODULOAPI.Context;
using MODULOAPI.Entities;

namespace MODULOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        // VERBOS HTTP ATRAVES DO CRUD(CREATE, READ, UPDATE e DELETE)

        [HttpPost] // POST / CREATE
        public IActionResult Create(Contato contato)
        {
            // CRIANDO UM CONTATO
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("{id}")] // GET / READ
        public IActionResult ObterPorId(int id)
        {
            // OBTENDO POR ID
            var contato = _context.Contatos.Find(id);
            
            if(contato == null) 
                return NotFound();

            return Ok(contato);
        }
         [HttpGet("ObterPorNome")] // GET / READ
        public IActionResult ObterPorNome(string nome)
        {
            // OBTENDO POR NOME
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }

        [HttpPut("{id}")] // PUT / UPDATE
        public IActionResult Atualizar(int id, Contato contato)
        {

            // ATUALIZANDO CONTATO NO BANCO DE DADOS
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
            return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }
        [HttpDelete("{id}")] // DELETE / DELETE
        public IActionResult Deletar(int id, Contato contato)
        {

            // DELETANDO CONTATO NO BANCO
             var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
            return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}