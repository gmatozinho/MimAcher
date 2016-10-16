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
    }
}
