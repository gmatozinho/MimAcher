using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeEnsinamentoDeAluno
    {
        public RepositorioDeEnsinamentoDeAluno RepositorioDeEnsinamentoDeAluno { get; set; }

        public GestorDeEnsinamentoDeAluno()
        {
            this.RepositorioDeEnsinamentoDeAluno = new RepositorioDeEnsinamentoDeAluno();
        }

        public List<ALUNO_ENSINAR> ObterTodosOsRegistros()
        {
            return this.RepositorioDeEnsinamentoDeAluno.ObterTodosOsRegistros();
        }

        public List<ALUNO_ENSINAR> ObterTodosOsRegistrosDeEnsinamentoDeAlunoPorLogin(String login)
        {
            return this.RepositorioDeEnsinamentoDeAluno.ObterTodosOsRegistrosDeEnsinamentoDeAlunoPorLogin(login);
        }

        public void InserirNovoEnsinamentoDeAluno(ALUNO_ENSINAR alunoensinar)
        {
            this.RepositorioDeEnsinamentoDeAluno.InserirNovoEnsinamentoDeAluno(alunoensinar);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeEnsinamentoDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverEnsinamentoDeAluno(ALUNO_ENSINAR alunoensinar)
        {
            this.RepositorioDeEnsinamentoDeAluno.RemoverEnsinamentoDeAluno(alunoensinar);
        }

        public void AtualizarEnsinamentoDeAluno(ALUNO_ENSINAR alunoensinar)
        {
            this.RepositorioDeEnsinamentoDeAluno.AtualizarEnsinamentoDeAluno(alunoensinar);
        }
    }
}
