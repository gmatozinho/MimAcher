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

        public MA_USUARIO ObterUsuarioPorId(int id)
        {
            return this.RepositorioDeUsuario.ObterUsuarioPorId(id);
        }

        public List<MA_USUARIO> ObterTodosOsUsuarios()
        {
            return this.RepositorioDeUsuario.ObterTodosOsUsuarios();
        }

        public MA_USUARIO ObterUsuarioPorEmail(String email)
        {
            return this.RepositorioDeUsuario.ObterUsuarioPorEmail(email);
        }

        public MA_USUARIO ObterUsuarioPorEmailESenha(String email, String senha)
        {
            return this.RepositorioDeUsuario.ObterUsuarioPorEmailESenha(email, senha);
        }

        public Boolean VerificarExistenciaDeUsuarioPorEmailESenha(String email, String senha)
        {
            if(ObterUsuarioPorEmailESenha(email, senha) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeUsuarioTemVinculoComParticipante(MA_USUARIO usuario)
        {
            if(usuario.MA_PARTICIPANTE != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeUsuarioTemVinculoComNAC(MA_USUARIO usuario)
        {
            if (usuario.MA_NAC != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InserirUsuario(MA_USUARIO usuario)
        {
            this.RepositorioDeUsuario.InserirUsuario(usuario);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeUsuario.BuscarQuantidadeRegistros();
        }

        public void RemoverUsuario(MA_USUARIO usuario)
        {
            this.RepositorioDeUsuario.RemoverUsuario(usuario);
        }

        public void AtualizarUsuario(MA_USUARIO usuario)
        {
            this.RepositorioDeUsuario.AtualizarUsuario(usuario);
        }
    }
}
