using MimAcher.GeradorDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Teste.CursorWebService
{
    internal class TesteWebService
    {
        private static void Main(string[] args)
        {

            var x = CursorBd.ObterDadosParticipante(1);

            Console.ReadLine();
            
        }
    }
}
