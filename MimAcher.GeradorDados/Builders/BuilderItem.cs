using MimAcher.Entidades;
using MimAcher.GeradorDados.Geradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Builders
{
    internal class BuilderItem
    {
        private GeradorItem geradorItens = new GeradorItem();
        private Random random = new Random();

        private ListaItens GerarItensParticipante()
        {
            ListaItens listaItens = new ListaItens();
            int quantidadeItens = random.Next(0, 10);
            
            while (quantidadeItens > 0)
            {
                listaItens.AdicionarItem(geradorItens.GerarItem());
                quantidadeItens--;
            }

            return listaItens;
        }

        private ListaItens GerarItensNac()
        {
            throw new NotSupportedException("Itens para NAC ainda não foram implementados!");
        }

        public ListaItens GerarListaItens(TipoUsuario tipo_usuario)
        {
            ListaItens lista_itens = new ListaItens();
            
            switch (tipo_usuario)
            {
                case (TipoUsuario.PARTICIPANTE):
                    lista_itens = this.GerarItensParticipante();
                    break;
                case (TipoUsuario.NAC):
                    lista_itens = this.GerarItensNac();
                    break;
            }

            return lista_itens;
        }
    }
}
