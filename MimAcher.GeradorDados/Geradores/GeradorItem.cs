using System;
using System.Collections.Generic;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorItem
    {
        private static Random random = new Random();
        private static readonly List<string> tipo_item =
            new List<string>
            { "futebol", "violao", "php", "c#", "xamarin", "teclado", "bateria",
            "uml", "analise de sistemas", "programacao", "cozinha", "cinema", "banco de dados",
            "cachorros", "medicina", "medicina alternativa", "psicologia", "livros de ficcao",
            "star wars", "star trek", "decoracao", "sociologia", "politica", "religiao",
            "volei", "tenis de mesa", "basquete", "NFL", "harry potter", "senhor dos aneis",
            "formula 1", "stock car", "sql", "linux", "windows", "direcao defensiva", "caminhada",
            "teoria musical", "ciencia da computacao", "calculo", "empreendedorismo"};

        public string GerarItem()
        {
            return tipo_item[random.Next(0, tipo_item.Count)];
        }
    }
}
