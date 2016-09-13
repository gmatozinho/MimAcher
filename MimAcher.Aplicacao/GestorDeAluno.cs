using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeAluno
    {
        public RepositorioDeAluno RepositorioDeAluno { get; set; }

        public GestorDeAluno()
        {
            this.RepositorioDeAluno = new RepositorioDeAluno();
        }
        
        public MA_ALUNO ObterAlunoPorId(int id)
        {
            return this.RepositorioDeAluno.ObterAlunoPorId(id);
        }

        public List<MA_ALUNO> ObterTodosOsAlunos()
        {
            return this.RepositorioDeAluno.ObterTodosOsAlunos();
        }

        public List<MA_ALUNO> ObterTodosOsAlunosPorNome(String nome)
        {
            return this.RepositorioDeAluno.ObterTodosOsAlunosPorNome(nome);
        }

        public MA_ALUNO ObterAlunoPorLogin(String login)
        {
            return this.RepositorioDeAluno.ObterAlunoPorLogin(login);
        }

        public void InserirAluno(MA_ALUNO aluno)
        {
            this.RepositorioDeAluno.InserirAluno(aluno);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverAluno(MA_ALUNO aluno)
        {
            this.RepositorioDeAluno.RemoverAluno(aluno);
        }

        public void AtualizarAluno(MA_ALUNO aluno)
        {
            this.RepositorioDeAluno.AtualizarAluno(aluno);
        }
    }
}