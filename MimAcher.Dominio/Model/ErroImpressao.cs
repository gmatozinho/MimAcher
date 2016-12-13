using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.Dominio.Model
{
    public class ErroImpressao
    {
        public String tipo { get; set; }
        public String aconteceu { get; set; }
        public String incidencia { get; set; }
        public String dt_acontecimento { get; set; }
    }
}