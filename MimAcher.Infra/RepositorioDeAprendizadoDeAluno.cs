using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeAprendizadoDeAluno
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAprendizadoDeAluno()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<ALUNO_APRENDER> ObterTodosOsRegistros()
        {
            return this.Contexto.ALUNO_APRENDER.ToList();
        }

        public List<ALUNO_APRENDER> ObterTodosOsRegistrosDeAprendizadoDeAlunoPorLogin(String login)
        {
            return this.Contexto.ALUNO_APRENDER.Where(l => l.login.Equals(login)).ToList();
        }

        public void InserirNovoAprendizadoDeAluno(ALUNO_APRENDER alunoaprender)
        {
            this.Contexto.ALUNO_APRENDER.Add(alunoaprender);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.ALUNO_APRENDER.Count();
        }

        public void RemoverAprendizadoDeAluno(ALUNO_APRENDER alunoaprender)
        {
            this.Contexto.ALUNO_APRENDER.Remove(alunoaprender);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAprendizadoDeAluno(ALUNO_APRENDER alunoaprender)
        {
            this.Contexto.Entry(alunoaprender).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
