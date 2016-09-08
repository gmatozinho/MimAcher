using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeAluno
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAluno()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<ALUNO> ObterTodosOsAlunos()
        {
            return this.Contexto.ALUNO.ToList();
        }

        public List<ALUNO> ObterTodosOsAlunosPorNome(String nome)
        {
            return this.Contexto.ALUNO.Where(l => l.nome.Equals(nome)).ToList();            
        }

        public ALUNO ObterAlunoPorLogin(String login)
        {
            return this.Contexto.ALUNO.Where(l => l.login.Equals(login)).SingleOrDefault();
        }

        
        public void InserirAluno(ALUNO Aluno)
        {            
            this.Contexto.ALUNO.Add(Aluno);
            this.Contexto.SaveChanges();         
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.ALUNO.Count();
        }
                
        public void RemoverAluno(ALUNO Aluno)
        {
            this.Contexto.ALUNO.Remove(Aluno);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAluno(ALUNO Aluno)
        {            
            this.Contexto.Entry(Aluno).State = EntityState.Modified;
            this.Contexto.SaveChanges();            
        }
    }
}
