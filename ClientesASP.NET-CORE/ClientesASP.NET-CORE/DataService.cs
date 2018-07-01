using System;
using System.Collections.Generic;
using System.Linq;
using Clientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using Clientes.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Clientes
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;

        public DataService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Pessoa GetPessoa(int id)
        {
            if (id < 1)
                throw new ArgumentException("É necessário informar o id da pessoa a ser buscada");

            return this._contexto.Pessoas.Find(id);
        }

        public Pessoa GetPessoaByCpf(string CPF)
        {
            if (String.IsNullOrEmpty(CPF))
                throw new ArgumentException("É necessário primeiro cadastrar a pessoa para depois cadastrar os telefones");

            var _pessoa = this._contexto.Pessoas.Where(x => (x.Cpf.Contains(CPF))).FirstOrDefault();
            return _pessoa;

        }

        public List<Telefone> GetTelefonesByPessoa(Pessoa Pessoa)
        {
            if (Pessoa is null)
                throw new ArgumentException("Não é possível buscar os telefones sem informar o objeto pessoa");

            return this._contexto.Telefones.Where(x => ((x.Pessoa == Pessoa))).ToList();

        }

        public List<Pessoa> GetPessoas(string filtroNome, DateTime filtroNasc, DateTime filtroDataCad)
        {
            DateTime _datavalida = new DateTime(1900, 1, 1, 1, 1, 1);

            return this._contexto.Pessoas.Where(x => (
                                                      (x.Nome.Contains(filtroNome) || String.IsNullOrEmpty(filtroNome)) &&
                                                      (x.DataCadastro.Date == filtroDataCad || filtroDataCad < _datavalida) &&
                                                      (x.DataNasc.Date == filtroNasc || filtroNasc < _datavalida))
                                                     ).OrderBy(x => x.Nome).ToList();
        }

        public void InicializaDB()
        {
            this._contexto.Database.EnsureCreated();

            if (this._contexto.Parametro.Count() == 0)
            {
                this._contexto.Parametro.Add(new Parametro("SC"));
                this._contexto.SaveChanges();
            } 

            if (this._contexto.Pessoas.Count() == 0)
            {
                List<Pessoa> pessoas = new List<Pessoa>
                {
                  new Pessoa("Michel Manarin", "097.564.825-23",DateTime.Now, new DateTime(1996, 8, 10, 0, 0, 0),"33.934.566-4"),
                  new Pessoa("Alessandra", "097.564.825-25",DateTime.Now, new DateTime(1995, 8, 10, 0, 0, 0) , "33.934.566-4"),
                  new Pessoa("Melgs", "097.564.825-27",DateTime.Now, new DateTime(2017, 1, 1, 0, 0, 0),"33.934.566-4")
                };

                pessoas.ForEach(pessoa => this._contexto.Pessoas.Add(pessoa));
                this._contexto.SaveChanges();
            }
        }

        void IDataService.SetPessoas(Pessoa novapessoa)
        {
            this._contexto.Pessoas.Add(novapessoa);
            this._contexto.SaveChanges();
        }

        Parametro IDataService.BuscaParametro()
        {
            return this._contexto.Parametro.Last();
        }

        void IDataService.GerenciaParametro(String estado){

            var _parametro = this._contexto.Parametro.Find(1);
            if (_parametro is null)
            {
                this._contexto.Parametro.Add(new Parametro(estado));
                this._contexto.SaveChanges();
            } else
            {
                this._contexto.Entry(_parametro).State = EntityState.Detached;
                _parametro.SetarEstado(estado);
                this._contexto.Update(_parametro);
                this._contexto.SaveChanges();
            }
        }

        void IDataService.UpdatePessoa(Int32 id, PessoaTelefoneMestreDetalhe valores)
        {
            var _pessoa = this.GetPessoa(id);
            this._contexto.Entry(_pessoa).State = EntityState.Detached;
            _pessoa.Altera(valores.camponome, valores.campocpf, valores.campodatacadastro, valores.camponasc, valores.camporg);
            this._contexto.Update(_pessoa);
            this._contexto.SaveChanges();
        }


        void IDataService.SetTelefones(Telefone novotelefone)
        {
            this._contexto.Telefones.Add(novotelefone);
            this._contexto.SaveChanges();
        }
    }
}
