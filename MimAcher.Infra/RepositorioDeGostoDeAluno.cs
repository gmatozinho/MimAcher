using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeGostoDeAluno
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeGostoDeAluno()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<ALUNO_GOSTO> ObterTodosOsRegistros()
        {
            return this.Contexto.ALUNO_GOSTO.ToList();
        }

        public List<ALUNO_GOSTO> ObterTodosOsRegistrosDeGostoDeAlunoPorLogin(String login)
        {
            return this.Contexto.ALUNO_GOSTO.Where(l => l.login.Equals(login)).ToList();
        }

        public void InserirNovoGostoDeAluno(ALUNO_GOSTO gostoaluno)
        {
            this.Contexto.ALUNO_GOSTO.Add(gostoaluno);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.ALUNO_GOSTO.Count();
        }

        public void RemoverGostoDeAluno(ALUNO_GOSTO gostoaluno)
        {
            this.Contexto.ALUNO_GOSTO.Remove(gostoaluno);
            this.Contexto.SaveChanges();
        }

        public void AtualizarGostoDeAluno(ALUNO_GOSTO gostoaluno)
        {
            this.Contexto.Entry(gostoaluno).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
