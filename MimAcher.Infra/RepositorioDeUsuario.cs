using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeUsuario
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeUsuario()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_USUARIO ObterUsuarioPorId(int id)
        {
            return Contexto.MA_USUARIO.Find(id);
        }

        public MA_USUARIO ObterUsuarioPorEmail(MA_USUARIO usuario)
        {
            return Contexto.MA_USUARIO.Where(l => l.e_mail.ToLower().Equals(usuario.e_mail.ToLower())).SingleOrDefault();
        }

        public List<MA_USUARIO> ObterTodosOsUsuarios()
        {
            return Contexto.MA_USUARIO.ToList();
        }
        
        public MA_USUARIO ObterUsuarioPorEmail(String email)
        {
            return Contexto.MA_USUARIO.Where(l => l.e_mail.Equals(email)).SingleOrDefault();
        }

        public MA_USUARIO ObterUsuarioPorEmailESenha(String email, String senha)
        {
            return Contexto.MA_USUARIO.Where(l => l.e_mail.ToLowerInvariant().Equals(email) && l.senha.ToLowerInvariant().Equals(senha)).SingleOrDefault();            
        }

        public void InserirUsuario(MA_USUARIO usuario)
        {
            if (!VerificarSeEmailDeUsuarioJaExiste(usuario))
            {
                Contexto.MA_USUARIO.Add(usuario);
                Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_USUARIO.Count();
        }

        public void RemoverUsuario(MA_USUARIO usuario)
        {
            Contexto.MA_USUARIO.Remove(usuario);
            Contexto.SaveChanges();
        }

        public void AtualizarUsuario(MA_USUARIO usuario)
        {
            if(!VerificarSeEmailDeUsuarioJaExiste(usuario))
            {
                Contexto.Entry(usuario).State = EntityState.Modified;
                Contexto.SaveChanges();
            } 
        }

        public Boolean VerificarSeEmailDeUsuarioJaExiste(MA_USUARIO usuario)
        {
            if (ObterUsuarioPorEmail(usuario) != null)
            {
                return true;
            }
            return false;
        }
    }
}
