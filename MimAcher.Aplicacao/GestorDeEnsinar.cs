using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeEnsinar
    {
        public RepositorioDeEnsinar RepositorioDeEnsinar { get; set; }

        public GestorDeEnsinar()
        {
            this.RepositorioDeEnsinar = new RepositorioDeEnsinar();
        }

        public List<ENSINAR> ObterTodosOsRegistrosDoQueSePodeEnsinado()
        {
            return this.RepositorioDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado();
        }

        public List<ENSINAR> ObterTodosOsRegistrosDoQuePodemSerEnsinadosPorNome(String nome)
        {
            return this.RepositorioDeEnsinar.ObterTodosOsRegistrosDoQuePodemSerEnsinadosPorNome(nome);
        }

        public void InserirNovoEnsino(ENSINAR ensino)
        {
            this.RepositorioDeEnsinar.InserirNovoEnsino(ensino);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeEnsinar.BuscarQuantidadeRegistros();
        }

        public void RemoverEnsino(ENSINAR ensino)
        {
            this.RepositorioDeEnsinar.RemoverEnsino(ensino);
        }

        public void AtualizarEnsino(ENSINAR ensino)
        {
            this.RepositorioDeEnsinar.AtualizarEnsino(ensino);
        }
    }
}
