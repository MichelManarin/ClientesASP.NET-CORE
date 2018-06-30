using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Pessoa
    {
        [Required]
        public int Id { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public string Cpf { get; private set; }
        [Required]
        public DateTime DataCadastro { get; private set; }
        [Required]
        public DateTime DataNasc { get; private set; }

        public Pessoa(string nome, string cpf, DateTime dataCadastro, DateTime dataNasc)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCadastro = dataCadastro;
            this.DataNasc = dataNasc;
        }

    }
}
