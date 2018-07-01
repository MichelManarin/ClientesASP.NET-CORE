using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clientes.Models;
using System.Globalization;
using Clientes.Models.ViewModels;

namespace Clientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IDataService _dataService;
        List<String> CollectionTelefone = new List<String> { };


        public ClienteController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        public IActionResult Menu(String filtroNome, DateTime filtroNasc, DateTime filtroDataCad)
        {
            ParametroDaAplicacao.EstadoDeOperacao = this._dataService.BuscaParametro().Estado;
            List<Pessoa> pessoas = _dataService.GetPessoas(filtroNome, filtroNasc, filtroDataCad);
            return View(pessoas);
        }

        public IActionResult Parametro()
        {
            var _estadoOperacao = _dataService.BuscaParametro();
            ParametroDaAplicacao.EstadoDeOperacao = _estadoOperacao.Estado;
            return View(_estadoOperacao);
        }

        public IActionResult EfetuarCadastroParametro(string campoestado)
        {
            this._dataService.GerenciaParametro(campoestado);
            ParametroDaAplicacao.EstadoDeOperacao = campoestado;
            return RedirectToAction("Menu");
        }

        public IActionResult Cadastrar(Int32 id)
        {
            PessoaTelefoneMestreDetalhe _viewmodel = new PessoaTelefoneMestreDetalhe();

            if (id > 0)
            {
                Pessoa _pessoa = _dataService.GetPessoa(id);
                _viewmodel.campocpf = _pessoa.Cpf;
                _viewmodel.camponasc = _pessoa.DataNasc;
                _viewmodel.camponome = _pessoa.Nome;
                _viewmodel.campoid = _pessoa.Id;
                _viewmodel.campodatacadastro = _pessoa.DataCadastro;
                _viewmodel.camporg = _pessoa.Rg;

                _dataService.GetTelefonesByPessoa(_pessoa).ForEach(
                    x => _viewmodel.telefones.Add((x.Numero))
                );
            }
            
            return View(_viewmodel);            
        }


        [HttpPost]
        public IActionResult EfetuarCadastroPessoa(PessoaTelefoneMestreDetalhe valores)
        {
            //DateTime _datanasc = DateTime.ParseExact(valores.camponasc,"yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (valores.campoid == 0)
            {
                _dataService.SetPessoas(new Pessoa(valores.camponome, valores.campocpf, DateTime.Now, valores.camponasc,valores.camporg));

                foreach (var item in valores.telefones)
                {
                    _dataService.SetTelefones(new Telefone(_dataService.GetPessoaByCpf(valores.campocpf), item));
                }
            } else
            {
               _dataService.UpdatePessoa(valores.campoid, valores);
            }
            
            return RedirectToAction("Menu");
        }

        public IActionResult Relatorio()
        {
            return View();
        }
        
    }
}