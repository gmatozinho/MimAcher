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

        public MA_APRENDER ObterAprendizadoPorId(int id)
        {
            return this.RepositorioDeAprender.ObterAprendizadoPorId(id);
        }

        public List<MA_APRENDER> ObterTodosOsRegistrosDoQueSePodeAprender()
        {
            return this.RepositorioDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender();
        }

        public List<MA_APRENDER> ObterTodosOsRegistrosDoQueSePodeAprenderPorNome(String nome)
        {
            return this.RepositorioDeAprender.ObterTodosOsRegistrosDoQueSePodeAprenderPorNome(nome);
        }

        public void InserirNovoAprendizado(MA_APRENDER aprender)
        {
            this.RepositorioDeAprender.InserirNovoAprendizado(aprender);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAprender.BuscarQuantidadeRegistros();
        }

        public void RemoverAprendizado(MA_APRENDER aprender)
        {
            this.RepositorioDeAprender.RemoverAprendizado(aprender);
        }

        public void AtualizarAprendizado(MA_APRENDER aprender)
        {
            this.RepositorioDeAprender.AtualizarAprendizado(aprender);
        }
    }
}
