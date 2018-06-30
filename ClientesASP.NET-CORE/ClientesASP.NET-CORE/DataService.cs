using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Models;

namespace Clientes
{
    public class DataService
    {
        private readonly Contexto _contexto;

        public DataService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public void InicializaDB()
        {
            this._contexto.Database.EnsureCreated();

            if (this._contexto.Pessoas.Count()== 0)
            {
                List<Pessoa> pessoas = new List<Pessoa>
                {
                  new Pessoa(1, "Michel Manarin", "097.564.825-23",DateTime.Now, new DateTime(1996, 8, 10, 0, 0, 0)),
                  new Pessoa(1, "Alessandra", "097.564.825-23",DateTime.Now, new DateTime(1995, 8, 10, 0, 0, 0))
                };

                pessoas.ForEach( pessoa => this._contexto.Pessoas.Add(pessoa));
                this._contexto.SaveChanges();
            }            
        }
    }
}
