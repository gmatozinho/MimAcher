using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class Aluno
    {
        public int cod_al { get; set; }
        public int cod_us { get; set; }
        public String nome { get; set; }
        public String dt_nascimento { get; set; }
        public int telefone { get; set; }
        public String e_mail { get; set; }
        public Double ? latitude { get; set; }
        public Double ? longitude { get; set; }
    }
}