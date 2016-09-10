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

        public MA_ALUNO_APRENDER ObterAprendizadoDoAlunoPorId(int id)
        {
            return this.RepositorioDeAprendizadoDeAluno.ObterAprendizadoDoAlunoPorId(id);
        }

        public List<MA_ALUNO_APRENDER> ObterTodosOsRegistros()
        {
            return this.RepositorioDeAprendizadoDeAluno.ObterTodosOsRegistros();
        }

        public void InserirNovoAprendizadoDeAluno(MA_ALUNO_APRENDER alunoaprender)
        {
            this.RepositorioDeAprendizadoDeAluno.InserirNovoAprendizadoDeAluno(alunoaprender);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAprendizadoDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverAprendizadoDeAluno(MA_ALUNO_APRENDER alunoaprender)
        {
            this.RepositorioDeAprendizadoDeAluno.RemoverAprendizadoDeAluno(alunoaprender);
        }

        public void AtualizarAprendizadoDeAluno(MA_ALUNO_APRENDER alunoaprender)
        {
            this.RepositorioDeAprendizadoDeAluno.AtualizarAprendizadoDeAluno(alunoaprender);
        }
    }

}
