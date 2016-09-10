using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeEnsinoDeAluno
    {
        public RepositorioDeEnsinoDeAluno RepositorioDeEnsinoDeAluno { get; set; }

        public GestorDeEnsinoDeAluno()
        {
            this.RepositorioDeEnsinoDeAluno = new RepositorioDeEnsinoDeAluno();
        }

        public MA_ALUNO_ENSINAR ObterRelacaoDoQueOAlunoEnsinaPorId(int id)
        {
            return this.RepositorioDeEnsinoDeAluno.ObterRelacaoDoQueOAlunoEnsinaPorId(id);
        }

        public List<MA_ALUNO_ENSINAR> ObterTodosOsRegistros()
        {
            return this.RepositorioDeEnsinoDeAluno.ObterTodosOsRegistros();
        }

        public void InserirNovoEnsinamentoDeAluno(MA_ALUNO_ENSINAR alunoensinar)
        {
            this.RepositorioDeEnsinoDeAluno.InserirNovoEnsinamentoDeAluno(alunoensinar);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeEnsinoDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverEnsinamentoDeAluno(MA_ALUNO_ENSINAR alunoensinar)
        {
            this.RepositorioDeEnsinoDeAluno.RemoverEnsinamentoDeAluno(alunoensinar);
        }

        public void AtualizarEnsinamentoDeAluno(MA_ALUNO_ENSINAR alunoensinar)
        {
            this.RepositorioDeEnsinoDeAluno.AtualizarEnsinamentoDeAluno(alunoensinar);
        }
    }
}
