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
            RepositorioDeImagemDeParticipante = new RepositorioDeImagemDeParticipante();
        }

        public MA_IMAGEM_PARTICIPANTE ObterImagemDeParticipantePorId(int id)
        {
            return RepositorioDeImagemDeParticipante.ObterImagemDeParticipantePorId(id);
        }

        public List<MA_IMAGEM_PARTICIPANTE> ObterTodosOsImagens()
        {
            return RepositorioDeImagemDeParticipante.ObterTodosOsImagens();
        }

        public MA_IMAGEM_PARTICIPANTE ObterImagemPorIdDeParticipante(int id_participante)
        {
            return RepositorioDeImagemDeParticipante.ObterImagemPorIdDeParticipante(id_participante);
        }

        public void InserirImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            RepositorioDeImagemDeParticipante.InserirImagem(Imagem);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeImagemDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            RepositorioDeImagemDeParticipante.RemoverImagem(Imagem);
        }

        public void AtualizarImagem(MA_IMAGEM_PARTICIPANTE Imagem)
        {
            RepositorioDeImagemDeParticipante.AtualizarImagem(Imagem);
        }
    }
}
