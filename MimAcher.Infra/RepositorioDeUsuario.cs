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

        public List<USUARIO> ObterTodosOsUsuarios()
        {
            return this.Contexto.USUARIO.ToList();
        }
        
        public USUARIO ObterUsuarioPorLogin(String login)
        {
            return this.Contexto.USUARIO.Where(l => l.login.Equals(login)).SingleOrDefault();
        }


        public void InserirUsuario(USUARIO Usuario)
        {
            this.Contexto.USUARIO.Add(Usuario);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.USUARIO.Count();
        }

        public void RemoverUsuario(USUARIO Usuario)
        {
            this.Contexto.USUARIO.Remove(Usuario);
            this.Contexto.SaveChanges();
        }

        public void AtualizarUsuario(USUARIO Usuario)
        {
            this.Contexto.Entry(Usuario).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
