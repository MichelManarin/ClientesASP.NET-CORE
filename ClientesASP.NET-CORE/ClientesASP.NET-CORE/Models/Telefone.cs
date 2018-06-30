using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Telefone
    {
        [Required]
        public int Id { get; private set; }
        [Required]
        public string Numero { get; private set; }
        [Required]
        public Pessoa Pessoa { get; private set; }

        public Telefone()
        {

        }

        public Telefone(int id, Pessoa pessoa, string numero)
        {
            this.Id = id;
            this.Pessoa = pessoa;
            this.Numero = numero;
        }
    }
}
