using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class Parametro
    {
        [Required]
        public int Id { get; private set; }

        [Required]
        public string Estado { get; private set; }

        public void SetarEstado(string estado)
        {
            this.Estado = estado;
        }

        public Parametro(string estado)
        {
            this.Estado = estado;
        }
    }
    
}
