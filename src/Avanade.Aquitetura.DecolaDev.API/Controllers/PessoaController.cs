using Avanade.Aquitetura.DecolaDev.Domain.Entidades;
using Avanade.Aquitetura.DecolaDev.Domain.Interfaces;
using Avanade.Aquitetura.DecolaDev.Infra.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Avanade.Aquitetura.DecolaDev.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;

        private readonly IRepositorio<Pessoa> _repositorio;

        public PessoaController(
            ILogger<PessoaController> logger,
            IRepositorio<Pessoa> repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;
        }

        [HttpGet]
        public IEnumerable<Domain.Entidades.Pessoa> Obter()
        {
            return _repositorio.Listar();
        }

        [HttpGet("{id}")]
        public Domain.Entidades.Pessoa ObterPorId([FromRoute] int id)
        {
            return _repositorio.ObterPorId(id);
        }

        [HttpPost()]
        public void CadastrarPessoa([FromBody] Domain.Entidades.Pessoa pessoa)
        {
            _repositorio.Cadastrar(pessoa);
        }

        [HttpPut("{id}")]
        public void AtualizarPessoa([FromRoute] int id, [FromBody] Domain.Entidades.Pessoa pessoa)
        {
            _repositorio.Atualizar(id, pessoa);
        }

        [HttpDelete("{id}")]
        public void DeletarPessoa([FromRoute] int id)
        {
            _repositorio.Deletar(id);
        }
    }
}
