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

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Domain.Entidades.Pessoa> Obter()
        {
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio();

            return pessoaRepositorio.Listar();
        }

        [HttpGet("{id}")]
        public Domain.Entidades.Pessoa ObterPorId([FromRoute] int id)
        {
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio();

            return pessoaRepositorio.ObterPorId(id);
        }

        [HttpPost()]
        public void CadastrarPessoa([FromBody] Domain.Entidades.Pessoa pessoa)
        {
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio();

            pessoaRepositorio.CadastrarPessoa(pessoa);
        }

        [HttpPut("{id}")]
        public void AtualizarPessoa([FromRoute] int id, [FromBody] Domain.Entidades.Pessoa pessoa)
        {
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio();

            pessoaRepositorio.AtualizarPessoa(id, pessoa);
        }

        [HttpDelete("{id}")]
        public void DeletarPessoa([FromRoute] int id)
        {
            PessoaRepositorio pessoaRepositorio = new PessoaRepositorio();

            pessoaRepositorio.DeletarPessoa(id);
        }
    }
}
