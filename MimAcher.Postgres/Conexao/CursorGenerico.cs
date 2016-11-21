using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.BancoDadosLocal.Conexao
{
    public abstract class CursorGenerico
    {
        protected DbConnection conexao;
        protected Dictionary<string, int> campi;
        protected string stringConexao;
        
        public void Close()
        {
            conexao.Close();
        }

        public abstract void InserirParticipante(Participante participante);

        public abstract void InserirConteudo(Participante participante, int codigo_participante);

        protected abstract void BuscaCampi();
    }
}
