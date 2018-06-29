using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Menu()
        {
            return View();
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