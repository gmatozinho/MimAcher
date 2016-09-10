using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeImagemDeUsuario
    {
        public RepositorioDeImagemDeUsuario RepositorioDeImagemDeUsuario { get; set; }

        public GestorDeImagemDeUsuario()
        {
            this.RepositorioDeImagemDeUsuario = new RepositorioDeImagemDeUsuario();
        }

        public MA_IMAGEM_USUARIO ObterImagemDeUsuarioPorId(int id)
        {
            return this.RepositorioDeImagemDeUsuario.ObterImagemDeUsuarioPorId(id);
        }

        public List<MA_IMAGEM_USUARIO> ObterTodosOsImagens()
        {
            return this.RepositorioDeImagemDeUsuario.ObterTodosOsImagens();
        }

        public MA_IMAGEM_USUARIO ObterImagemPorIdDeUsuario(int id_usuario)
        {
            return this.RepositorioDeImagemDeUsuario.ObterImagemPorIdDeUsuario(id_usuario);
        }

        public void InserirImagem(MA_IMAGEM_USUARIO Imagem)
        {
            this.RepositorioDeImagemDeUsuario.InserirImagem(Imagem);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeImagemDeUsuario.BuscarQuantidadeRegistros();
        }

        public void RemoverImagem(MA_IMAGEM_USUARIO Imagem)
        {
            this.RepositorioDeImagemDeUsuario.RemoverImagem(Imagem);
        }

        public void AtualizarImagem(MA_IMAGEM_USUARIO Imagem)
        {
            this.RepositorioDeImagemDeUsuario.AtualizarImagem(Imagem);
        }
    }
}
