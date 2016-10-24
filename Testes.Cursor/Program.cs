using MimAcher.GeradorDados;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.Cursor
{
    class Program
    {
        static void Main(string[] args)
        {
            DiretorGeradores dir = new DiretorGeradores();
            Participante par;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                par = (Participante)dir.GerarParticipante();
                Console.WriteLine("Inserindo participante " + par.Nome + "...");
                Console.WriteLine(string.Format("email: {0} \n senha> {1}", par.Email, par.Senha));
                par.Commit();
            }

            Console.ReadLine();
        }
    }
}
