using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estudos.Models
{
    public class Home
    {
        public List<Produto> Lista_destaque { get; set; }
        public List<Produto> Lista_tempo { get; set; }

        public int HomeId { get; set; }
    }
}

