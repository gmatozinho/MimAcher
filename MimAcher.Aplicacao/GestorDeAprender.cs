using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeAprender
    {
        public RepositorioDeAprender RepositorioDeAprender { get; set; }

        public GestorDeAprender()
        {
            this.RepositorioDeAprender = new RepositorioDeAprender();
        }

        public List<APRENDER> ObterTodosOsRegistrosDoQueSePodeAprender()
        {
            return RepositorioDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender();
        }

        public List<APRENDER> ObterTodosOsRegistrosDoQueSePodeAprenderPorNome(String nome)
        {
            return this.RepositorioDeAprender.ObterTodosOsRegistrosDoQueSePodeAprenderPorNome(nome);
        }

        public void InserirNovoAprendizado(APRENDER aprender)
        {
            this.InserirNovoAprendizado(aprender);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAprender.BuscarQuantidadeRegistros();
        }

        public void RemoverAprendizado(APRENDER aprender)
        {
            this.RepositorioDeAprender.RemoverAprendizado(aprender);
        }

        public void AtualizarAprendizado(APRENDER aprender)
        {
            this.RepositorioDeAprender.AtualizarAprendizado(aprender);
        }
    }
}
