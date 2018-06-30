using System.Collections.Generic;
using Clientes.Models;

namespace Clientes
{
    public interface IDataService
    {
        void InicializaDB();
        List<Pessoa> GetPessoas();
        void SetPessoas(Pessoa novapessoa);
    }
}