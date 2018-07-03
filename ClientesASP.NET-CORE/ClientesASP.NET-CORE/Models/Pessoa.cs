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

        public string Rg { get; private set; }
        [Required]
        public DateTime DataCadastro { get; private set; }
        [Required]
        public DateTime DataNasc { get; private set; }

        private void Validate()
        {
            if (ParametroDaAplicacao.EstadoDeOperacao == "SC")
                if (String.IsNullOrWhiteSpace(this.Rg))
                    throw new Exception("É necessário cadastrar o RG");

            if(ParametroDaAplicacao.EstadoDeOperacao == "PR")
            {
                if (this.DataNasc.AddYears(18) > DateTime.Now.Date)
                    throw new Exception("É necessário ter mais de 18 anos para cadastro");
            }

        }

        public Pessoa(Int32 id, string nome, string cpf, DateTime dataCadastro, DateTime dataNasc, string rg)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCadastro = dataCadastro;
            this.DataNasc = dataNasc;
            this.Rg = rg;
            Validate();

        }

        public Pessoa(string nome, string cpf, DateTime dataCadastro, DateTime dataNasc, string rg)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCadastro = dataCadastro;
            this.DataNasc = dataNasc;
            this.Rg = rg;
            Validate();
        }

        public void Altera(string nome, string cpf, DateTime dataCadastro, DateTime dataNasc, string rg)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCadastro = dataCadastro;
            this.DataNasc = dataNasc;
            this.Rg = rg;
            Validate();
        }

    }
}
