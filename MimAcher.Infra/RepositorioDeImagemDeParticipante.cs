using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeImagemDeParticipante
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeImagemDeParticipante()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_IMAGEM_PARTICIPANTE ObterImagemDeParticipantePorId(int id)
        {
            return this.Contexto.MA_IMAGEM_PARTICIPANTE.Find(id);
        }

        public List<MA_IMAGEM_PARTICIPANTE> ObterTodosOsImagens()
        {
            return this.Contexto.MA_IMAGEM_PARTICIPANTE.ToList();
        }

        public MA_IMAGEM_PARTICIPANTE ObterImagemPorIdDeParticipante(int idParticipante)
        {
            return this.Contexto.MA_IMAGEM_PARTICIPANTE.Where(l => l.cod_participante == idParticipante).SingleOrDefault();
        }

        public void InserirImagem(MA_IMAGEM_PARTICIPANTE imagem)
        {
            this.Contexto.MA_IMAGEM_PARTICIPANTE.Add(imagem);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_IMAGEM_PARTICIPANTE.Count();
        }

        public void RemoverImagem(MA_IMAGEM_PARTICIPANTE imagem)
        {
            this.Contexto.MA_IMAGEM_PARTICIPANTE.Remove(imagem);
            this.Contexto.SaveChanges();
        }

        public void AtualizarImagem(MA_IMAGEM_PARTICIPANTE imagem)
        {
            this.Contexto.Entry(imagem).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
