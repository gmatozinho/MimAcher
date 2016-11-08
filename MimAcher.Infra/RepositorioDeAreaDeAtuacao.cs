using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeAreaDeAtuacao
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAreaDeAtuacao()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_AREA_ATUACAO ObterAreaDeAtuacaoPorId(int id)
        {
            return Contexto.MA_AREA_ATUACAO.Find(id);
        }

        public MA_AREA_ATUACAO ObterAreaDeAtuacaoPorNome(MA_AREA_ATUACAO areaatuacao)
        {
            return Contexto.MA_AREA_ATUACAO.Where(l => l.nome.ToLowerInvariant().Equals(areaatuacao.nome.ToLowerInvariant())).SingleOrDefault();
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacao()
        {
            return Contexto.MA_AREA_ATUACAO.ToList();
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacaosPorNome(String nome)
        {
            return Contexto.MA_AREA_ATUACAO.Where(l => l.nome.Equals(nome)).ToList();
        }

        public void InserirAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            if (!VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(AreaDeAtuacao))
            {
                Contexto.MA_AREA_ATUACAO.Add(AreaDeAtuacao);
                Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_AREA_ATUACAO.Count();
        }

        public void RemoverAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            Contexto.MA_AREA_ATUACAO.Remove(AreaDeAtuacao);
            Contexto.SaveChanges();
        }

        public void AtualizarAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            if (!VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(AreaDeAtuacao))
            {
                Contexto.Entry(AreaDeAtuacao).State = EntityState.Modified;
                Contexto.SaveChanges();
            }            
        }

        public Boolean VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(MA_AREA_ATUACAO areaatuacao)
        {
            if (ObterAreaDeAtuacaoPorNome(areaatuacao) != null) {
                return true;
            }
            return false;
        }
    }
}
