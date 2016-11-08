using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeItem
    {
        public RepositorioDeItem RepositorioDeItem { get; set; }

        public GestorDeItem()
        {
            RepositorioDeItem = new RepositorioDeItem();
        }

        public MA_ITEM ObterItemPorId(int id)
        {
            return RepositorioDeItem.ObterItemPorId(id);
        }

        public List<MA_ITEM> ObterTodosOsItems()
        {
            return RepositorioDeItem.ObterTodosOsItems();
        }

        public List<MA_ITEM> ObterTodosOsItemsPorNome(String nome)
        {
            return RepositorioDeItem.ObterTodosOsItemsPorNome(nome);
        }

        public void InserirItem(MA_ITEM Item)
        {
            RepositorioDeItem.InserirItem(Item);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeItem.BuscarQuantidadeRegistros();
        }

        public void RemoverItem(MA_ITEM Item)
        {
            RepositorioDeItem.RemoverItem(Item);
        }

        public void AtualizarItem(MA_ITEM Item)
        {
            RepositorioDeItem.AtualizarItem(Item);
        }
    }
}
