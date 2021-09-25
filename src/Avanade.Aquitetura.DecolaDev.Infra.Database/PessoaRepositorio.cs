using Avanade.Aquitetura.DecolaDev.Domain.Entidades;
using Avanade.Aquitetura.DecolaDev.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.Aquitetura.DecolaDev.Infra.Database
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        List<Domain.Entidades.Pessoa> _banco;

        public PessoaRepositorio()
        {
            _banco = new List<Domain.Entidades.Pessoa>();
        }

        public void Atualizar(int id, Pessoa entidade)
        {
            var item = _banco.FirstOrDefault(p => p.Id == id);

            if (item is not null)
            {
                item.Nascimento = entidade.Nascimento;
                item.NomeCompleto = entidade.NomeCompleto;
                item.Salario = entidade.Salario;
                item.Trem = entidade.Trem;
            }
            else
            {
                throw new Exception($"Entidade id {id} não existe na base de dados");
            }
        }

        public void Cadastrar(Pessoa entidade)
        {
            _banco.Add(entidade);
        }

        public void Deletar(int id)
        {
            _banco.Remove(_banco.FirstOrDefault(p => p.Id == id));
        }

        public IEnumerable<Pessoa> Listar()
        {
            return _banco.ToList();
        }

        public Pessoa ObterPorId(int id)
        {
            return _banco.FirstOrDefault(p => p.Id == id);

            //TODO: Criar o teste de unidade para o repositorio
            //throw new Exception();
        }
    }
}
