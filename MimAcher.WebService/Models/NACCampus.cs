using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimAcher.WebService.Models
{
    public class NACCampus
    {
        public int cod_nc { get; set; }
        public int cod_us { get; set; }
        public String nomerepresentante { get; set; }
        public Double ? latitude { get; set; }
        public Double ? longitude { get; set; }
    }
}