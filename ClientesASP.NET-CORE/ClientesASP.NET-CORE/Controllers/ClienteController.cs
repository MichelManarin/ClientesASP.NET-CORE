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
        
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Relatorio()
        {
            return View();
        }

        public IActionResult CadastrarNovaPessoa()
        {
            return View();
        }
    }
}