using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Models;

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

            if (this._contexto.Pessoas.Count()== 0)
            {
                List<Pessoa> pessoas = new List<Pessoa>
                {
                  new Pessoa("Michel Manarin", "097.564.825-23",DateTime.Now, new DateTime(1996, 8, 10, 0, 0, 0)),
                  new Pessoa("Alessandra", "097.564.825-25",DateTime.Now, new DateTime(1995, 8, 10, 0, 0, 0)),
                  new Pessoa("Melgs", "097.564.825-27",DateTime.Now, new DateTime(2017, 1, 1, 0, 0, 0))
                };

                pessoas.ForEach( pessoa => this._contexto.Pessoas.Add(pessoa));
                this._contexto.SaveChanges();
            }            
        }

        void IDataService.SetPessoas(Pessoa novapessoa)
        {
            this._contexto.Pessoas.Add(novapessoa);
            this._contexto.SaveChanges();
        }
    }
}
