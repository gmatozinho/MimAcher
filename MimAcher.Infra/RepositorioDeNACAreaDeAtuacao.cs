using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeNACAreaDeAtuacao
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeNACAreaDeAtuacao()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_NAC_AREA_ATUACAO ObterNACAreaDeAtuacaoPorId(int id)
        {
            return Contexto.MA_NAC_AREA_ATUACAO.Find(id);
        }

        public MA_NAC_AREA_ATUACAO ObterNACAreaAtuacaoPorNACEAreaDeAtuacao(MA_NAC_AREA_ATUACAO nacareaatuacao)
        {
            return Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.cod_nac == nacareaatuacao.cod_nac && l.cod_nac_area_atuacao == nacareaatuacao.cod_nac_area_atuacao).SingleOrDefault();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACAreasDeAtuacao()
        {
            return Contexto.MA_NAC_AREA_ATUACAO.ToList();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeAreaDeAtuacao(String nome)
        {
            return Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.MA_AREA_ATUACAO.nome.Equals(nome)).ToList();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeRepresentanteDoNAC(String nomerepresentante)
        {
            return Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.MA_NAC.nome_representante.Equals(nomerepresentante)).ToList();
        }

        public void InserirNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            if (!VerificarSeExisteRelacaoDeNACAreaDeAtuacao(NACAreaDeAtuacao))
            {
                Contexto.MA_NAC_AREA_ATUACAO.Add(NACAreaDeAtuacao);
                Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_NAC_AREA_ATUACAO.Count();
        }

        public void RemoverNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            Contexto.MA_NAC_AREA_ATUACAO.Remove(NACAreaDeAtuacao);
            Contexto.SaveChanges();
        }

        public void AtualizarNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            if (!VerificarSeExisteRelacaoDeNACAreaDeAtuacao(NACAreaDeAtuacao))
            {
                Contexto.Entry(NACAreaDeAtuacao).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeExisteRelacaoDeNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO nacareaatuacao)
        {
            if (ObterNACAreaAtuacaoPorNACEAreaDeAtuacao(nacareaatuacao) != null)
            {
                return true;
            }
            return false;
        }
    }
}
