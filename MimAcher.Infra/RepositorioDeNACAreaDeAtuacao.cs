using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeNACAreaDeAtuacao
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeNACAreaDeAtuacao()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_NAC_AREA_ATUACAO ObterNACAreaDeAtuacaoPorId(int id)
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Find(id);
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACAreasDeAtuacao()
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.ToList();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeAreaDeAtuacao(String nome)
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.MA_AREA_ATUACAO.nome.Equals(nome)).ToList();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeRepresentanteDoNAC(String nomerepresentante)
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.MA_NAC.nome_representante.Equals(nomerepresentante)).ToList();
        }

        public void InserirNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            this.Contexto.MA_NAC_AREA_ATUACAO.Add(NACAreaDeAtuacao);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Count();
        }

        public void RemoverNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            this.Contexto.MA_NAC_AREA_ATUACAO.Remove(NACAreaDeAtuacao);
            this.Contexto.SaveChanges();
        }

        public void AtualizarNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            this.Contexto.Entry(NACAreaDeAtuacao).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
