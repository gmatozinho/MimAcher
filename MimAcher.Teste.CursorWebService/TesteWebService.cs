using MimAcher.GeradorDados;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.Teste.CursorWebService
{
    class TesteWebService
    {
        static void Main(string[] args)
        {
            DiretorGeradores dir = new DiretorGeradores();

            for (int i = 0; i < 10; i++)
            {
                Participante p = (Participante)dir.GerarParticipante();

                p.Localizacao = "-13.23416/16.514";

                Console.WriteLine("Nome: " + p.Nome + "\nCodigo: " + CursorBD.EnviarParticipante(p));
                Console.WriteLine("--------------------------------------------------------------------");
            }

            Console.ReadLine();

        }
    }
}
