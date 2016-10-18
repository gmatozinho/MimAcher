using MimAcher.GeradorDados.Geradores;
using System;
using MimAcher.Mobile.Entidades;

namespace MimAcher.GeradorDados.Builders
{
    internal class BuilderItem
    {
        private GeradorItem geradorItens = new GeradorItem();
        private Random random = new Random();

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
