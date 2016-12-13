using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.Dominio.Model
{
    public class ErroImpressao
    {
        public String Tipo { get; set; }
        public String Aconteceu { get; set; }
        public String Incidencia { get; set; }
        public String DtAcontecimento { get; set; }
    }
}