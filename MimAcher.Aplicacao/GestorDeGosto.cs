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

        public MA_GOSTO ObterGostoPorId(int id)
        {
            return this.RepositorioDeGosto.ObterGostoPorId(id);
        }

        public List<MA_GOSTO> ObterTodosOsGostos()
        {
            return this.RepositorioDeGosto.ObterTodosOsGostos();
        }

        public List<MA_GOSTO> ObterTodosOsRegistrosDeGostoPorNome(String nome)
        {
            return this.RepositorioDeGosto.ObterTodosOsRegistrosDeGostoPorNome(nome);
        }

        public void InserirNovoGosto(MA_GOSTO gosto)
        {
            this.RepositorioDeGosto.InserirNovoGosto(gosto);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeGosto.BuscarQuantidadeRegistros();
        }

        public void RemoverGosto(MA_GOSTO gosto)
        {
            this.RepositorioDeGosto.RemoverGosto(gosto);
        }

        public void AtualizarGosto(MA_GOSTO gosto)
        {
            this.RepositorioDeGosto.AtualizarGosto(gosto);
        }
    }
}
