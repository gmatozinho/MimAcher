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
            StringConexao = "Server = localhost\\SQLEXPRESS;Database=mimacher;Trusted_Connection=True;";
            Conexao = new SqlConnection(StringConexao);
            Conexao.Open();

            BuscaCampi();
        }

        override
        public void InserirParticipante(Participante participante)
        {
            try
            {
                if (Conexao.State == ConnectionState.Closed)
                    Conexao.Open();

                SqlCommand comandoSql = new SqlCommand("inserir_participante", (SqlConnection) Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosParticipante(comandoSql, participante, Campi);

                //Este parâmetro é exlusivo do SQL server
                var parametro = comandoSql.CreateParameter();
                parametro.DbType = DbType.Int32;
                parametro.ParameterName = "codigo_participante";
                parametro.Direction = ParameterDirection.Output;
                comandoSql.Parameters.Add(parametro);

                comandoSql.Prepare();
                comandoSql.ExecuteNonQuery();
                int codigoParticipante = (int) comandoSql.Parameters["codigo_participante"].Value;

                InserirConteudo(participante, codigoParticipante);
            }
            catch (Exception ex)
            {
                Console.Write("Deu pau jovem: " + ex.Message);
            }
        }

        override
        public void InserirConteudo(Participante participante, int codigoParticipante)
        {
            SqlCommand comandoSql;

            foreach (string hobbie in participante.Hobbies.Conteudo)
            {
                comandoSql = new SqlCommand("inserir_hobbie", (SqlConnection)Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSql, hobbie, codigoParticipante);

                comandoSql.ExecuteNonQuery();
            }

            foreach (string ensinar in participante.Ensinar.Conteudo)
            {
                comandoSql = new SqlCommand("inserir_ensinar", (SqlConnection)Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSql, ensinar, codigoParticipante);

                comandoSql.ExecuteNonQuery();
            }

            foreach (string aprender in participante.Aprender.Conteudo)
            {
                comandoSql = new SqlCommand("inserir_aprender", (SqlConnection)Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSql, aprender, codigoParticipante);

                comandoSql.ExecuteNonQuery();
            }
        }
        
        override
        protected void BuscaCampi()
        {
            Campi = new Dictionary<string, int>();
            SqlCommand comandoSql = new SqlCommand("SELECT local, cod_campus FROM ma_campus;", (SqlConnection)Conexao);
            SqlDataReader leitor = comandoSql.ExecuteReader();

            while (leitor.Read())
            {
                Campi[leitor[0].ToString()] = Int32.Parse(leitor[1].ToString());
            }

            leitor.Close();
            leitor.Dispose();
        }

    }
}
