using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeNacAreaDeAtuacao
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeNacAreaDeAtuacao()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_NAC_AREA_ATUACAO ObterNacAreaDeAtuacaoPorId(int id)
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Find(id);
        }

        public MA_NAC_AREA_ATUACAO ObterNacAreaAtuacaoPorNacEAreaDeAtuacao(MA_NAC_AREA_ATUACAO nacareaatuacao)
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.cod_nac == nacareaatuacao.cod_nac && l.cod_nac_area_atuacao == nacareaatuacao.cod_nac_area_atuacao).SingleOrDefault();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNacAreasDeAtuacao()
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.ToList();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNacsAreasDeAtuacaosPorNomeDeAreaDeAtuacao(String nome)
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.MA_AREA_ATUACAO.nome.Equals(nome)).ToList();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNacsAreasDeAtuacaosPorNomeDeRepresentanteDoNac(String nomerepresentante)
        {
            return this.Contexto.MA_NAC_AREA_ATUACAO.Where(l => l.MA_NAC.nome_representante.Equals(nomerepresentante)).ToList();
        }

        public void InserirNacAreaDeAtuacao(MA_NAC_AREA_ATUACAO NacAreaDeAtuacao)
        {
            if (!VerificarSeExisteRelacaoDeNacAreaDeAtuacao(NacAreaDeAtuacao))
            {
                this.Contexto.MA_NAC_AREA_ATUACAO.Add(NacAreaDeAtuacao);
                this.Contexto.SaveChanges();
            }
        }

        public Boolean InserirNacAreaDeAtuacaoComRetorno(MA_NAC_AREA_ATUACAO NacAreaDeAtuacao)
        {
            if (!VerificarSeExisteRelacaoDeNacAreaDeAtuacao(NacAreaDeAtuacao))
            {
                try
                {
                    this.Contexto.MA_NAC_AREA_ATUACAO.Add(NacAreaDeAtuacao);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception e)
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
            return this.Contexto.MA_NAC_AREA_ATUACAO.Count();
        }

        public void RemoverNacAreaDeAtuacao(MA_NAC_AREA_ATUACAO NacAreaDeAtuacao)
        {
            this.Contexto.MA_NAC_AREA_ATUACAO.Remove(NacAreaDeAtuacao);
            this.Contexto.SaveChanges();
        }

        public void AtualizarNacAreaDeAtuacao(MA_NAC_AREA_ATUACAO NacAreaDeAtuacao)
        {
            if (!VerificarSeExisteRelacaoDeNacAreaDeAtuacao(NacAreaDeAtuacao))
            {
                this.Contexto.Entry(NacAreaDeAtuacao).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean AtualizarNacAreaDeAtuacaoComRetorno(MA_NAC_AREA_ATUACAO NacAreaDeAtuacao)
        {
            if (!VerificarSeExisteRelacaoDeNacAreaDeAtuacao(NacAreaDeAtuacao))
            {
                try
                {
                    this.Contexto.Entry(NacAreaDeAtuacao).State = EntityState.Modified;
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeExisteRelacaoDeNacAreaDeAtuacao(MA_NAC_AREA_ATUACAO nacareaatuacao)
        {
            if (ObterNacAreaAtuacaoPorNacEAreaDeAtuacao(nacareaatuacao) != null)
            {
                return true;
            }
            return false;
        }
    }
}
