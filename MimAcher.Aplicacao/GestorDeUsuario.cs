using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeUsuario
    {
        public RepositorioDeUsuario RepositorioDeUsuario { get; set; }

        public GestorDeUsuario(){
            RepositorioDeUsuario = new RepositorioDeUsuario();
        }

        public MA_USUARIO ObterUsuarioPorId(int id)
        {
            return RepositorioDeUsuario.ObterUsuarioPorId(id);
        }

        public List<MA_USUARIO> ObterTodosOsUsuarios()
        {
            return RepositorioDeUsuario.ObterTodosOsUsuarios();
        }

        public MA_USUARIO ObterUsuarioPorEmail(String email)
        {
            return RepositorioDeUsuario.ObterUsuarioPorEmail(email);
        }

        public MA_USUARIO ObterUsuarioPorEmailESenha(String email, String senha)
        {
            return RepositorioDeUsuario.ObterUsuarioPorEmailESenha(email, senha);
        }

        public Boolean VerificarExistenciaDeUsuarioPorEmailESenha(String email, String senha)
        {
            if(ObterUsuarioPorEmailESenha(email, senha) != null)
            {
                return true;
            }
            return false;
        }
        
        public void InserirUsuario(MA_USUARIO usuario)
        {
            RepositorioDeUsuario.InserirUsuario(usuario);
        }

        public Boolean InserirUsuarioComRetorno(MA_USUARIO usuario)
        {
            return RepositorioDeUsuario.InserirUsuarioComRetorno(usuario);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeUsuario.BuscarQuantidadeRegistros();
        }

        public void RemoverUsuario(MA_USUARIO usuario)
        {
            RepositorioDeUsuario.RemoverUsuario(usuario);
        }

        public void AtualizarUsuario(MA_USUARIO usuario)
        {
            RepositorioDeUsuario.AtualizarUsuario(usuario);
        }
    }
}
