using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeGostoDeAluno
    {
        public RepositorioDeGostoDeAluno RepositorioDeGostoDeAluno { get; set; }

        public GestorDeGostoDeAluno()
        {
            this.RepositorioDeGostoDeAluno = new RepositorioDeGostoDeAluno();
        }

        public List<ALUNO_GOSTO> ObterTodosOsRegistros()
        {
            return this.RepositorioDeGostoDeAluno.ObterTodosOsRegistros();
        }

        public List<ALUNO_GOSTO> ObterTodosOsRegistrosDeGostoDeAlunoPorLogin(String login)
        {
            return this.RepositorioDeGostoDeAluno.ObterTodosOsRegistrosDeGostoDeAlunoPorLogin(login);
        }

        public void InserirNovoGostoDeAluno(ALUNO_GOSTO gostoaluno)
        {
            this.RepositorioDeGostoDeAluno.InserirNovoGostoDeAluno(gostoaluno);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeGostoDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverGostoDeAluno(ALUNO_GOSTO gostoaluno)
        {
            this.RepositorioDeGostoDeAluno.RemoverGostoDeAluno(gostoaluno);
        }

        public void AtualizarGostoDeAluno(ALUNO_GOSTO gostoaluno)
        {
            this.RepositorioDeGostoDeAluno.AtualizarGostoDeAluno(gostoaluno);
        }
    }
}
