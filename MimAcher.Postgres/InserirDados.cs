using MimAcher.Entidades;
using MimAcher.GeradorDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.Postgres
{
    class InserirDados
    {
        static void Main(string[] args)
        {
            DiretorGeradores dir = new DiretorGeradores();
            Participante par = (Participante)dir.GerarParticipante();

            CursorPostgres cursor = new CursorPostgres();

            cursor.InserirParticipante(par);
            
            Console.ReadLine();
        }
    }
}
