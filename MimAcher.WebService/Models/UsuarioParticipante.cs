using System;

namespace MimAcher.WebService.Models
{
    public class UsuarioParticipante
    {
        public String e_mail { get; set; }
        public String senha { get; set; }
        public int cod_participante { get; set; }
        public int cod_usuario { get; set; }
        public int cod_campus { get; set; }
        public String nome { get; set; }
        public String telefone { get; set; }
        public DateTime? dt_nascimento { get; set; }
        public Double? latitude { get; set; }
        public Double? longitude { get; set; }
    }
}