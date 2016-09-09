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

        public MA_ALUNO_GOSTO ObterGostoDoAlunoPorId(int id)
        {
            return this.Contexto.MA_ALUNO_GOSTO.Find(id);
        }

        public List<MA_ALUNO_GOSTO> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_ALUNO_GOSTO.ToList();
        }
                
        public void InserirNovoGostoDeAluno(MA_ALUNO_GOSTO gostoaluno)
        {
            this.Contexto.MA_ALUNO_GOSTO.Add(gostoaluno);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ALUNO_GOSTO.Count();
        }

        public void RemoverGostoDeAluno(MA_ALUNO_GOSTO gostoaluno)
        {
            this.Contexto.MA_ALUNO_GOSTO.Remove(gostoaluno);
            this.Contexto.SaveChanges();
        }

        public void AtualizarGostoDeAluno(MA_ALUNO_GOSTO gostoaluno)
        {
            this.Contexto.Entry(gostoaluno).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
