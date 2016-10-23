using MimAcher.GeradorDados.Geradores;
using MimAcher.Mobile.Entidades;
using System;

namespace MimAcher.GeradorDados.Builders
{
    internal class BuilderItem
    {
        private readonly GeradorItem geradorItens = new GeradorItem();
        private readonly Random random = new Random();

        public ListaItens GerarListaItens()
        {
            ListaItens listaItens = new ListaItens();
            int quantidadeItens = random.Next(0, 10);

            while (quantidadeItens > 0)
            {
                listaItens.AdicionarItem(geradorItens.GerarItem());
                quantidadeItens--;
            }

            return listaItens;
        }
    }
}
