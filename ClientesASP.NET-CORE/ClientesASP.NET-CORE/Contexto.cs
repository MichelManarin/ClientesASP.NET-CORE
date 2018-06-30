using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoa> Produtos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }
    }
}
