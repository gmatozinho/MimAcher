using System;
using System.Diagnostics;
using MimAcher.GeradorDados;
using MimAcher.BancoDadosLocal.Conexao;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.BancoDadosLocal
{
    static class InserirDados
    {
        static void Main()
        {
            DiretorGeradores dir = new DiretorGeradores();
            Participante par;

            CursorGenerico cursor = new CursorSQLServer();

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < 250000; i++)
            {
                par = (Participante)dir.GerarParticipante();
                Console.WriteLine("Inserindo participante " + par.Nome + "...");
                cursor.InserirParticipante(par);
            }

            cursor.Close();

            watch.Stop();
            Console.WriteLine("Tempo: " + watch.Elapsed);

            Console.ReadLine();
        }
    }
}
