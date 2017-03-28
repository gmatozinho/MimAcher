using System;

namespace MimAcher.WebService.Models
{
    public class UsuarioParticipante
    {
        public String EMail { get; set; }
        public String Senha { get; set; }
        public int CodParticipante { get; set; }
        public int CodUsuario { get; set; }
        public int CodCampus { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public DateTime? DtNascimento { get; set; }
        public Double? Latitude { get; set; }
        public Double? Longitude { get; set; }
    }
}