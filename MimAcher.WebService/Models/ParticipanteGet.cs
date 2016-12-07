using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class ParticipanteGet
    {
        public int cod_participante { get; set; }
        public String nome_participante { get; set; }
        public int cod_campus { get; set; }
        public String nome_campus { get; set; }
        public int cod_usuario { get; set; }
        public String e_mail { get; set; }
        public String telefone { get; set; }
        public String dt_nascimento { get; set; }
        public String latitude { get; set; }
        public String longitude { get; set; }                
    }
}