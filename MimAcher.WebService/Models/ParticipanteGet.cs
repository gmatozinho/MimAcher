using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class ParticipanteGet
    {
        public int CodParticipante { get; set; }
        public String NomeParticipante { get; set; }
        public int CodCampus { get; set; }
        public String NomeCampus { get; set; }
        public int CodUsuario { get; set; }
        public String EMail { get; set; }
        public String Telefone { get; set; }
        public String DtNascimento { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }                
    }
}