using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeEnsinoDeAluno
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeEnsinoDeAluno()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_ALUNO_ENSINAR ObterRelacaoDoQueOAlunoEnsinaPorId(int id)
        {
            return this.Contexto.MA_ALUNO_ENSINAR.Find(id);
        }

        public List<MA_ALUNO_ENSINAR> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_ALUNO_ENSINAR  .ToList();
        }
        
        public void InserirNovoEnsinamentoDeAluno(MA_ALUNO_ENSINAR alunoensinar)
        {
            this.Contexto.MA_ALUNO_ENSINAR.Add(alunoensinar);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ALUNO_ENSINAR.Count();
        }

        public void RemoverEnsinamentoDeAluno(MA_ALUNO_ENSINAR alunoensinar)
        {
            this.Contexto.MA_ALUNO_ENSINAR.Remove(alunoensinar);
            this.Contexto.SaveChanges();
        }

        public void AtualizarEnsinamentoDeAluno(MA_ALUNO_ENSINAR alunoensinar)
        {
            this.Contexto.Entry(alunoensinar).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
