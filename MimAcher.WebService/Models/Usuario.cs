using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class Usuario
    {
        public int cod_usuario { get; set; }
        public String e_mail { get; set; }
        public String senha { get; set; }        
    }
}