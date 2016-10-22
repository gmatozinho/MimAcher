﻿using MimAcher.Entidades;
using MimAcher.GeradorDados;
using MimAcher.Postgres.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.Postgres
{
    static class InserirDados
    {
        static void Main()
        {
            DiretorGeradores dir = new DiretorGeradores();
            Participante par;

            CursorPostgres cursor = new CursorPostgres();

            var watch = System.Diagnostics.Stopwatch.StartNew();

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
