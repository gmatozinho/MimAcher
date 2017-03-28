using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

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

        public MA_IMAGEM_PARTICIPANTE ObterImagemPorIdDeParticipante(int idParticipante)
        {
            return this.RepositorioDeImagemDeParticipante.ObterImagemPorIdDeParticipante(idParticipante);
        }

        public void InserirImagem(MA_IMAGEM_PARTICIPANTE imagem)
        {
            this.RepositorioDeImagemDeParticipante.InserirImagem(imagem);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeImagemDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverImagem(MA_IMAGEM_PARTICIPANTE imagem)
        {
            this.RepositorioDeImagemDeParticipante.RemoverImagem(imagem);
        }

        public void AtualizarImagem(MA_IMAGEM_PARTICIPANTE imagem)
        {
            this.RepositorioDeImagemDeParticipante.AtualizarImagem(imagem);
        }
    }
}
