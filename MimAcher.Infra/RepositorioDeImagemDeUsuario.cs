using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeImagemDeUsuario
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeImagemDeUsuario()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<IMAGEM_USUARIO> ObterTodosOsImagens()
        {
            return this.Contexto.IMAGEM_USUARIO.ToList();
        }
        
        public IMAGEM_USUARIO ObterImagemPorLogin(String login)
        {
            return this.Contexto.IMAGEM_USUARIO.Where(l => l.login.Equals(login)).SingleOrDefault();
        }


        public void InserirImagem(IMAGEM_USUARIO Imagem)
        {
            this.Contexto.IMAGEM_USUARIO.Add(Imagem);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.IMAGEM_USUARIO.Count();
        }

        public void RemoverImagem(IMAGEM_USUARIO Imagem)
        {
            this.Contexto.IMAGEM_USUARIO.Remove(Imagem);
            this.Contexto.SaveChanges();
        }

        public void AtualizarImagem(IMAGEM_USUARIO Imagem)
        {
            this.Contexto.Entry(Imagem).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
