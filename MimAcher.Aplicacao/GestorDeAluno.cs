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

        public List<ALUNO> ObterTodosOsAlunos()
        {
            return this.RepositorioDeAluno.ObterTodosOsAlunos();
        }

        public List<ALUNO> ObterTodosOsAlunosPorNome(String nome)
        {
            return this.RepositorioDeAluno.ObterTodosOsAlunosPorNome(nome);
        }

        public ALUNO ObterAlunoPorLogin(String login)
        {
            return this.RepositorioDeAluno.ObterAlunoPorLogin(login);
        }


        public void InserirAluno(ALUNO Aluno)
        {
            this.RepositorioDeAluno.InserirAluno(Aluno);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverAluno(ALUNO Aluno)
        {
            return this.RepositorioDeAluno.RemoverAluno(Aluno);
        }


    }
