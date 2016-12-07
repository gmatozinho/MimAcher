using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeErro
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeErro()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_ERRO ObterErroPorId(int id)
        {
            return this.Contexto.MA_ERRO.Find(id);
        }
        
        public List<MA_ERRO> ObterTodosOsErros()
        {
            return this.Contexto.MA_ERRO.ToList();
        }

        public List<MA_ERRO> ObterTodosOsErrosPorTipo(String tipo)
        {
            return this.Contexto.MA_ERRO.Where(l => l.tipo.ToLowerInvariant().Equals(tipo.ToLowerInvariant())).ToList();
        }

        public void InserirErro(MA_ERRO Erro)
        {
            this.Contexto.MA_ERRO.Add(Erro);
            this.Contexto.SaveChanges();
        }

        public Boolean InserirErroComRetorno(MA_ERRO Erro)
        {
            try
            {
                this.Contexto.MA_ERRO.Add(Erro);
                this.Contexto.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ERRO.Count();
        }

        public void RemoverErro(MA_ERRO Erro)
        {
            this.Contexto.MA_ERRO.Remove(Erro);
            this.Contexto.SaveChanges();
        }

        public void AtualizarErro(MA_ERRO Erro)
        {        
            this.Contexto.Entry(Erro).State = EntityState.Modified;
            this.Contexto.SaveChanges();        
        }

        public Boolean AtualizarErroComRetorno(MA_ERRO Erro)
        {
            try
            {
                this.Contexto.Entry(Erro).State = EntityState.Modified;
                this.Contexto.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
    }
}
