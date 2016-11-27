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
            var dir = new DiretorGeradores();

            for (var i = 0; i < 10; i++)
            {
                var p = (Participante)dir.GerarParticipante();

                p.Localizacao = "-13.23416/16.514";

                Console.WriteLine("Nome: " + p.Nome + "\nCodigo: " + CursorBd.CadastrarParticipante(p));
                Console.WriteLine("--------------------------------------------------------------------");
            }

            Console.ReadLine();

        }
    }
}
