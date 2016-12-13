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
            return this.Contexto.MA_ITEM.Where(l => l.nome.ToLowerInvariant().Equals(nome.ToLowerInvariant())).ToList();
        }

        public void InserirItem(MA_ITEM item)
        {
            if (VerificarSeNomeDeItemJaExiste(item))
            {
                this.Contexto.MA_ITEM.Add(item);
                this.Contexto.SaveChanges();
            }
        }

        public Boolean InserirItemComRetorno(MA_ITEM item)
        {
            if (VerificarSeNomeDeItemJaExiste(item))
            {
                try
                {
                    this.Contexto.MA_ITEM.Add(item);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ITEM.Count();
        }

        public void RemoverItem(MA_ITEM item)
        {
            this.Contexto.MA_ITEM.Remove(item);
            this.Contexto.SaveChanges();
        }

        public void AtualizarItem(MA_ITEM item)
        {
            if (VerificarSeNomeDeItemJaExiste(item))
            {
                this.Contexto.Entry(item).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean AtualizarItemComRetorno(MA_ITEM item)
        {
            if (VerificarSeNomeDeItemJaExiste(item))
            {
                try
                {
                    this.Contexto.Entry(item).State = EntityState.Modified;
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception)
                {
                    return false;                        
                }                
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeNomeDeItemJaExiste(MA_ITEM item)
        {
            if (ObterItemPorNome(item) == null)
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
