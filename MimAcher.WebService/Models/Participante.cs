using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class Participante
    {
        public int cod_participante { get; set; }
        public int cod_usuario { get; set; }
        public int cod_campus { get; set; }
        public String nome { get; set; }
        public int telefone { get; set; }
        public DateTime ? dt_nascimento { get; set; }
        public Double ? latitude { get; set; }
        public Double ? longitude { get; set; }
    }
}