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

        public MA_ALUNO_GOSTO ObterGostoDoAlunoPorId(int id)
        {
            return this.RepositorioDeGostoDeAluno.ObterGostoDoAlunoPorId(id);
        }

        public List<MA_ALUNO_GOSTO> ObterTodosOsRegistros()
        {
            return this.RepositorioDeGostoDeAluno.ObterTodosOsRegistros();
        }

        public void InserirNovoGostoDeAluno(MA_ALUNO_GOSTO gostoaluno)
        {
            this.RepositorioDeGostoDeAluno.InserirNovoGostoDeAluno(gostoaluno);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeGostoDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverGostoDeAluno(MA_ALUNO_GOSTO gostoaluno)
        {
            this.RepositorioDeGostoDeAluno.RemoverGostoDeAluno(gostoaluno);
        }

        public void AtualizarGostoDeAluno(MA_ALUNO_GOSTO gostoaluno)
        {
            this.RepositorioDeGostoDeAluno.AtualizarGostoDeAluno(gostoaluno);
        }
    }
}
