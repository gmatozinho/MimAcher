using System.Collections.Generic;
using System.Data.Common;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.Postgres.Conexao
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
