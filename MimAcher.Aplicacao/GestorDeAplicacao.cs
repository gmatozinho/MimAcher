using System;

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
            return false;
        }

        public String RetornaDadoSemVigurla(String data)
        {
            string[] retornoSplit = data.Split(',');

            if (retornoSplit.Length <= 1)
            {
                return data;
            }
            data = retornoSplit[0] + "." + retornoSplit[1];

            return data;
        }
    }
}
