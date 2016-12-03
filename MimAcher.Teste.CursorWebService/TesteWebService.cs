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
            CursorBd.EnviarAprender(1, 7);
            CursorBd.EnviarEnsinar(1, 7);
            CursorBd.EnviarHobbie(1, 7);

            var itens = CursorBd.ObterParticipanteItem(1, CursorBd.ObterItens());

            foreach (var item in itens.Keys)
            {
                foreach (var elem in itens[item])
                    Console.WriteLine(item + ": " + elem);
            }

            Console.ReadLine();
        }
    }
}
