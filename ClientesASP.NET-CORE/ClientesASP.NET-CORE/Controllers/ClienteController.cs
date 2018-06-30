using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clientes.Models;

namespace Clientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IDataService _dataService;
        public ClienteController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        public IActionResult Menu(String filtroNome, DateTime filtroNasc, DateTime filtroDataCad)
        {
            List<Pessoa> pessoas = _dataService.GetPessoas(filtroNome, filtroNasc, filtroDataCad);
            return View(pessoas);
        }
        
        public IActionResult Cadastrar(Int32 id)
        {
            if (id > 0)
                return View(_dataService.GetPessoa(id));
            else
                return View();
        }

        public IActionResult Relatorio()
        {
            return View();
        }

        protected void EfetuarCadastro(string nome, string cpf, DateTime datanascimento)
        {
            _dataService.SetPessoas(new Pessoa(nome, cpf, DateTime.Now, datanascimento));
                    
        }
    }
}