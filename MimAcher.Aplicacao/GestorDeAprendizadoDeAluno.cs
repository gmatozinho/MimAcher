using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeAprendizadoDeAluno
    {
        public RepositorioDeAprendizadoDeAluno RepositorioDeAprendizadoDeAluno { get; set; }

        public GestorDeAprendizadoDeAluno()
        {
            this.RepositorioDeAprendizadoDeAluno = new RepositorioDeAprendizadoDeAluno();
        }

        public List<ALUNO_APRENDER> ObterTodosOsRegistros()
        {
            return this.RepositorioDeAprendizadoDeAluno.ObterTodosOsRegistros();
        }

        public List<ALUNO_APRENDER> ObterTodosOsRegistrosDeAprendizadoDeAlunoPorLogin(String login)
        {
            return this.RepositorioDeAprendizadoDeAluno.ObterTodosOsRegistrosDeAprendizadoDeAlunoPorLogin(login);
        }

        public void InserirNovoAprendizadoDeAluno(ALUNO_APRENDER alunoaprender)
        {
            this.RepositorioDeAprendizadoDeAluno.InserirNovoAprendizadoDeAluno(alunoaprender);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAprendizadoDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverAprendizadoDeAluno(ALUNO_APRENDER alunoaprender)
        {
            this.RepositorioDeAprendizadoDeAluno.RemoverAprendizadoDeAluno(alunoaprender);
        }

        public void AtualizarAprendizadoDeAluno(ALUNO_APRENDER alunoaprender)
        {
            this.RepositorioDeAprendizadoDeAluno.AtualizarAprendizadoDeAluno(alunoaprender);
        }
    }

}
