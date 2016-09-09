using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeGosto
    {
        public RepositorioDeGosto RepositorioDeGosto { get; set; }

        public GestorDeGosto()
        {
            this.RepositorioDeGosto = new RepositorioDeGosto();
        }

        public List<GOSTO> ObterTodosOsRegistrosDoQueSePodeEnsinado()
        {
            return this.RepositorioDeGosto.ObterTodosOsRegistrosDoQueSePodeEnsinado();
        }

        public List<GOSTO> ObterTodosOsRegistrosDeGostoPorNome(String nome)
        {
            return this.RepositorioDeGosto.ObterTodosOsRegistrosDeGostoPorNome(nome);
        }

        public void InserirNovoGosto(GOSTO gosto)
        {
            this.RepositorioDeGosto.InserirNovoGosto(gosto);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeGosto.BuscarQuantidadeRegistros();
        }

        public void RemoverGosto(GOSTO gosto)
        {
            this.RepositorioDeGosto.RemoverGosto(gosto);
        }

        public void AtualizarGosto(GOSTO gosto)
        {
            this.RepositorioDeGosto.AtualizarGosto(gosto);
        }
    }
}
