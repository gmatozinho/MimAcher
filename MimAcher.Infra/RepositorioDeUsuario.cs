using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeUsuario
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeUsuario()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_USUARIO ObterUsuarioPorId(int id)
        {
            return this.Contexto.MA_USUARIO.Find(id);
        }

        public MA_USUARIO ObterUsuarioPorEmail(MA_USUARIO usuario)
        {
            return this.Contexto.MA_USUARIO.Where(l => l.e_mail.ToLower().Equals(usuario.e_mail.ToLower())).SingleOrDefault();
        }

        public List<MA_USUARIO> ObterTodosOsUsuarios()
        {
            return this.Contexto.MA_USUARIO.ToList();
        }
        
        public MA_USUARIO ObterUsuarioPorEmail(String email)
        {
            return this.Contexto.MA_USUARIO.Where(l => l.e_mail.Equals(email)).SingleOrDefault();
        }

        public MA_USUARIO ObterUsuarioPorEmailESenha(String email, String senha)
        {
            MA_USUARIO usuario = this.Contexto.MA_USUARIO.Where(l => l.e_mail.Equals(email) && l.senha.Equals(senha)).SingleOrDefault();

            //return this.Contexto.MA_USUARIO.Where(l => l.login.Equals(login) && l.senha.Equals(senha)).SingleOrDefault();
            return usuario;
        }

        public void InserirUsuario(MA_USUARIO usuario)
        {
            if (!VerificarSeEmailDeUsuarioJaExiste(usuario))
            {
                this.Contexto.MA_USUARIO.Add(usuario);
                this.Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_USUARIO.Count();
        }

        public void RemoverUsuario(MA_USUARIO usuario)
        {
            this.Contexto.MA_USUARIO.Remove(usuario);
            this.Contexto.SaveChanges();
        }

        public void AtualizarUsuario(MA_USUARIO usuario)
        {
            if(!VerificarSeEmailDeUsuarioJaExiste(usuario))
            {
                this.Contexto.Entry(usuario).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            } 
        }

        public Boolean VerificarSeEmailDeUsuarioJaExiste(MA_USUARIO usuario)
        {
            if (ObterUsuarioPorEmail(usuario) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
