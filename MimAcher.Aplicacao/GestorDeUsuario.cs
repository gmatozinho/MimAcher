using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;


namespace MimAcher.Aplicacao
{
    public class GestorDeUsuario
    {
        public RepositorioDeUsuario RepositorioDeUsuario { get; set; }

        public GestorDeUsuario(){
            this.RepositorioDeUsuario = new RepositorioDeUsuario();
        }

        public List<USUARIO> ObterTodosOsUsuarios()
        {
            return this.ObterTodosOsUsuarios();
        }

        public USUARIO ObterUsuarioPorLogin(String login)
        {
            return this.RepositorioDeUsuario.ObterUsuarioPorLogin(login);
        }


        public void InserirUsuario(USUARIO usuario)
        {
            this.RepositorioDeUsuario.InserirUsuario(usuario);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeUsuario.BuscarQuantidadeRegistros();
        }

        public void RemoverUsuario(USUARIO usuario)
        {
            this.RepositorioDeUsuario.RemoverUsuario(usuario);
        }

        public void AtualizarUsuario(USUARIO usuario)
        {
            this.RepositorioDeUsuario.AtualizarUsuario(usuario);
        }
    }
}
