using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class NAC
    {
        public int cod_nac { get; set; }
        public int cd_usuario { get; set; }
        public int cod_campus { get; set; }
        public String nomerepresentante { get; set; }
        public int telefone { get; set; }
    }
}