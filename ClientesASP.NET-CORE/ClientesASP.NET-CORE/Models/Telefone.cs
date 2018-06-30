using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Telefone
    {
        public int Id { get; private set; }
        public int IdPessoa { get; private set; }
        public string Numero { get; private set; }

        public Telefone(int id, int idpessoa, string numero)
        {
            this.Id = id;
            this.IdPessoa = idpessoa;
            this.Numero = numero;
        }
    }
}
