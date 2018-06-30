using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataNasc { get; private set; }

        public Pessoa(int id, string nome, string cpf, DateTime dataCadastro, DateTime dataNasc)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCadastro = dataCadastro;
            this.DataNasc = dataNasc;
        }

    }
}
