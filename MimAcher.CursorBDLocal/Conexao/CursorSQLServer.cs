using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Postgres.Conexao.Parametros;

namespace MimAcher.Postgres.Conexao
{
    internal class CursorSqlServer : CursorGenerico
    {
         public CursorSqlServer()
        {
            stringConexao = "Server = localhost\\SQLEXPRESS;Database=mimacher;Trusted_Connection=True;";
            conexao = new SqlConnection(stringConexao);
            conexao.Open();

            BuscaCampi();
        }

        override
        public void InserirParticipante(Participante participante)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();

                SqlCommand comandoSQL = new SqlCommand("inserir_participante", (SqlConnection) conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosParticipante(comandoSQL, participante, campi);

                //Este parâmetro é exlusivo do SQL server
                var parametro = comandoSQL.CreateParameter();
                parametro.DbType = DbType.Int32;
                parametro.ParameterName = "codigo_participante";
                parametro.Direction = ParameterDirection.Output;
                comandoSQL.Parameters.Add(parametro);

                comandoSQL.Prepare();
                comandoSQL.ExecuteNonQuery();
                int codigo_participante = (int) comandoSQL.Parameters["codigo_participante"].Value;

                InserirConteudo(participante, codigo_participante);
            }
            catch (Exception ex)
            {
                Console.Write("Deu pau jovem: " + ex.Message);
            }
        }

        override
        public void InserirConteudo(Participante participante, int codigo_participante)
        {
            SqlCommand comandoSQL;

            foreach (string hobbie in participante.Hobbies.Conteudo)
            {
                comandoSQL = new SqlCommand("inserir_hobbie", (SqlConnection)conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, hobbie, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }

            foreach (string ensinar in participante.Ensinar.Conteudo)
            {
                comandoSQL = new SqlCommand("inserir_ensinar", (SqlConnection)conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, ensinar, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }

            foreach (string aprender in participante.Aprender.Conteudo)
            {
                comandoSQL = new SqlCommand("inserir_aprender", (SqlConnection)conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, aprender, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }
        }
        
        override
        protected void BuscaCampi()
        {
            campi = new Dictionary<string, int>();
            SqlCommand comandoSQL = new SqlCommand("SELECT local, cod_campus FROM ma_campus;", (SqlConnection)conexao);
            SqlDataReader leitor = comandoSQL.ExecuteReader();

            while (leitor.Read())
            {
                campi[leitor[0].ToString()] = Int32.Parse(leitor[1].ToString());
            }

            leitor.Close();
            leitor.Dispose();
        }

    }
}
