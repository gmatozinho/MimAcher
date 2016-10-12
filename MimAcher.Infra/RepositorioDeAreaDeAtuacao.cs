using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeAreaDeAtuacao
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAreaDeAtuacao()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_AREA_ATUACAO ObterAreaDeAtuacaoPorId(int id)
        {
            return this.Contexto.MA_AREA_ATUACAO.Find(id);
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacao()
        {
            return this.Contexto.MA_AREA_ATUACAO.ToList();
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacaosPorNome(String nome)
        {
            return this.Contexto.MA_AREA_ATUACAO.Where(l => l.nome.Equals(nome)).ToList();
        }

        public void InserirAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            this.Contexto.MA_AREA_ATUACAO.Add(AreaDeAtuacao);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_AREA_ATUACAO.Count();
        }

        public void RemoverAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            this.Contexto.MA_AREA_ATUACAO.Remove(AreaDeAtuacao);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            this.Contexto.Entry(AreaDeAtuacao).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
