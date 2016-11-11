using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeItem
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeItem()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_ITEM ObterItemPorId(int id)
        {
            return Contexto.MA_ITEM.Find(id);
        }

        public MA_ITEM ObterItemPorNome(MA_ITEM item)
        {
            return Contexto.MA_ITEM.Where(l => l.nome.Equals(item.nome)).SingleOrDefault();
        }

        public List<MA_ITEM> ObterTodosOsItems()
        {
            return Contexto.MA_ITEM.ToList();
        }

        public List<MA_ITEM> ObterTodosOsItemsPorNome(String nome)
        {
            return Contexto.MA_ITEM.Where(l => l.nome.ToLowerInvariant().Equals(nome.ToLowerInvariant())).ToList();
        }
                
        public void InserirItem(MA_ITEM Item)
        {
            if (VerificarSeNomeDeItemJaExiste(Item))
            {
                Contexto.MA_ITEM.Add(Item);
                Contexto.SaveChanges();
            }
            
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_ITEM.Count();
        }

        public void RemoverItem(MA_ITEM Item)
        {
            Contexto.MA_ITEM.Remove(Item);
            Contexto.SaveChanges();
        }

        public void AtualizarItem(MA_ITEM Item)
        {
            if (VerificarSeNomeDeItemJaExiste(Item))
            {
                Contexto.Entry(Item).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeNomeDeItemJaExiste(MA_ITEM item)
        {
            if (ObterItemPorNome(item) != null)
            {
                return true;
            }
            return false;
        }
    }
}
