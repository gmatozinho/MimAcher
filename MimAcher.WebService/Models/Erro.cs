using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class Erro
    {
        public string Tipo { get; set; }
        public string Aconteceu { get; set; }
        public int Incidencia { get; set; }
        public String DtAcontecimento { get; set; }
    }
}