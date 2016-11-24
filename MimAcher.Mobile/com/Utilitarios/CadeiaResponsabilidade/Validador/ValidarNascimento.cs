using System;
using System.Collections.Generic;
using System.Globalization;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarNascimento : AbstractValidatorHandler
    {
        public ValidarNascimento(ValidatorEnum validator) : base(validator)
        {
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var data = informacoesInseridas["nascimento"];
            
            try
            {
                var compare = 1;
                if (string.IsNullOrEmpty(data)) return compare <= 0;
                var dataatual = DateTime.Today;

                DateTime saida;
                var isValid = DateTime.TryParseExact(data, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out saida);

                if (!isValid) return false;
                compare = DateTime.Compare(saida, dataatual);
                return compare <= 0;

            }
            catch
            {
                return false;
            }

            
        }

        public override void Write(Context activity)
        {
            throw new System.NotImplementedException();
        }
    }
}