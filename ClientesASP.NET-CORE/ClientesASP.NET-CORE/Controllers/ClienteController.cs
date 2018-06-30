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


        public IActionResult Menu()
        {
            var pessoas = new List<Pessoa>
            {
                new Pessoa("Michel", "096.125156165", DateTime.Now, DateTime.Now)
            };
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
    }
}