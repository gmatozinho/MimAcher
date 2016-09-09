using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeMA_USUARIO
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeMA_USUARIO()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_USUARIO ObterUsuarioPorId(int id)
        {
            return this.Contexto.MA_USUARIO.Find(id);
        }

        public List<MA_USUARIO> ObterTodosOsMA_USUARIOs()
        {
            return this.Contexto.MA_USUARIO.ToList();
        }
        
        public MA_USUARIO ObterMA_USUARIOPorLogin(String login)
        {
            return this.Contexto.MA_USUARIO.Where(l => l.login.Equals(login)).SingleOrDefault();
        }


        public void InserirMA_USUARIO(MA_USUARIO MA_USUARIO)
        {
            this.Contexto.MA_USUARIO.Add(MA_USUARIO);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_USUARIO.Count();
        }

        public void RemoverMA_USUARIO(MA_USUARIO MA_USUARIO)
        {
            this.Contexto.MA_USUARIO.Remove(MA_USUARIO);
            this.Contexto.SaveChanges();
        }

        public void AtualizarMA_USUARIO(MA_USUARIO MA_USUARIO)
        {
            this.Contexto.Entry(MA_USUARIO).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
