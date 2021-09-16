using System;
using System.Collections.Generic;

namespace Avanade.Aquitetura.DecolaDev.Domain.Entidades
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public DateTime Nascimento { get; set; }

        public Decimal Salario { get; set; }

        public IEnumerable<string> Trem { get; set; }
    }
}