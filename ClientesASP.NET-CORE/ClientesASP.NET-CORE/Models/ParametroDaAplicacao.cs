using System;
using System.Data;
using System.Linq;
using System.Web;

namespace Clientes.Models
{
    public static class ParametroDaAplicacao
    {
        static string _estadoDeOperacao;

        public static string EstadoDeOperacao
        {
            get
            {
                return _estadoDeOperacao;
            }
            set
            {
                _estadoDeOperacao = value;
            }
        }
    }
}

