using System.Collections.Generic;
using System.Data.Common;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.Postgres.Conexao
{
    public abstract class CursorGenerico
    {
        protected DbConnection Conexao;
        protected Dictionary<string, int> Campi;
        protected string StringConexao;
        
        public void Close()
        {
            Conexao.Close();
        }

        public abstract void InserirParticipante(Participante participante);

        public abstract void InserirConteudo(Participante participante, int codigoParticipante);

        protected abstract void BuscaCampi();
    }
}
