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

        public List<IMAGEM_USUARIO> ObterTodosOsImagens()
        {
            return this.RepositorioDeImagemDeUsuario.ObterTodosOsImagens();
        }

        public IMAGEM_USUARIO ObterImagemPorLogin(String login)
        {
            return this.RepositorioDeImagemDeUsuario.ObterImagemPorLogin(login);
        }


        public void InserirImagem(IMAGEM_USUARIO imagem)
        {
            this.RepositorioDeImagemDeUsuario.InserirImagem(imagem);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeImagemDeUsuario.BuscarQuantidadeRegistros();
        }

        public void RemoverImagem(IMAGEM_USUARIO imagem)
        {
            this.RepositorioDeImagemDeUsuario.RemoverImagem(imagem);
        }

        public void AtualizarImagem(IMAGEM_USUARIO imagem)
        {
            this.RepositorioDeImagemDeUsuario.AtualizarImagem(imagem);
        }
    }
}
