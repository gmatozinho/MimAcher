using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class Usuario
    {
        public int cod_us { get; set; }
        public String login { get; set; }
        public String senha { get; set; }
        public int identificador { get; set; }
    }
}