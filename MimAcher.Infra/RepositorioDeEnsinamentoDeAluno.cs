using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeEnsinamentoDeAluno
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeEnsinamentoDeAluno()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<ALUNO_ENSINAR> ObterTodosOsRegistros()
        {
            return this.Contexto.ALUNO_ENSINAR  .ToList();
        }

        public List<ALUNO_ENSINAR> ObterTodosOsRegistrosDeEnsinamentoDeAlunoPorLogin(String login)
        {
            return this.Contexto.ALUNO_ENSINAR.Where(l => l.login.Equals(login)).ToList();
        }

        public void InserirNovoEnsinamentoDeAluno(ALUNO_ENSINAR alunoensinar)
        {
            this.Contexto.ALUNO_ENSINAR.Add(alunoensinar);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.ALUNO_ENSINAR.Count();
        }

        public void RemoverEnsinamentoDeAluno(ALUNO_ENSINAR alunoensinar)
        {
            this.Contexto.ALUNO_ENSINAR.Remove(alunoensinar);
            this.Contexto.SaveChanges();
        }

        public void AtualizarEnsinamentoDeAluno(ALUNO_ENSINAR alunoensinar)
        {
            this.Contexto.Entry(alunoensinar).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
