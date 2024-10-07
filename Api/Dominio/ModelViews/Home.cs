using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.ModelViews
{
    public class Home
    {
        public string Mensagem { get => "Bem vindo a API de veiculos - Minimal API"; }
        public string Doc { get => "/swagger"; }
    }
}