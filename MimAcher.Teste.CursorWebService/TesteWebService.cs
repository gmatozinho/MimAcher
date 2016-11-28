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
            var itens = CursorBd.ObterParticipanteItem(25, CursorBd.ObterItens());

            foreach(var item in itens["hobbie"])
            {
                Console.WriteLine(item);
            }
            foreach (var item in itens["aprender"])
            {
                Console.WriteLine(item);
            }
            foreach (var item in itens["ensinar"])
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
