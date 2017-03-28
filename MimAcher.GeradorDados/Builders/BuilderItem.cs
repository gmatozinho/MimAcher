using System;
using MimAcher.GeradorDados.Geradores;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.GeradorDados.Builders
{
    internal class BuilderItem
    {
        private readonly GeradorItem _geradorItens = new GeradorItem();
        private readonly Random _random = new Random();

        public ListaItens GerarListaItens()
        {
            ListaItens listaItens = new ListaItens();
            int quantidadeItens = _random.Next(0, 10);

            while (quantidadeItens > 0)
            {
                listaItens.AdicionarItemParaGerador(_geradorItens.GerarItem());
                quantidadeItens--;
            }

            return listaItens;
        }
    }
}
