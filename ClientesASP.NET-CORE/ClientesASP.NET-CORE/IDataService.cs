using System;
using System.Collections.Generic;
using Clientes.Models;
using Clientes.Models.ViewModels;

namespace Clientes
{
    public interface IDataService
    {
        void InicializaDB();
        List<Pessoa> GetPessoas(string filtroNome, DateTime filtroNasc, DateTime filtroDataCad);
        Pessoa GetPessoa(Int32 id);
        Pessoa GetPessoaByCpf(string CPF);
        void SetPessoas(Pessoa novapessoa);
        void SetTelefones(Telefone novotelefone);
        void UpdatePessoa(Int32 id, PessoaTelefoneMestreDetalhe valores);
        void GerenciaParametro(String estado);
        Parametro BuscaParametro();
        List<Telefone> GetTelefonesByPessoa(Pessoa Pessoa);
    }
}