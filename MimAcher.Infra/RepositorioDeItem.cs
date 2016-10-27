using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeItem
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeItem()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_ITEM ObterItemPorId(int id)
        {
            return this.Contexto.MA_ITEM.Find(id);
        }

        public MA_ITEM ObterItemPorNome(MA_ITEM item)
        {
            return this.Contexto.MA_ITEM.Where(l => l.nome.Equals(item.nome)).SingleOrDefault();
        }

        public List<MA_ITEM> ObterTodosOsItems()
        {
            return this.Contexto.MA_ITEM.ToList();
        }

        public List<MA_ITEM> ObterTodosOsItemsPorNome(String nome)
        {
            return this.Contexto.MA_ITEM.Where(l => l.nome.ToLower().Equals(nome.ToLower())).ToList();
        }
                
        public void InserirItem(MA_ITEM Item)
        {
            if (VerificarSeNomeDeItemJaExiste(Item))
            {
                this.Contexto.MA_ITEM.Add(Item);
                this.Contexto.SaveChanges();
            }
            
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ITEM.Count();
        }

        public void RemoverItem(MA_ITEM Item)
        {
            this.Contexto.MA_ITEM.Remove(Item);
            this.Contexto.SaveChanges();
        }

        public void AtualizarItem(MA_ITEM Item)
        {
            if (VerificarSeNomeDeItemJaExiste(Item))
            {
                this.Contexto.Entry(Item).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeNomeDeItemJaExiste(MA_ITEM item)
        {
            if (ObterItemPorNome(item) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
