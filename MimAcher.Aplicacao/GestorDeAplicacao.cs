using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.Aplicacao
{
    public class GestorDeAplicacao
    {
        public Boolean TratarCampoString(String campo)
        {

            if (campo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String RetornaDadoSemVigurla(String data)
        {
            string[] retornoSplit = data.Split(',');

            if (retornoSplit.Length <= 1)
            {
                return data;
            }
            else
            {
                data = retornoSplit[0] + "." + retornoSplit[1];

                return data;
            }

        }
    }
}
