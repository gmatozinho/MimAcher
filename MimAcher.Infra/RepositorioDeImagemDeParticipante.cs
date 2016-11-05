using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
        
        public MA_IMAGEM_PARTICIPANTE ObterImagemPorIdDeParticipante(int id_participante)
        {
            return this.Contexto.MA_IMAGEM_PARTICIPANTE.Where(l => l.cod_participante == id_participante).SingleOrDefault();
        }
        
        public void InserirImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            this.Contexto.MA_IMAGEM_PARTICIPANTE.Add(Imagem);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_IMAGEM_PARTICIPANTE.Count();
        }

        public void RemoverImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            this.Contexto.MA_IMAGEM_PARTICIPANTE.Remove(Imagem);
            this.Contexto.SaveChanges();
        }

        public void AtualizarImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            this.Contexto.Entry(Imagem).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
