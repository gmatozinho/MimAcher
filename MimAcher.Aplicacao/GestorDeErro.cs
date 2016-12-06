using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeErro
    {
        public RepositorioDeErro RepositorioDeErro { get; set; }

        public GestorDeErro()
        {
            this.RepositorioDeErro = new RepositorioDeErro();
        }

        public MA_ERRO ObterErroPorId(int id)
        {
            return this.RepositorioDeErro.ObterErroPorId(id);
        }

        public List<MA_ERRO> ObterTodosOsErros()
        {
            return this.RepositorioDeErro.ObterTodosOsErros();
        }

        public List<MA_ERRO> ObterTodosOsErrosPorTipo(String tipo)
        {
            return this.RepositorioDeErro.ObterTodosOsErrosPorTipo(tipo);
        }

        public void InserirErro(MA_ERRO erro)
        {
            this.RepositorioDeErro.InserirErro(erro);
        }

        public Boolean InserirErroComRetorno(MA_ERRO erro)
        {
            return this.RepositorioDeErro.InserirErroComRetorno(erro);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeErro.BuscarQuantidadeRegistros();
        }

        public void RemoverErro(MA_ERRO erro)
        {
            this.RepositorioDeErro.RemoverErro(erro);
        }

        public void AtualizarErro(MA_ERRO erro)
        {
            this.RepositorioDeErro.AtualizarErro(erro);
        }

        public Boolean AtualizarErroComRetorno(MA_ERRO erro)
        {
            return this.RepositorioDeErro.AtualizarErroComRetorno(erro);
        }
    }
}
