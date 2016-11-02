using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;
using MimAcher.Dominio;

namespace MimAcher.Aplicacao
{
    public class GestorDeImagemDeParticipante
    {
        public RepositorioDeImagemDeParticipante RepositorioDeImagemDeParticipante { get; set; }

        public GestorDeImagemDeParticipante()
        {
            this.RepositorioDeImagemDeParticipante = new RepositorioDeImagemDeParticipante();
        }

        public MA_IMAGEM_PARTICIPANTE ObterImagemDeParticipantePorId(int id)
        {
            return this.RepositorioDeImagemDeParticipante.ObterImagemDeParticipantePorId(id);
        }

        public List<MA_IMAGEM_PARTICIPANTE> ObterTodosOsImagens()
        {
            return this.RepositorioDeImagemDeParticipante.ObterTodosOsImagens();
        }

        public MA_IMAGEM_PARTICIPANTE ObterImagemPorIdDeParticipante(int id_participante)
        {
            return this.RepositorioDeImagemDeParticipante.ObterImagemPorIdDeParticipante(id_participante);
        }

        public void InserirImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            this.RepositorioDeImagemDeParticipante.InserirImagem(Imagem);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeImagemDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            this.RepositorioDeImagemDeParticipante.RemoverImagem(Imagem);
        }

        public void AtualizarImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            this.RepositorioDeImagemDeParticipante.AtualizarImagem(Imagem);
        }
    }
}
