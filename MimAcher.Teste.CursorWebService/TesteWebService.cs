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
            var itens = CursorBd.Match(2);

            foreach(var item in itens["hobbie"])
            {
                Console.WriteLine("Hobbie: " + item);
            }
            foreach (var item in itens["aprender"])
            {
                Console.WriteLine("Aprender: " + item);
            }
            foreach (var item in itens["ensinar"])
            {
                Console.WriteLine("Ensinar: " + item);
            }

            Console.ReadLine();
        }
    }
}
