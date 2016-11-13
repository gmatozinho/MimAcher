﻿using System;
using System.Diagnostics;
using MimAcher.GeradorDados;
using MimAcher.Mobile.Entidades;
using MimAcher.Postgres.Conexao;

namespace MimAcher.Postgres
{
    static class InserirDados
    {
        static void Main()
        {
            DiretorGeradores dir = new DiretorGeradores();
            Participante par;

            CursorPostgres cursor = new CursorPostgres();

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
