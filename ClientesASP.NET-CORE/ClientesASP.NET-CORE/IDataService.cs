﻿using System;
using System.Collections.Generic;
using Clientes.Models;

namespace Clientes
{
    public interface IDataService
    {
        void InicializaDB();
        List<Pessoa> GetPessoas(string filtroNome, DateTime filtroNasc, DateTime filtroDataCad);
        Pessoa GetPessoa(Int32 id);
        void SetPessoas(Pessoa novapessoa);
    }
}