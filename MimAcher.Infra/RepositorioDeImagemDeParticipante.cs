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
            Contexto = new MIMACHEREntities();
        }

        public MA_IMAGEM_PARTICIPANTE ObterImagemDeParticipantePorId(int id)
        {
            return Contexto.MA_IMAGEM_PARTICIPANTE.Find(id);
        }

        public List<MA_IMAGEM_PARTICIPANTE> ObterTodosOsImagens()
        {
            return Contexto.MA_IMAGEM_PARTICIPANTE.ToList();
        }
        
        public MA_IMAGEM_PARTICIPANTE ObterImagemPorIdDeParticipante(int id_participante)
        {
            return Contexto.MA_IMAGEM_PARTICIPANTE.Where(l => l.cod_participante == id_participante).SingleOrDefault();
        }
        
        public void InserirImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            Contexto.MA_IMAGEM_PARTICIPANTE.Add(Imagem);
            Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_IMAGEM_PARTICIPANTE.Count();
        }

        public void RemoverImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            Contexto.MA_IMAGEM_PARTICIPANTE.Remove(Imagem);
            Contexto.SaveChanges();
        }

        public void AtualizarImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            Contexto.Entry(Imagem).State = EntityState.Modified;
            Contexto.SaveChanges();
        }
    }
}
