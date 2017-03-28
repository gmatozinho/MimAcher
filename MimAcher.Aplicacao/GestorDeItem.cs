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
            this.RepositorioDeItem = new RepositorioDeItem();
        }

        public MA_ITEM ObterItemPorId(int id)
        {
            return this.RepositorioDeItem.ObterItemPorId(id);
        }

        public List<MA_ITEM> ObterTodosOsItems()
        {
            return this.RepositorioDeItem.ObterTodosOsItems();
        }

        public List<MA_ITEM> ObterTodosOsItemsPorNome(String nome)
        {
            return this.RepositorioDeItem.ObterTodosOsItemsPorNome(nome);
        }

        public void InserirItem(MA_ITEM item)
        {
            this.RepositorioDeItem.InserirItem(item);
        }

        public Boolean InserirItemComRetorno(MA_ITEM item)
        {
            return this.RepositorioDeItem.InserirItemComRetorno(item);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeItem.BuscarQuantidadeRegistros();
        }

        public void RemoverItem(MA_ITEM item)
        {
            this.RepositorioDeItem.RemoverItem(item);
        }

        public void AtualizarItem(MA_ITEM item)
        {
            this.RepositorioDeItem.AtualizarItem(item);
        }

        public Boolean AtualizarItemComRetorno(MA_ITEM item)
        {
            return this.RepositorioDeItem.AtualizarItemComRetorno(item);
        }
    }
}
