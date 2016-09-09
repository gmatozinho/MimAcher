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

        public MA_ALUNO ObterAlunoPorId(int id)
        {
            return this.Contexto.MA_ALUNO.Find(id);
        }

        public List<MA_ALUNO> ObterTodosOsAlunos()
        {
            return this.Contexto.MA_ALUNO.ToList();
        }

        public List<MA_ALUNO> ObterTodosOsAlunosPorNome(String nome)
        {
            return this.Contexto.MA_ALUNO.Where(l => l.nome.Equals(nome)).ToList();            
        }

        public MA_ALUNO ObterAlunoPorLogin(String login)
        {
            return this.Contexto.MA_ALUNO.Where(l => l.MA_USUARIO.login.Equals(login)).SingleOrDefault();
        }
        
        public void InserirAluno(MA_ALUNO Aluno)
        {            
            this.Contexto.MA_ALUNO.Add(Aluno);
            this.Contexto.SaveChanges();         
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ALUNO.Count();
        }
                
        public void RemoverAluno(MA_ALUNO Aluno)
        {
            this.Contexto.MA_ALUNO.Remove(Aluno);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAluno(MA_ALUNO Aluno)
        {            
            this.Contexto.Entry(Aluno).State = EntityState.Modified;
            this.Contexto.SaveChanges();            
        }
    }
}
