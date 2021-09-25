using Avanade.Aquitetura.DecolaDev.API.Controllers;
using Avanade.Aquitetura.DecolaDev.Domain.Entidades;
using Avanade.Aquitetura.DecolaDev.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Avanade.DecolaTech.Tests
{
    public class PessoaControllerTests
    {
        private PessoaController _pessoaController;

        private Mock<ILogger<PessoaController>> _loggerMock;

        private Mock<IRepositorio<Pessoa>> _repositorioMock;

        [Fact]
        public void ObterPorId_QuandoIdExiste()
        {
            //Arrange
            Pessoa pessoa = new Pessoa
            {
                Id = 1,
                Nascimento = DateTime.Now,
                NomeCompleto = "Fructuoso",
                Salario = 1.99M
            };

            _loggerMock = new Mock<ILogger<PessoaController>>();

            _repositorioMock = new Mock<IRepositorio<Pessoa>>();

            _repositorioMock.Setup(x => x.ObterPorId(1))
                .Returns(pessoa);

            _pessoaController = new PessoaController(
                _loggerMock.Object,
                _repositorioMock.Object);

            //Act
            var pessoaRecebida = _pessoaController.ObterPorId(1);

            //Assert
            Assert.NotNull(pessoaRecebida);

            Assert.Equal(pessoa.NomeCompleto, pessoaRecebida.NomeCompleto);

            _repositorioMock.Verify(x => x.ObterPorId(It.IsAny<int>()),
                times: Times.Once);
        }
    }
}
