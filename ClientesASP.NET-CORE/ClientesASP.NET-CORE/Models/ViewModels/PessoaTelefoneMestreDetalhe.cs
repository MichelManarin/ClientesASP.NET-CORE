using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models.ViewModels
{
    public class PessoaTelefoneMestreDetalhe
    {
        public int campoid { get; set; }
        public string camponome { get; set; }
        public DateTime camponasc { get;  set; }
        public DateTime campodatacadastro { get; set; }
        public string campocpf { get; set; }
        public string camporg { get; set; }
        public List<TelefoneInformado> telefones { get; set; }

        public PessoaTelefoneMestreDetalhe()
        {
            this.telefones = new List<TelefoneInformado> { };
        }

        public class TelefoneInformado
        {
            public string telefone { get; set; }
            public TelefoneInformado(string numero)
            {
                this.telefone = numero;
            }
        }            
    }
}
