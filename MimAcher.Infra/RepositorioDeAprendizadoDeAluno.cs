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

        public MA_ALUNO_APRENDER ObterAprendizadoDoAlunoPorId(int id)
        {
            return this.Contexto.MA_ALUNO_APRENDER.Find(id);
        }

        public List<MA_ALUNO_APRENDER> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_ALUNO_APRENDER.ToList();
        }

        public void InserirNovoAprendizadoDeAluno(MA_ALUNO_APRENDER alunoaprender)
        {
            this.Contexto.MA_ALUNO_APRENDER.Add(alunoaprender);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ALUNO_APRENDER.Count();
        }

        public void RemoverAprendizadoDeAluno(MA_ALUNO_APRENDER alunoaprender)
        {
            this.Contexto.MA_ALUNO_APRENDER.Remove(alunoaprender);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAprendizadoDeAluno(MA_ALUNO_APRENDER alunoaprender)
        {
            this.Contexto.Entry(alunoaprender).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
